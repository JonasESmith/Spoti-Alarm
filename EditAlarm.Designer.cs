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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.msmMain = new MetroFramework.Components.MetroStyleManager(this.components);
      this.metroLink1 = new MetroFramework.Controls.MetroLink();
      this.bgWorker = new System.ComponentModel.BackgroundWorker();
      this.alarmDGV = new System.Windows.Forms.DataGridView();
      this.alarmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.alarmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.alarmDGV)).BeginInit();
      this.SuspendLayout();
      // 
      // msmMain
      // 
      this.msmMain.Owner = this;
      // 
      // metroLink1
      // 
      this.metroLink1.Location = new System.Drawing.Point(0, 0);
      this.metroLink1.Name = "metroLink1";
      this.metroLink1.TabIndex = 0;
      // 
      // alarmDGV
      // 
      this.alarmDGV.AllowUserToAddRows = false;
      this.alarmDGV.AllowUserToDeleteRows = false;
      this.alarmDGV.AllowUserToResizeColumns = false;
      this.alarmDGV.AllowUserToResizeRows = false;
      this.alarmDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Lime;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.alarmDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.alarmDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.alarmDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alarmName,
            this.alarmTime});
      this.alarmDGV.Dock = System.Windows.Forms.DockStyle.Fill;
      this.alarmDGV.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.alarmDGV.Location = new System.Drawing.Point(20, 60);
      this.alarmDGV.Name = "alarmDGV";
      this.alarmDGV.ReadOnly = true;
      this.alarmDGV.RowHeadersVisible = false;
      this.alarmDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.alarmDGV.Size = new System.Drawing.Size(410, 270);
      this.alarmDGV.TabIndex = 0;
      // 
      // alarmName
      // 
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Lime;
      this.alarmName.DefaultCellStyle = dataGridViewCellStyle2;
      this.alarmName.HeaderText = "Alarm Name";
      this.alarmName.Name = "alarmName";
      this.alarmName.ReadOnly = true;
      // 
      // alarmTime
      // 
      dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      dataGridViewCellStyle3.ForeColor = System.Drawing.Color.ForestGreen;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Lime;
      this.alarmTime.DefaultCellStyle = dataGridViewCellStyle3;
      this.alarmTime.HeaderText = "Alarm Time";
      this.alarmTime.Name = "alarmTime";
      this.alarmTime.ReadOnly = true;
      this.alarmTime.Width = 50;
      // 
      // EditAlarm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(450, 350);
      this.Controls.Add(this.alarmDGV);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(450, 150);
      this.Movable = false;
      this.Name = "EditAlarm";
      this.Text = "SpotiAlarm / Set";
      this.Load += new System.EventHandler(this.EditAlarm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.msmMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.alarmDGV)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private MetroFramework.Components.MetroStyleManager msmMain;
    private MetroFramework.Controls.MetroLink metroLink1;
    private System.ComponentModel.BackgroundWorker bgWorker;
    private System.Windows.Forms.DataGridView alarmDGV;
    private System.Windows.Forms.DataGridViewTextBoxColumn alarmName;
    private System.Windows.Forms.DataGridViewTextBoxColumn alarmTime;
  }
}