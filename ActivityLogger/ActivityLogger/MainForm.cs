using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;
using Timer = System.Timers.Timer;

namespace ActivityLogger
{
    using System.Configuration;

    public partial class MainForm : Form
    {
        private List<DateTimeInterval> _activityIntervals;
        private DateTimeInterval[] _selectedIntervals;

        private Timer _saveTimer;
        private Timer _uiUpdateTimer;

        private TimeSpan _minInactivityTime = TimeSpan.FromMinutes(10);
        private TimeSpan _maxInactivityTime = TimeSpan.FromHours(3);

        private double _saveTimerInterval = 10 * 60 * 1000;
        private double _uiUpdateInterval = 60 * 1000;

        private string _logsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.bin");

        private bool _completeClosing = false;

        private RegistryKey _registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        private string _applicationName = "ActivityLogger";

        private readonly string _dayStartOffsetHoursKey = "DayStartOffsetHours";

        public MainForm()
        {
            InitializeComponent();
            InitializeHooks();

            _activityIntervals = new List<DateTimeInterval>();

            _saveTimer = new Timer();
            _saveTimer.Interval = _saveTimerInterval;
            _saveTimer.Elapsed += SaveTimerOnElapsed;
            _saveTimer.Start();

            _uiUpdateTimer = new Timer();
            _uiUpdateTimer.Interval = _uiUpdateInterval;
            _uiUpdateTimer.Elapsed += UiUpdateTimerOnElapsed;
            _uiUpdateTimer.Start();

            Select();
            Focus();

            notifyIcon.Visible = false;

            radioButtonToday.Checked = true;

            checkBoxAutoStart.Checked = _registryKey.GetValue(_applicationName) != null;
            
            if (int.TryParse(
                ConfigurationManager.AppSettings[_dayStartOffsetHoursKey],
                out var dayStartOffsetHours))
            {
                numericUpDownDayStartOffset.Value = dayStartOffsetHours;
            }
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            LoadLogs();
            UpdateUi();
        }

        private void SaveLogs()
        {
            using (var fileStream = new FileStream(_logsPath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, _activityIntervals);
            }
        }

        private void LoadLogs()
        {
            if (!File.Exists(_logsPath)) return;

            using (var fileStream = new FileStream(_logsPath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                _activityIntervals = binaryFormatter.Deserialize(fileStream) as List<DateTimeInterval>;
            }
        }

        private void SaveTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            SaveLogs();

            BeginInvoke(new Action(() => { toolStripStatusLabel.Text = $"{DateTime.Now.ToLongTimeString()}: logs saved"; }));
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            var hoursTimeSpan =
                timeSpan
                - TimeSpan.FromMinutes(timeSpan.Minutes)
                - TimeSpan.FromSeconds(timeSpan.Seconds);

            return $"{(int)Math.Floor(hoursTimeSpan.TotalHours):00}:{timeSpan.Minutes:00}";
        }

        private IEnumerable<DateTimeInterval> GetInactivityIntervals()
        {
            for (var i = 0; i < _selectedIntervals.Length; i++)
            {
                if (i > 0 && _selectedIntervals[i].Start - _selectedIntervals[i - 1].End <= _maxInactivityTime)
                {
                    yield return new DateTimeInterval(_selectedIntervals[i - 1].End, _selectedIntervals[i].Start);
                }
            }
        }

        private void UpdateUi()
        {
            CalculateSelectedIntervals();

            listViewIntervals.Items.Clear();
            richTextBox.Text = string.Empty;

            if (_selectedIntervals == null || _selectedIntervals.Length == 0)
            {
                textBoxTotal.Text = textBoxActive.Text = textBoxInactive.Text = textBoxStart.Text = textBoxEnd.Text = "N/A";
                return;
            }

            for (var i = 0; i < _selectedIntervals.Length; i++)
            {
                if (i > 0 && _selectedIntervals[i].Start - _selectedIntervals[i - 1].End <= _maxInactivityTime)
                {
                    listViewIntervals.Items.Add(new ListViewItem()
                    {
                        Text = "Inactivity",
                        SubItems =
                            {
                                FormatTimeSpan(_selectedIntervals[i].Start - _selectedIntervals[i - 1].End),
                                _selectedIntervals[i - 1].End.ToShortTimeString(),
                                _selectedIntervals[i].Start.ToShortTimeString(),
                            }
                    });

                    richTextBox.Text +=
                        $"Break {FormatTimeSpan(_selectedIntervals[i].Start - _selectedIntervals[i - 1].End)} {Environment.NewLine}";
                }
                else if (i > 0)
                {
                    richTextBox.Text += $"End of session{Environment.NewLine}";
                    listViewIntervals.Items.Add(new ListViewItem()
                    {
                        Text = "End of session",
                        SubItems =
                            {
                                "-",
                                "-",
                                "-"
                            }
                    });
                }

                listViewIntervals.Items.Add(new ListViewItem()
                {
                    Text = "Activity",
                    SubItems =
                        {
                            FormatTimeSpan(_selectedIntervals[i].Duration),
                            _selectedIntervals[i].Start.ToShortTimeString(),
                            _selectedIntervals[i].End.ToShortTimeString(),
                        }
                });

                richTextBox.Text +=
                    $"Activity {_selectedIntervals[i].Start.ToShortTimeString()} - {_selectedIntervals[i].End.ToShortTimeString()} ({FormatTimeSpan(_selectedIntervals[i].Duration)}) {Environment.NewLine}";
            }

            textBoxStart.Text = string.Join(" ", _selectedIntervals.First().Start.ToString("HH:mm"),
                _selectedIntervals.First().Start.Date != _selectedIntervals.Last().End.Date
                    ? _selectedIntervals.First().Start.ToShortDateString()
                    : string.Empty);

            textBoxEnd.Text = string.Join(" ", _selectedIntervals.Last().End.ToString("HH:mm"),
                _selectedIntervals.First().Start.Date != _selectedIntervals.Last().End.Date
                    ? _selectedIntervals.Last().Start.ToShortDateString()
                    : string.Empty);

            var active = _selectedIntervals.Aggregate(TimeSpan.Zero, (current, interval) => current.Add(interval.Duration));
            var inactive = GetInactivityIntervals().Aggregate(TimeSpan.Zero, (current, interval) => current.Add(interval.Duration));

            var total = active + inactive;
            textBoxTotal.Text = FormatTimeSpan(total);

            var activePercent = active.TotalMilliseconds / total.TotalMilliseconds * 100;
            textBoxActive.Text = $"{FormatTimeSpan(active)} ({activePercent.ToString("##0")}%)";

            var inactivePercent = inactive.TotalMilliseconds / total.TotalMilliseconds * 100;
            textBoxInactive.Text = $"{FormatTimeSpan(inactive)} ({inactivePercent.ToString("##0")}%)";

            toolStripStatusLabel.Text = $"{DateTime.Now.ToLongTimeString()}: UI updated";
        }

