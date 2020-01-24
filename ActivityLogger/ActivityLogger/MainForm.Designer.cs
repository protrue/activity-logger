namespace ActivityLogger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.textBoxActive = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.textBoxInactive = new System.Windows.Forms.TextBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.labelFirst = new System.Windows.Forms.Label();
            this.labelLast = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelActive = new System.Windows.Forms.Label();
            this.labelInactive = new System.Windows.Forms.Label();
            this.listViewIntervals = new System.Windows.Forms.ListView();
            this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDuration = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderStart = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderEnd = new System.Windows.Forms.ColumnHeader();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBoxInterval = new System.Windows.Forms.GroupBox();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonWeek = new System.Windows.Forms.RadioButton();
            this.radioButtonYesterday = new System.Windows.Forms.RadioButton();
            this.radioButtonToday = new System.Windows.Forms.RadioButton();
            this.labelDash = new System.Windows.Forms.Label();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.numericUpDownDayStartOffset = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.labelDayStartOffset = new System.Windows.Forms.Label();
            this.labelAutostart = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxInterval.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDayStartOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(6, 151);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(120, 21);
            this.dateTimePickerStart.TabIndex = 0;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(147, 17);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.ReadOnly = true;
            this.textBoxStart.Size = new System.Drawing.Size(120, 21);
            this.textBoxStart.TabIndex = 1;
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Location = new System.Drawing.Point(147, 44);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.ReadOnly = true;
            this.textBoxEnd.Size = new System.Drawing.Size(120, 21);
            this.textBoxEnd.TabIndex = 2;
            // 
            // textBoxActive
            // 
            this.textBoxActive.Location = new System.Drawing.Point(147, 98);
            this.textBoxActive.Name = "textBoxActive";
            this.textBoxActive.ReadOnly = true;
            this.textBoxActive.Size = new System.Drawing.Size(120, 21);
            this.textBoxActive.TabIndex = 3;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ActivityLogger";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.exitToolStripMenuItem });
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Checked = false;
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(147, 151);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowCheckBox = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(120, 21);
            this.dateTimePickerEnd.TabIndex = 8;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
            // 
            // textBoxInactive
            // 
            this.textBoxInactive.Location = new System.Drawing.Point(147, 125);
            this.textBoxInactive.Name = "textBoxInactive";
            this.textBoxInactive.ReadOnly = true;
            this.textBoxInactive.Size = new System.Drawing.Size(120, 21);
            this.textBoxInactive.TabIndex = 9;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Location = new System.Drawing.Point(147, 71);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(120, 21);
            this.textBoxTotal.TabIndex = 10;
            // 
            // labelFirst
            // 
            this.labelFirst.Location = new System.Drawing.Point(6, 17);
            this.labelFirst.Name = "labelFirst";
            this.labelFirst.Size = new System.Drawing.Size(100, 21);
            this.labelFirst.TabIndex = 11;
            this.labelFirst.Text = "First";
            this.labelFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLast
            // 
            this.labelLast.Location = new System.Drawing.Point(6, 44);
            this.labelLast.Name = "labelLast";
            this.labelLast.Size = new System.Drawing.Size(100, 21);
            this.labelLast.TabIndex = 12;
            this.labelLast.Text = "Last";
            this.labelLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotal
            // 
            this.labelTotal.Location = new System.Drawing.Point(6, 71);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(100, 21);
            this.labelTotal.TabIndex = 13;
            this.labelTotal.Text = "Total";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelActive
            // 
            this.labelActive.Location = new System.Drawing.Point(6, 98);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(100, 21);
            this.labelActive.TabIndex = 14;
            this.labelActive.Text = "Active";
            this.labelActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInactive
            // 
            this.labelInactive.Location = new System.Drawing.Point(6, 125);
            this.labelInactive.Name = "labelInactive";
            this.labelInactive.Size = new System.Drawing.Size(100, 21);
            this.labelInactive.TabIndex = 15;
            this.labelInactive.Text = "Inactive";
            this.labelInactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewIntervals
            // 
            this.listViewIntervals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeaderType, this.columnHeaderDuration, this.columnHeaderStart, this.columnHeaderEnd });
            this.listViewIntervals.FullRowSelect = true;
            this.listViewIntervals.GridLines = true;
            this.listViewIntervals.Location = new System.Drawing.Point(297, 31);
            this.listViewIntervals.Name = "listViewIntervals";
            this.listViewIntervals.Size = new System.Drawing.Size(475, 252);
            this.listViewIntervals.TabIndex = 16;
            this.listViewIntervals.UseCompatibleStateImageBehavior = false;
            this.listViewIntervals.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 115;
            // 
            // columnHeaderDuration
            // 
            this.columnHeaderDuration.Text = "Duration";
            this.columnHeaderDuration.Width = 115;
            // 
            // columnHeaderStart
            // 
            this.columnHeaderStart.Text = "Start";
            this.columnHeaderStart.Width = 115;
            // 
            // columnHeaderEnd
            // 
            this.columnHeaderEnd.Text = "End";
            this.columnHeaderEnd.Width = 115;
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(297, 289);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(475, 247);
            this.richTextBox.TabIndex = 17;
            this.richTextBox.Text = "";
            // 
            // groupBoxInterval
            // 
            this.groupBoxInterval.Controls.Add(this.radioButtonCustom);
            this.groupBoxInterval.Controls.Add(this.radioButtonMonth);
            this.groupBoxInterval.Controls.Add(this.radioButtonWeek);
            this.groupBoxInterval.Controls.Add(this.radioButtonYesterday);
            this.groupBoxInterval.Controls.Add(this.radioButtonToday);
            this.groupBoxInterval.Controls.Add(this.dateTimePickerStart);
            this.groupBoxInterval.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxInterval.Controls.Add(this.labelDash);
            this.groupBoxInterval.Location = new System.Drawing.Point(12, 27);
            this.groupBoxInterval.Name = "groupBoxInterval";
            this.groupBoxInterval.Size = new System.Drawing.Size(279, 185);
            this.groupBoxInterval.TabIndex = 18;
            this.groupBoxInterval.TabStop = false;
            this.groupBoxInterval.Text = "Interval";
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point(6, 120);
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size(67, 19);
            this.radioButtonCustom.TabIndex = 10;
            this.radioButtonCustom.TabStop = true;
            this.radioButtonCustom.Text = "Custom";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            this.radioButtonCustom.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Location = new System.Drawing.Point(6, 95);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(86, 19);
            this.radioButtonMonth.TabIndex = 3;
            this.radioButtonMonth.TabStop = true;
            this.radioButtonMonth.Text = "This month";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            this.radioButtonMonth.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonWeek
            // 
            this.radioButtonWeek.AutoSize = true;
            this.radioButtonWeek.Location = new System.Drawing.Point(6, 70);
            this.radioButtonWeek.Name = "radioButtonWeek";
            this.radioButtonWeek.Size = new System.Drawing.Size(80, 19);
            this.radioButtonWeek.TabIndex = 2;
            this.radioButtonWeek.TabStop = true;
            this.radioButtonWeek.Text = "This week";
            this.radioButtonWeek.UseVisualStyleBackColor = true;
            this.radioButtonWeek.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonYesterday
            // 
            this.radioButtonYesterday.AutoSize = true;
            this.radioButtonYesterday.Location = new System.Drawing.Point(6, 45);
            this.radioButtonYesterday.Name = "radioButtonYesterday";
            this.radioButtonYesterday.Size = new System.Drawing.Size(78, 19);
            this.radioButtonYesterday.TabIndex = 1;
            this.radioButtonYesterday.TabStop = true;
            this.radioButtonYesterday.Text = "Yesterday";
            this.radioButtonYesterday.UseVisualStyleBackColor = true;
            this.radioButtonYesterday.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonToday
            // 
            this.radioButtonToday.AutoSize = true;
            this.radioButtonToday.Location = new System.Drawing.Point(6, 20);
            this.radioButtonToday.Name = "radioButtonToday";
            this.radioButtonToday.Size = new System.Drawing.Size(58, 19);
            this.radioButtonToday.TabIndex = 0;
            this.radioButtonToday.TabStop = true;
            this.radioButtonToday.Text = "Today";
            this.radioButtonToday.UseVisualStyleBackColor = true;
            this.radioButtonToday.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // labelDash
            // 
            this.labelDash.Location = new System.Drawing.Point(126, 151);
            this.labelDash.Name = "labelDash";
            this.labelDash.Size = new System.Drawing.Size(21, 21);
            this.labelDash.TabIndex = 9;
            this.labelDash.Text = "-";
            this.labelDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.labelFirst);
            this.groupBoxStatistics.Controls.Add(this.textBoxStart);
            this.groupBoxStatistics.Controls.Add(this.textBoxEnd);
            this.groupBoxStatistics.Controls.Add(this.textBoxActive);
            this.groupBoxStatistics.Controls.Add(this.textBoxInactive);
            this.groupBoxStatistics.Controls.Add(this.labelInactive);
            this.groupBoxStatistics.Controls.Add(this.textBoxTotal);
            this.groupBoxStatistics.Controls.Add(this.labelActive);
            this.groupBoxStatistics.Controls.Add(this.labelLast);
            this.groupBoxStatistics.Controls.Add(this.labelTotal);
            this.groupBoxStatistics.Location = new System.Drawing.Point(12, 218);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(279, 158);
            this.groupBoxStatistics.TabIndex = 19;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.numericUpDownDayStartOffset);
            this.groupBoxSettings.Controls.Add(this.checkBoxAutoStart);
            this.groupBoxSettings.Controls.Add(this.labelDayStartOffset);
            this.groupBoxSettings.Controls.Add(this.labelAutostart);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 382);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(279, 64);
            this.groupBoxSettings.TabIndex = 20;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // numericUpDownDayStartOffset
            // 
            this.numericUpDownDayStartOffset.Location = new System.Drawing.Point(147, 36);
            this.numericUpDownDayStartOffset.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numericUpDownDayStartOffset.Minimum = new decimal(new int[] { 12, 0, 0, -2147483648 });
            this.numericUpDownDayStartOffset.Name = "numericUpDownDayStartOffset";
            this.numericUpDownDayStartOffset.Size = new System.Drawing.Size(40, 21);
            this.numericUpDownDayStartOffset.TabIndex = 3;
            this.numericUpDownDayStartOffset.ValueChanged += new System.EventHandler(this.NumericUpDownDayStartOffsetValueChanged);
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.Location = new System.Drawing.Point(147, 15);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(15, 21);
            this.checkBoxAutoStart.TabIndex = 2;
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // labelDayStartOffset
            // 
            this.labelDayStartOffset.Location = new System.Drawing.Point(6, 38);
            this.labelDayStartOffset.Name = "labelDayStartOffset";
            this.labelDayStartOffset.Size = new System.Drawing.Size(130, 21);
            this.labelDayStartOffset.TabIndex = 1;
            this.labelDayStartOffset.Text = "Day start offset (hours)";
            // 
            // labelAutostart
            // 
            this.labelAutostart.Location = new System.Drawing.Point(6, 17);
            this.labelAutostart.Name = "labelAutostart";
            this.labelAutostart.Size = new System.Drawing.Size(130, 21);
            this.labelAutostart.TabIndex = 0;
            this.labelAutostart.Text = "Autostart";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.groupBoxInterval);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.listViewIntervals);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActivityLogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxInterval.ResumeLayout(false);
            this.groupBoxInterval.PerformLayout();
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDayStartOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.Label labelDayStartOffset;
        private System.Windows.Forms.Label labelAutostart;
        private System.Windows.Forms.NumericUpDown numericUpDownDayStartOffset;

        private System.Windows.Forms.GroupBox groupBoxSettings;

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.TextBox textBoxActive;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxInactive;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label labelFirst;
        private System.Windows.Forms.Label labelLast;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.Label labelInactive;
        private System.Windows.Forms.ListView listViewIntervals;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderStart;
        private System.Windows.Forms.ColumnHeader columnHeaderEnd;
        private System.Windows.Forms.ColumnHeader columnHeaderDuration;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.GroupBox groupBoxInterval;
        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.RadioButton radioButtonWeek;
        private System.Windows.Forms.RadioButton radioButtonYesterday;
        private System.Windows.Forms.RadioButton radioButtonToday;
        private System.Windows.Forms.Label labelDash;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
    }
}