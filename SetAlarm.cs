// Programmer :  Jonas Smith
// program    :  SpotiAlarm

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpotiAlarm
{
  public partial class SetAlarm : MetroFramework.Forms.MetroForm
  {
    public  int          hh;
    public  int          mm;
    public  int          ss;
    public  int          repeat;
    public  string       reCheck;
    private static Alarm alarm;

    public SetAlarm()
    {
      InitializeComponent();
    }

    private void Alarm_Load(object sender, EventArgs e)
    {
      #region Loading styles to all assets
      ShowIcon = false;

      // loads "dark" style to match spotify 
      this.StyleManager = msmMain;
      msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
      msmMain.Style = MetroFramework.MetroColorStyle.Green;

      // hours and minutes label change 
      label1.ForeColor = Color.White;
      label2.ForeColor = Color.White;
      dayLabel.ForeColor = Color.White;

      // adding flat appearance to "save" button & change path btn.
      //SaveBtn
      button1.ForeColor = Color.White;
      button1.TabStop = false;
      button1.FlatStyle = FlatStyle.Flat;
      button1.FlatAppearance.BorderSize = 0;
      button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
      // adds the green hoover effect to the buttons
      button1.MouseEnter += OnMouseEnterSave;
      button1.MouseLeave += OnMouseLeaveSave;

      nameTxtBx.ForeColor = Color.Gray;

      // changeing the number of items shown on comboxes
      HourComBox.DropDownHeight = HourComBox.Font.Height * 5;
      minComBox.DropDownHeight = HourComBox.Font.Height * 10;
      #endregion


      int hours = Convert.ToInt32(DateTime.Now.ToString("HH"));
      HourComBox.Text = hours.ToString("D2");
      int minutes = Convert.ToInt32(DateTime.Now.ToString("mm")); minutes++;
      if (minutes == 00)
        minComBox.Text = "00";
      else
        minComBox.Text = minutes.ToString("D2");
    }

    #region Save-Button code

    // <summary>
    //    Save button 
    // </summary>

    private void button1_Click(object sender, EventArgs e)
    {
      // <summary>
      //    I will be updating the eniter program to better use an Alarm object
      //      So to better utilize multiple alarms, and editing capabilities. 
      // </summary>

      alarm = (Alarm)this.Tag;

      if (nameTxtBx.Text != "Alarm Name")
      {
        alarm.Name = nameTxtBx.Text;
      }
      else
      {
        alarm.Name = "Basic-Alarm";
      }
      alarm.Hour    = Convert.ToInt16(HourComBox.GetItemText(this.HourComBox.SelectedItem));
      alarm.Minute  = Convert.ToInt16(minComBox.GetItemText(this.minComBox.SelectedItem));

      // Days to repeat the alarm 
      // this seems Primitive... I can do better
      if (repeat == 1)
      {
        #region load days that alarm will repeat
        reCheck = "-";
        if (sundayBox.Checked)
          reCheck += 0;
        else
          reCheck += 9;

        if (mondayBox.Checked)
          reCheck += 1;
        else
          reCheck += 9;

        if (tuesdayBox.Checked)
          reCheck += 2;
        else
          reCheck += 9;

        if (wednesdayBox.Checked)
          reCheck += 3;
        else
          reCheck += 9;

        if (thursdayBox.Checked)
          reCheck += 4;
        else
          reCheck += 9;

        if (fridayBox.Checked)
          reCheck += 5;
        else
          reCheck += 9;

        if (saturdayBox.Checked)
          reCheck += 6;
        else
          reCheck += 9;

        #endregion
      }
      else
      {
        string day = DateTime.Now.DayOfWeek.ToString();
        #region switch select current day

        switch (day)
        {
          case "Sunday":
            reCheck = "0";
            break;
          case "Monday":
            reCheck = "1";
            break;
          case "Tuesday":
            reCheck = "2";
            break;
          case "Wednesday":
            reCheck = "3";
            break;
          case "Thursday":
            reCheck = "4";
            break;
          case "Friday":
            reCheck = "5";
            break;
          case "Saturday":
            reCheck = "6";
            break;
        }
        #endregion
      }
      alarm.Days = Convert.ToInt32(reCheck);

      DialogResult = DialogResult.OK;
    }
    // on mouse hoover
    private void OnMouseEnterSave(object sender, EventArgs e)
    {
      button1.BackColor = Color.LightGreen;
    }
    private void OnMouseLeaveSave(object sender, EventArgs e)
    {
      button1.BackColor = Color.FromArgb(0, 255, 255, 255);
    }
    #endregion

    #region repeat checkbox
    // checkbox code 
    private void repeatingAlarm_CheckedChanged(object sender, EventArgs e)
    {
      //https://stackoverflow.com/questions/15008871/how-to-create-many-labels-and-textboxes-dynamically-depending-on-the-value-of-an
      if (repeatingAlarm.Checked)
      {
        this.Height = 220;
        repeat = 1;
        dayComBox.Enabled = false;
        dayLabel.ForeColor = Color.Gray;
      }
      else if (!repeatingAlarm.Checked)
      {
        this.Size = new Size(375, 190);
        repeat = 0;
        dayComBox.Enabled = true;
        dayLabel.ForeColor = Color.White;
      }
    }

    #endregion

    #region "Blank" methods 


    private void fridayBox_CheckedChanged(object sender, EventArgs e)
    { }
    private void HourComBox_SelectedIndexChanged(object sender, EventArgs e)
    { }
    private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    { }
    private void label1_Click(object sender, EventArgs e)
    { }
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    { }
    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
    { }

    #endregion

    #region dayComboBox 

    private void dayComBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (dayComBox.GetItemText(this.dayComBox.SelectedItem))
      {
        case "Sun":
          reCheck = "0";
          break;
        case "Mon":
          reCheck = "1";
          break;
        case "Tus":
          reCheck = "2";
          break;
        case "Wed":
          reCheck = "3";
          break;
        case "Thu":
          reCheck = "4";
          break;
        case "Fri":
          reCheck = "5";
          break;
        case "Sat":
          reCheck = "6";
          break;

      }
      Properties.Settings.Default.UserDays = reCheck;

    }
    #endregion
  }
}