        private void UiUpdateTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            BeginInvoke(new Action(UpdateUi));
        }

        private void ProcessActivity()
        {
            if (_activityIntervals.Count == 0)
            {
                _activityIntervals.Add(new DateTimeInterval(DateTime.Now));
                return;
            }

            if (DateTime.Now - _activityIntervals.Last().End >= _minInactivityTime)
            {
                _activityIntervals.Add(new DateTimeInterval(DateTime.Now));
            }

            _activityIntervals.Last().End = DateTime.Now;
        }

        private void CalculateSelectedIntervals()
        {
            _selectedIntervals =
                _activityIntervals
                    .Where(i =>
                        dateTimePickerEnd.Checked
                            ? i.Start >= dateTimePickerStart.Value.Date.AddHours((double)numericUpDownDayStartOffset.Value)
                              && i.Start <= dateTimePickerEnd.Value.Date.AddDays(1).AddHours((double)numericUpDownDayStartOffset.Value)
                            : i.Start >= dateTimePickerStart.Value.Date.AddHours((double)numericUpDownDayStartOffset.Value)
                            && i.End <= dateTimePickerStart.Value.AddDays(1).AddHours((double)numericUpDownDayStartOffset.Value))
                    .ToArray();
        }

        private void DateTimePickerValueChanged(object sender, EventArgs e)
        {
            CalculateSelectedIntervals();
            UpdateUi();
        }

        private void MinimizeToTray()
        {
            Hide();
            notifyIcon.Visible = true;

            _uiUpdateTimer.Stop();
        }

        private void RestoreFromTray()
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;

            radioButtonToday.Checked = false;
            radioButtonToday.Checked = true;

            _uiUpdateTimer.Start();
            UpdateUi();
        }

        private void NotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
        {
            RestoreFromTray();
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_completeClosing) return;

            e.Cancel = true;
            MinimizeToTray();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Stop logging?", "Complete exit", MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
                return;

            _completeClosing = true;
            Close();
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveLogs();
            Unhook();
        }

        private void AutostartToolStripMenuItemCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoStart.Checked)
            {
                _registryKey.SetValue(_applicationName, Application.ExecutablePath);
            }
            else
            {
                _registryKey.DeleteValue(_applicationName, false);
            }
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStart.Enabled = false;
            dateTimePickerEnd.Enabled = false;
            dateTimePickerEnd.Checked = false;

            if (radioButtonToday.Checked)
            {
                dateTimePickerEnd.Checked = false;
                dateTimePickerEnd.Value = DateTime.Today;

                dateTimePickerStart.Value = DateTime.Today;
            }

            if (radioButtonYesterday.Checked)
            {
                dateTimePickerEnd.Checked = false;
                dateTimePickerEnd.Value = DateTime.Today.AddDays(-1);

                dateTimePickerStart.Value = DateTime.Today.AddDays(-1);
            }

            if (radioButtonWeek.Checked)
            {
                dateTimePickerEnd.Checked = true;

                dateTimePickerStart.Value = DateTime.Today.AddDays(1 - (DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)DateTime.Today.DayOfWeek));
                dateTimePickerEnd.Value = DateTime.Today.AddDays(7 - DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)DateTime.Today.DayOfWeek);
            }

            if (radioButtonMonth.Checked)
            {
                dateTimePickerEnd.Checked = true;

                dateTimePickerStart.Value = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                dateTimePickerEnd.Value = DateTime.Today.AddDays(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - DateTime.Today.Day);
            }

            if (radioButtonCustom.Checked)
            {
                dateTimePickerStart.Enabled = true;
                dateTimePickerEnd.Enabled = true;
            }
        }

        private void NumericUpDownDayStartOffsetValueChanged(object sender, EventArgs e)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var entry = configuration.AppSettings.Settings[_dayStartOffsetHoursKey];
            if (entry == null)
                configuration.AppSettings.Settings.Add(_dayStartOffsetHoursKey, numericUpDownDayStartOffset.Value.ToString());
            else
                configuration.AppSettings.Settings[_dayStartOffsetHoursKey].Value = numericUpDownDayStartOffset.Value.ToString();

            configuration.Save(ConfigurationSaveMode.Modified);
            
            UpdateUi();
        }
    }
}
