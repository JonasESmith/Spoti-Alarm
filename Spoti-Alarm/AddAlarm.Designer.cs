﻿namespace SpotiAlarm
{
  partial class AddAlarm
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
      this.closeBtn = new System.Windows.Forms.Button();
      this.alarmNameLabel = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.alarmTimeLabel = new System.Windows.Forms.Label();
      this.hourComboBox = new System.Windows.Forms.ComboBox();
      this.minComboBox = new System.Windows.Forms.ComboBox();
      this.timePickComboBox = new System.Windows.Forms.ComboBox();
      this.titleBarPanel = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.titleBarPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // closeBtn
      // 
      this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
      this.closeBtn.Location = new System.Drawing.Point(421, 0);
      this.closeBtn.Name = "closeBtn";
      this.closeBtn.Size = new System.Drawing.Size(45, 25);
      this.closeBtn.TabIndex = 0;
      this.closeBtn.Text = "x";
      this.closeBtn.UseVisualStyleBackColor = true;
      // 
      // alarmNameLabel
      // 
      this.alarmNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.alarmNameLabel.Location = new System.Drawing.Point(30, 49);
      this.alarmNameLabel.Name = "alarmNameLabel";
      this.alarmNameLabel.Size = new System.Drawing.Size(104, 26);
      this.alarmNameLabel.TabIndex = 1;
      this.alarmNameLabel.Text = "alarm name";
      this.alarmNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textBox1
      // 
      this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.Location = new System.Drawing.Point(140, 49);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(237, 26);
      this.textBox1.TabIndex = 2;
      // 
      // alarmTimeLabel
      // 
      this.alarmTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.alarmTimeLabel.Location = new System.Drawing.Point(34, 92);
      this.alarmTimeLabel.Name = "alarmTimeLabel";
      this.alarmTimeLabel.Size = new System.Drawing.Size(104, 26);
      this.alarmTimeLabel.TabIndex = 3;
      this.alarmTimeLabel.Text = "alarm time";
      this.alarmTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // hourComboBox
      // 
      this.hourComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.hourComboBox.FormattingEnabled = true;
      this.hourComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
      this.hourComboBox.Location = new System.Drawing.Point(140, 92);
      this.hourComboBox.Name = "hourComboBox";
      this.hourComboBox.Size = new System.Drawing.Size(71, 28);
      this.hourComboBox.TabIndex = 5;
      this.hourComboBox.Text = "   hour";
      // 
      // minComboBox
      // 
      this.minComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.minComboBox.FormattingEnabled = true;
      this.minComboBox.Location = new System.Drawing.Point(217, 92);
      this.minComboBox.Name = "minComboBox";
      this.minComboBox.Size = new System.Drawing.Size(71, 28);
      this.minComboBox.TabIndex = 6;
      this.minComboBox.Text = "   min";
      // 
      // timePickComboBox
      // 
      this.timePickComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timePickComboBox.FormattingEnabled = true;
      this.timePickComboBox.Items.AddRange(new object[] {
            "am",
            "pm"});
      this.timePickComboBox.Location = new System.Drawing.Point(306, 92);
      this.timePickComboBox.Name = "timePickComboBox";
      this.timePickComboBox.Size = new System.Drawing.Size(71, 28);
      this.timePickComboBox.TabIndex = 7;
      this.timePickComboBox.Text = "am/pm";
      // 
      // titleBarPanel
      // 
      this.titleBarPanel.Controls.Add(this.closeBtn);
      this.titleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.titleBarPanel.Location = new System.Drawing.Point(0, 0);
      this.titleBarPanel.Name = "titleBarPanel";
      this.titleBarPanel.Size = new System.Drawing.Size(466, 25);
      this.titleBarPanel.TabIndex = 8;
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(38, 156);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(373, 130);
      this.panel1.TabIndex = 9;
      // 
      // splitter1
      // 
      this.splitter1.Location = new System.Drawing.Point(0, 25);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 315);
      this.splitter1.TabIndex = 10;
      this.splitter1.TabStop = false;
      // 
      // comboBox1
      // 
      this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(140, 126);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 21);
      this.comboBox1.TabIndex = 0;
      // 
      // AddAlarm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(466, 340);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.titleBarPanel);
      this.Controls.Add(this.timePickComboBox);
      this.Controls.Add(this.minComboBox);
      this.Controls.Add(this.hourComboBox);
      this.Controls.Add(this.alarmTimeLabel);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.alarmNameLabel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "AddAlarm";
      this.Text = "AddAlarm";
      this.titleBarPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button closeBtn;
    private System.Windows.Forms.Label alarmNameLabel;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label alarmTimeLabel;
    private System.Windows.Forms.ComboBox hourComboBox;
    private System.Windows.Forms.ComboBox minComboBox;
    private System.Windows.Forms.ComboBox timePickComboBox;
    private System.Windows.Forms.Panel titleBarPanel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.ComboBox comboBox1;
  }
}