namespace SpotiAlarm
{
  partial class EditAlarm
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
      this.msmMain = new MetroFramework.Components.MetroStyleManager(this.components);
      this.metroLink1 = new MetroFramework.Controls.MetroLink();
      this.bgWorker = new System.ComponentModel.BackgroundWorker();
      this.alarmFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.titlePanel = new System.Windows.Forms.Panel();
      this.editCloseBtn = new System.Windows.Forms.Button();
      this.noAlarmPanel = new System.Windows.Forms.Panel();
      this.noAlarmLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).BeginInit();
      this.alarmFlowLayoutPanel.SuspendLayout();
      this.titlePanel.SuspendLayout();
      this.noAlarmPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // msmMain
      // 
      this.msmMain.Owner = null;
      // 
      // metroLink1
      // 
      this.metroLink1.Location = new System.Drawing.Point(0, 0);
      this.metroLink1.Name = "metroLink1";
      this.metroLink1.TabIndex = 0;
      // 
      // alarmFlowLayoutPanel
      // 
      this.alarmFlowLayoutPanel.Controls.Add(this.noAlarmPanel);
      this.alarmFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.alarmFlowLayoutPanel.Location = new System.Drawing.Point(0, 25);
      this.alarmFlowLayoutPanel.Name = "alarmFlowLayoutPanel";
      this.alarmFlowLayoutPanel.Size = new System.Drawing.Size(535, 230);
      this.alarmFlowLayoutPanel.TabIndex = 1;
      this.alarmFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.alarmFlowLayoutPanel_Paint);
      this.alarmFlowLayoutPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.alarmFlowLayoutPanel_MouseDown);
      // 
      // titlePanel
      // 
      this.titlePanel.Controls.Add(this.editCloseBtn);
      this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.titlePanel.Location = new System.Drawing.Point(0, 0);
      this.titlePanel.Name = "titlePanel";
      this.titlePanel.Size = new System.Drawing.Size(535, 25);
      this.titlePanel.TabIndex = 2;
      this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
      // 
      // editCloseBtn
      // 
      this.editCloseBtn.Dock = System.Windows.Forms.DockStyle.Right;
      this.editCloseBtn.Location = new System.Drawing.Point(490, 0);
      this.editCloseBtn.Name = "editCloseBtn";
      this.editCloseBtn.Size = new System.Drawing.Size(45, 25);
      this.editCloseBtn.TabIndex = 0;
      this.editCloseBtn.Text = "x";
      this.editCloseBtn.UseVisualStyleBackColor = true;
      this.editCloseBtn.Click += new System.EventHandler(this.editCloseBtn_Click);
      // 
      // noAlarmPanel
      // 
      this.noAlarmPanel.Controls.Add(this.noAlarmLabel);
      this.noAlarmPanel.Location = new System.Drawing.Point(3, 3);
      this.noAlarmPanel.Name = "noAlarmPanel";
      this.noAlarmPanel.Size = new System.Drawing.Size(532, 215);
      this.noAlarmPanel.TabIndex = 0;
      // 
      // noAlarmLabel
      // 
      this.noAlarmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.noAlarmLabel.Location = new System.Drawing.Point(79, 65);
      this.noAlarmLabel.Name = "noAlarmLabel";
      this.noAlarmLabel.Size = new System.Drawing.Size(355, 68);
      this.noAlarmLabel.TabIndex = 0;
      this.noAlarmLabel.Text = "currently no alarms";
      this.noAlarmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // EditAlarm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(535, 255);
      this.ControlBox = false;
      this.Controls.Add(this.alarmFlowLayoutPanel);
      this.Controls.Add(this.titlePanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(450, 190);
      this.Name = "EditAlarm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SpotiAlarm / Set";
      this.Load += new System.EventHandler(this.EditAlarm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).EndInit();
      this.alarmFlowLayoutPanel.ResumeLayout(false);
      this.titlePanel.ResumeLayout(false);
      this.noAlarmPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private MetroFramework.Components.MetroStyleManager msmMain;
    private MetroFramework.Controls.MetroLink metroLink1;
    private System.ComponentModel.BackgroundWorker bgWorker;
    private System.Windows.Forms.FlowLayoutPanel alarmFlowLayoutPanel;
    private System.Windows.Forms.Panel titlePanel;
    private System.Windows.Forms.Button editCloseBtn;
    private System.Windows.Forms.Panel noAlarmPanel;
    private System.Windows.Forms.Label noAlarmLabel;
  }
}