// Programmer :  Jonas Smith
// program    :  SpotiAlarm

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpotiAlarm
{
  public partial class EditAlarm : MetroFramework.Forms.MetroForm
  {
    public  int                hh;
    public  int                mm;
    public  int                ss;
    public  int                repeat;
    public  string             reCheck;
    private static Alarm       alarm;
    private static List<Alarm> alarmListTemp;

    public EditAlarm()
    {
      InitializeComponent();
    }

    private void EditAlarm_Load(object sender, EventArgs e)
    {
      // <Summary>
      //    loads "dark" style to match spotify 
      // </Summary>
      #region MetroTheme
      this.StyleManager = msmMain;
      msmMain.Theme     = MetroFramework.MetroThemeStyle.Dark;
      msmMain.Style     = MetroFramework.MetroColorStyle.Green;
      #endregion

      alarmListTemp = (List<Alarm>)this.Tag;

      LoadDGV();
    }

    private void LoadDGV()
    {
      alarmDGV.EnableHeadersVisualStyles = false;
      alarmDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
      alarmDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      alarmDGV.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
      alarmDGV.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);

      for (int i = 1; i <= alarmListTemp.Count; i++)
      {
        alarmDGV.Rows.Add();
        alarmDGV.Rows[i - 1].Cells[0].Value = alarmListTemp[i - 1].Name;
        alarmDGV.Rows[i - 1].Cells[1].Value = alarmListTemp[i - 1].AlarmTime;
      }
    }
  }
}
