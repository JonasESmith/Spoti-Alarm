namespace SpotiAlarm
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
      this.label1 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.button2 = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.msmMain = new MetroFramework.Components.MetroStyleManager(this.components);
      this.settingsBtn = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(0, 54);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(302, 61);
      this.label1.TabIndex = 0;
      this.label1.Text = "loading..";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.Transparent;
      this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(360, 42);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(70, 70);
      this.button2.TabIndex = 2;
      this.button2.Text = "add alarm";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // toolTip1
      // 
      this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
      // 
      // msmMain
      // 
      this.msmMain.Owner = this;
      this.msmMain.Style = MetroFramework.MetroColorStyle.Green;
      this.msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
      // 
      // settingsBtn
      // 
      this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
      this.settingsBtn.Location = new System.Drawing.Point(0, 113);
      this.settingsBtn.Name = "settingsBtn";
      this.settingsBtn.Size = new System.Drawing.Size(40, 40);
      this.settingsBtn.TabIndex = 3;
      this.settingsBtn.UseVisualStyleBackColor = true;
      this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
      // 
      // SpotiAlarm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(450, 150);
      this.Controls.Add(this.settingsBtn);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(450, 150);
      this.MinimumSize = new System.Drawing.Size(400, 150);
      this.Name = "SpotiAlarm";
      this.Text = "SpotiAlarm";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.ToolTip toolTip1;
    private MetroFramework.Components.MetroStyleManager msmMain;
    private System.Windows.Forms.Button settingsBtn;
  }
}

