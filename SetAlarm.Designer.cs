namespace SpotiAlarm
{
  partial class SetAlarm
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
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.nextAlarm = new System.Windows.Forms.Label();
      this.msmMain = new MetroFramework.Components.MetroStyleManager(this.components);
      this.repeatingAlarm = new MetroFramework.Controls.MetroCheckBox();
      this.minComBox = new MetroFramework.Controls.MetroComboBox();
      this.HourComBox = new MetroFramework.Controls.MetroComboBox();
      this.metroLink1 = new MetroFramework.Controls.MetroLink();
      this.sundayBox = new MetroFramework.Controls.MetroCheckBox();
      this.mondayBox = new MetroFramework.Controls.MetroCheckBox();
      this.tuesdayBox = new MetroFramework.Controls.MetroCheckBox();
      this.wednesdayBox = new MetroFramework.Controls.MetroCheckBox();
      this.saturdayBox = new MetroFramework.Controls.MetroCheckBox();
      this.fridayBox = new MetroFramework.Controls.MetroCheckBox();
      this.thursdayBox = new MetroFramework.Controls.MetroCheckBox();
      this.dayComBox = new MetroFramework.Controls.MetroComboBox();
      this.dayLabel = new System.Windows.Forms.Label();
      this.bgWorker = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(360, 42);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(70, 70);
      this.button1.TabIndex = 4;
      this.button1.Text = "Save";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Calibri", 12F);
      this.label1.Location = new System.Drawing.Point(48, 93);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 19);
      this.label1.TabIndex = 0;
      this.label1.Text = "hours";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Calibri", 12F);
      this.label2.Location = new System.Drawing.Point(173, 93);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 19);
      this.label2.TabIndex = 0;
      this.label2.Text = "minutes";
      // 
      // nextAlarm
      // 
      this.nextAlarm.AutoSize = true;
      this.nextAlarm.Location = new System.Drawing.Point(12, 88);
      this.nextAlarm.Name = "nextAlarm";
      this.nextAlarm.Size = new System.Drawing.Size(0, 13);
      this.nextAlarm.TabIndex = 7;
      // 
      // msmMain
      // 
      this.msmMain.Owner = this;
      // 
      // repeatingAlarm
      // 
      this.repeatingAlarm.AutoSize = true;
      this.repeatingAlarm.Location = new System.Drawing.Point(23, 125);
      this.repeatingAlarm.Name = "repeatingAlarm";
      this.repeatingAlarm.Size = new System.Drawing.Size(144, 15);
      this.repeatingAlarm.TabIndex = 3;
      this.repeatingAlarm.Text = "Is this alarm repeating?";
      this.repeatingAlarm.UseVisualStyleBackColor = true;
      this.repeatingAlarm.CheckedChanged += new System.EventHandler(this.repeatingAlarm_CheckedChanged);
      // 
      // minComBox
      // 
      this.minComBox.FormattingEnabled = true;
      this.minComBox.ItemHeight = 23;
      this.minComBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
      this.minComBox.Location = new System.Drawing.Point(143, 61);
      this.minComBox.Name = "minComBox";
      this.minComBox.Size = new System.Drawing.Size(114, 29);
      this.minComBox.TabIndex = 2;
      this.minComBox.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
      // 
      // HourComBox
      // 
      this.HourComBox.FormattingEnabled = true;
      this.HourComBox.ItemHeight = 23;
      this.HourComBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
      this.HourComBox.Location = new System.Drawing.Point(23, 61);
      this.HourComBox.Name = "HourComBox";
      this.HourComBox.Size = new System.Drawing.Size(114, 29);
      this.HourComBox.TabIndex = 1;
      this.HourComBox.SelectedIndexChanged += new System.EventHandler(this.HourComBox_SelectedIndexChanged);
      // 
      // metroLink1
      // 
      this.metroLink1.Location = new System.Drawing.Point(0, 0);
      this.metroLink1.Name = "metroLink1";
      this.metroLink1.TabIndex = 0;
      // 
      // sundayBox
      // 
      this.sundayBox.AutoSize = true;
      this.sundayBox.Location = new System.Drawing.Point(50, 165);
      this.sundayBox.Name = "sundayBox";
      this.sundayBox.Size = new System.Drawing.Size(46, 15);
      this.sundayBox.TabIndex = 11;
      this.sundayBox.Text = "Sun.";
      this.sundayBox.UseVisualStyleBackColor = true;
      // 
      // mondayBox
      // 
      this.mondayBox.AutoSize = true;
      this.mondayBox.Location = new System.Drawing.Point(100, 165);
      this.mondayBox.Name = "mondayBox";
      this.mondayBox.Size = new System.Drawing.Size(51, 15);
      this.mondayBox.TabIndex = 12;
      this.mondayBox.Text = "Mon.";
      this.mondayBox.UseVisualStyleBackColor = true;
      // 
      // tuesdayBox
      // 
      this.tuesdayBox.AutoSize = true;
      this.tuesdayBox.Location = new System.Drawing.Point(150, 165);
      this.tuesdayBox.Name = "tuesdayBox";
      this.tuesdayBox.Size = new System.Drawing.Size(46, 15);
      this.tuesdayBox.TabIndex = 13;
      this.tuesdayBox.Text = "Tue.";
      this.tuesdayBox.UseVisualStyleBackColor = true;
      // 
      // wednesdayBox
      // 
      this.wednesdayBox.AutoSize = true;
      this.wednesdayBox.Location = new System.Drawing.Point(200, 165);
      this.wednesdayBox.Name = "wednesdayBox";
      this.wednesdayBox.Size = new System.Drawing.Size(50, 15);
      this.wednesdayBox.TabIndex = 14;
      this.wednesdayBox.Text = "Wed.";
      this.wednesdayBox.UseVisualStyleBackColor = true;
      // 
      // saturdayBox
      // 
      this.saturdayBox.AutoSize = true;
      this.saturdayBox.Location = new System.Drawing.Point(350, 165);
      this.saturdayBox.Name = "saturdayBox";
      this.saturdayBox.Size = new System.Drawing.Size(39, 15);
      this.saturdayBox.TabIndex = 17;
      this.saturdayBox.Text = "Sat";
      this.saturdayBox.UseVisualStyleBackColor = true;
      // 
      // fridayBox
      // 
      this.fridayBox.AutoSize = true;
      this.fridayBox.Location = new System.Drawing.Point(300, 165);
      this.fridayBox.Name = "fridayBox";
      this.fridayBox.Size = new System.Drawing.Size(39, 15);
      this.fridayBox.TabIndex = 16;
      this.fridayBox.Text = "Fri.";
      this.fridayBox.UseVisualStyleBackColor = true;
      this.fridayBox.CheckedChanged += new System.EventHandler(this.fridayBox_CheckedChanged);
      // 
      // thursdayBox
      // 
      this.thursdayBox.AutoSize = true;
      this.thursdayBox.Location = new System.Drawing.Point(250, 165);
      this.thursdayBox.Name = "thursdayBox";
      this.thursdayBox.Size = new System.Drawing.Size(47, 15);
      this.thursdayBox.TabIndex = 15;
      this.thursdayBox.Text = "Thu.";
      this.thursdayBox.UseVisualStyleBackColor = true;
      // 
      // dayComBox
      // 
      this.dayComBox.FormattingEnabled = true;
      this.dayComBox.ItemHeight = 23;
      this.dayComBox.Items.AddRange(new object[] {
            "Mon",
            "Tus",
            "Wed",
            "Thu",
            "Fri",
            "Sat",
            "Sun"});
      this.dayComBox.Location = new System.Drawing.Point(263, 61);
      this.dayComBox.Name = "dayComBox";
      this.dayComBox.Size = new System.Drawing.Size(77, 29);
      this.dayComBox.TabIndex = 18;
      this.dayComBox.SelectedIndexChanged += new System.EventHandler(this.dayComBox_SelectedIndexChanged);
      // 
      // dayLabel
      // 
      this.dayLabel.AutoSize = true;
      this.dayLabel.Font = new System.Drawing.Font("Calibri", 12F);
      this.dayLabel.Location = new System.Drawing.Point(281, 93);
      this.dayLabel.Name = "dayLabel";
      this.dayLabel.Size = new System.Drawing.Size(32, 19);
      this.dayLabel.TabIndex = 19;
      this.dayLabel.Text = "day";
      // 
      // SetAlarm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(450, 150);
      this.ControlBox = false;
      this.Controls.Add(this.dayLabel);
      this.Controls.Add(this.dayComBox);
      this.Controls.Add(this.saturdayBox);
      this.Controls.Add(this.fridayBox);
      this.Controls.Add(this.thursdayBox);
      this.Controls.Add(this.wednesdayBox);
      this.Controls.Add(this.tuesdayBox);
      this.Controls.Add(this.mondayBox);
      this.Controls.Add(this.sundayBox);
      this.Controls.Add(this.HourComBox);
      this.Controls.Add(this.minComBox);
      this.Controls.Add(this.repeatingAlarm);
      this.Controls.Add(this.nextAlarm);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(450, 220);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(450, 150);
      this.Movable = false;
      this.Name = "SetAlarm";
      this.Text = "SpotiAlarm / Set";
      this.Load += new System.EventHandler(this.Alarm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label nextAlarm;
    private MetroFramework.Components.MetroStyleManager msmMain;
    private MetroFramework.Controls.MetroCheckBox repeatingAlarm;
    private MetroFramework.Controls.MetroComboBox minComBox;
    private MetroFramework.Controls.MetroComboBox HourComBox;
    private MetroFramework.Controls.MetroLink metroLink1;
    private MetroFramework.Controls.MetroCheckBox saturdayBox;
    private MetroFramework.Controls.MetroCheckBox fridayBox;
    private MetroFramework.Controls.MetroCheckBox thursdayBox;
    private MetroFramework.Controls.MetroCheckBox wednesdayBox;
    private MetroFramework.Controls.MetroCheckBox tuesdayBox;
    private MetroFramework.Controls.MetroCheckBox mondayBox;
    private MetroFramework.Controls.MetroCheckBox sundayBox;
    private System.Windows.Forms.Label dayLabel;
    private MetroFramework.Controls.MetroComboBox dayComBox;
    private System.ComponentModel.BackgroundWorker bgWorker;
  }
}