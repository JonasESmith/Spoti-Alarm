namespace SpotiAlarm
{
  partial class settings
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
      this.saveBtn = new System.Windows.Forms.Button();
      this.changePathBtn = new System.Windows.Forms.Button();
      this.onStartupCheck = new MetroFramework.Controls.MetroCheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).BeginInit();
      this.SuspendLayout();
      // 
      // msmMain
      // 
      this.msmMain.Owner = this;
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(107, 132);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 0;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
      // 
      // changePathBtn
      // 
      this.changePathBtn.Location = new System.Drawing.Point(85, 70);
      this.changePathBtn.Name = "changePathBtn";
      this.changePathBtn.Size = new System.Drawing.Size(125, 25);
      this.changePathBtn.TabIndex = 1;
      this.changePathBtn.Text = "change spotify path";
      this.changePathBtn.UseVisualStyleBackColor = true;
      this.changePathBtn.Click += new System.EventHandler(this.changePathBtn_Click);
      // 
      // onStartupCheck
      // 
      this.onStartupCheck.AutoSize = true;
      this.onStartupCheck.Location = new System.Drawing.Point(61, 101);
      this.onStartupCheck.Name = "onStartupCheck";
      this.onStartupCheck.Size = new System.Drawing.Size(181, 15);
      this.onStartupCheck.TabIndex = 2;
      this.onStartupCheck.Text = "Start the program on startup? ";
      this.onStartupCheck.UseVisualStyleBackColor = true;
      this.onStartupCheck.CheckedChanged += new System.EventHandler(this.onStartupCheck_CheckedChanged);
      // 
      // settings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(300, 163);
      this.ControlBox = false;
      this.Controls.Add(this.onStartupCheck);
      this.Controls.Add(this.changePathBtn);
      this.Controls.Add(this.saveBtn);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "settings";
      this.Text = "SpotiAlarm - Settings";
      this.Load += new System.EventHandler(this.settings_Load);
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MetroFramework.Components.MetroStyleManager msmMain;
    private System.Windows.Forms.Button saveBtn;
    private System.Windows.Forms.Button changePathBtn;
    private MetroFramework.Controls.MetroCheckBox onStartupCheck;
  }
}