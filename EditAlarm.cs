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
    public  int                 hh;
    public  int                 mm;
    public  int                 ss;
    public  int                 repeat;
    public  string              reCheck;
    private static Alarm        alarm;
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
      this.StyleManager = msmMain;
      msmMain.Theme     = MetroFramework.MetroThemeStyle.Dark;
      msmMain.Style     = MetroFramework.MetroColorStyle.Green;

      alarmListTemp = (List<Alarm>)this.Tag;

      LoadDGV();

    }

    private void LoadDGV()
    {
      for(int i = 1; i <= alarmListTemp.Count; i++)
      {
        alarmDGV.Rows.Add();
        alarmDGV.Rows[i - 1].Cells[0].Value = alarmListTemp[i - 1].Name;
        alarmDGV.Rows[i - 1].Cells[1].Value = alarmListTemp[i - 1].AlarmTime;
      }
    }
  }
}
