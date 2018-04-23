﻿namespace SpotiAlarm
{
  partial class SpotiAlarm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotiAlarm));
      this.timeDisplay = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.addAlarmBtn = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.msmMain = new MetroFramework.Components.MetroStyleManager(this.components);
      this.settingsBtn = new System.Windows.Forms.Button();
      this.closeBtn = new System.Windows.Forms.Button();
      this.editAlarmBtn = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).BeginInit();
      this.SuspendLayout();
      // 
      // timeDisplay
      // 
      this.timeDisplay.BackColor = System.Drawing.Color.Transparent;
      this.timeDisplay.Font = new System.Drawing.Font("Calibri", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timeDisplay.Location = new System.Drawing.Point(12, 64);
      this.timeDisplay.Name = "timeDisplay";
      this.timeDisplay.Size = new System.Drawing.Size(354, 86);
      this.timeDisplay.TabIndex = 0;
      this.timeDisplay.Text = "loading..";
      this.timeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.timeDisplay.Click += new System.EventHandler(this.label1_Click);
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // addAlarmBtn
      // 
      this.addAlarmBtn.BackColor = System.Drawing.Color.Transparent;
      this.addAlarmBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.addAlarmBtn.Location = new System.Drawing.Point(389, 75);
      this.addAlarmBtn.Name = "addAlarmBtn";
      this.addAlarmBtn.Size = new System.Drawing.Size(111, 43);
      this.addAlarmBtn.TabIndex = 2;
      this.addAlarmBtn.Text = "add alarm";
      this.addAlarmBtn.UseVisualStyleBackColor = false;
      this.addAlarmBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.addAlarmBtn_MouseUp);
      // 
      // msmMain
      // 
      this.msmMain.Owner = null;
      this.msmMain.Style = MetroFramework.MetroColorStyle.Green;
      this.msmMain.Theme = MetroFramework.MetroThemeStyle.Light;
      // 
      // settingsBtn
      // 
      this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
      this.settingsBtn.Location = new System.Drawing.Point(389, 157);
      this.settingsBtn.Name = "settingsBtn";
      this.settingsBtn.Size = new System.Drawing.Size(111, 43);
      this.settingsBtn.TabIndex = 3;
      this.settingsBtn.UseVisualStyleBackColor = true;
      this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
      // 
      // closeBtn
      // 
      this.closeBtn.Location = new System.Drawing.Point(455, 0);
      this.closeBtn.Name = "closeBtn";
      this.closeBtn.Size = new System.Drawing.Size(45, 23);
      this.closeBtn.TabIndex = 4;
      this.closeBtn.Text = "x";
      this.closeBtn.UseVisualStyleBackColor = true;
      this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
      // 
      // editAlarmBtn
      // 
      this.editAlarmBtn.BackColor = System.Drawing.Color.Transparent;
      this.editAlarmBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.editAlarmBtn.Location = new System.Drawing.Point(389, 116);
      this.editAlarmBtn.Name = "editAlarmBtn";
      this.editAlarmBtn.Size = new System.Drawing.Size(111, 43);
      this.editAlarmBtn.TabIndex = 5;
      this.editAlarmBtn.Text = "edit alarms";
      this.editAlarmBtn.UseVisualStyleBackColor = false;
      this.editAlarmBtn.Click += new System.EventHandler(this.button1_Click);
      // 
      // SpotiAlarm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(500, 200);
      this.Controls.Add(this.editAlarmBtn);
      this.Controls.Add(this.closeBtn);
      this.Controls.Add(this.settingsBtn);
      this.Controls.Add(this.addAlarmBtn);
      this.Controls.Add(this.timeDisplay);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(500, 200);
      this.MinimumSize = new System.Drawing.Size(500, 200);
      this.Name = "SpotiAlarm";
      this.Text = "SpotiAlarm";
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpotiAlarm_MouseDown);
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label timeDisplay;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button addAlarmBtn;
    private System.Windows.Forms.ToolTip toolTip1;
    private MetroFramework.Components.MetroStyleManager msmMain;
    private System.Windows.Forms.Button settingsBtn;
    private System.Windows.Forms.Button closeBtn;
    private System.Windows.Forms.Button editAlarmBtn;
  }
}

