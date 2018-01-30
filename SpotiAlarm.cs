// Programmer :  Jonas Smith
// program    :  SpotiAlarm
// Purpose    :  Start spotify to play the last playlist at a specific time. 
// Set startup:  https://stackoverflow.com/questions/674628/how-do-i-set-a-program-to-launch-at-startup

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpotiAlarm
{
  public partial class SpotiAlarm : MetroFramework.Forms.MetroForm
  {   
    // hour12 = army/regular  alarm = 0/1
    private int hour12 = 0, alarm = 0;

    // <Summary>
    // These are necessary for the Selection of the window. This is not super usefull or necessary as of now. 
    // </Summary>
    [DllImport("user32")] private static extern bool SetForegroundWindow(IntPtr hwnd);
    [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public int alarmCount;
    public string paths;
    public string fileName;
    private static List<Alarm> alarmList = new List<Alarm>();

    // path to Spotify.exe
    private string path;
    SetAlarm getUp = new SetAlarm();

    public SpotiAlarm()
    {
      InitializeComponent();
      ShowIcon = false;

      // loads correct theme from MetroFramework.
      StyleManager = msmMain;
      msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
      msmMain.Style = MetroFramework.MetroColorStyle.Green;

      // changes text colors for the dark theme above. 
      label1.ForeColor = Color.White;
      addAlarmBtn.ForeColor = Color.White;

      #region loadbutton styles 

      // Loading style for the add alarm button.
      addAlarmBtn.TabStop = false;
      addAlarmBtn.FlatStyle = FlatStyle.Flat;
      addAlarmBtn.FlatAppearance.BorderSize = 0;
      addAlarmBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
      addAlarmBtn.MouseEnter += OnMouseEnter;
      addAlarmBtn.MouseLeave += OnMouseLeave;

      settingsBtn.TabStop = false;
      settingsBtn.FlatStyle = FlatStyle.Flat;
      settingsBtn.FlatAppearance.BorderSize = 0;
      settingsBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
      #endregion
    }


    #region Onstartup failure

    public void GetExeLocation()
    {
      // for getting the location of exe file ( it can change when you change the location of exe)
      paths = System.Reflection.Assembly.GetEntryAssembly().Location;

      // for getting the name of exe file( it can change when you change the name of exe)
      fileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

      // start the exe autometically when computer is stared.
      StartExeWhenPcStartup(fileName, paths);
    }

    public void StartExeWhenPcStartup(string filename, string filepaths)
    {
      Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
      key.SetValue(filename, filepaths);
    }
    #endregion

    private void Form1_Load(object sender, EventArgs e)
    {
      LoadPath();
      LoadAssets();
      timer1.Start();
    }

    #region LoadAssets();

    private void LoadAssets()
    {
      alarm = 1;
      string tooltip = " ";
      string Alarms;

      if (Properties.Settings.Default.UserAlarms != "0")
      {
        Alarms = Properties.Settings.Default.UserAlarms;

        var words = Alarms.Split(',');

        alarmCount = Convert.ToInt32(words[0]);

        int j = 0;
        for(int i = 1; i <= alarmCount; i++)
        {
          j *= 5;
          alarmList.Add(new Alarm(words[1 + j], Convert.ToInt32(words[2 + j]), Convert.ToInt32(words[3 + j]),
                                                Convert.ToInt32(words[4 + j]), Convert.ToInt32(words[5 + j])));
          j = i;
        }

        NextAlarm();

        // Loading alarm from settings.
        // getUp.hh = Properties.Settings.Default.UserHour;
        // getUp.mm = Properties.Settings.Default.UserMinute;

        // tool tip for add alarm button/label that shows when the next alarm is. 
        // this is gross but is better than its own label.
        // tooltip = "Next alarm at " + Properties.Settings.Default.UserHour.ToString("D2") + ":"
        //                            + Properties.Settings.Default.UserMinute.ToString("D2");
      }
      else
      {
        tooltip = "There is currently no alarm.";
      }

      // set's the tooltip for the digital Clock
      this.toolTip1.SetToolTip(this.addAlarmBtn, tooltip);
      this.toolTip1.SetToolTip(this.label1, tooltip);
    }

    private void NextAlarm()
    {
      DateTime currentTime = DateTime.Now;
      uint currentTimeMs = (uint)currentTime.TimeOfDay.TotalMilliseconds;

      // num of miliseconds in a day
      uint msToNextAlarm = 86400000;

      for (int i = 1; i <= alarmList.Count; i++)
      {
        uint totalMs = (uint)alarmList[i - 1].AlarmTime.TotalMilliseconds;

        if (totalMs > currentTimeMs)
        {
          if((totalMs - currentTimeMs) < msToNextAlarm)
          {
            msToNextAlarm = (totalMs - currentTimeMs);

            getUp.hh = alarmList[i - 1].Hour;
            getUp.mm = alarmList[i - 1].Minute;
          }
        }
      }
    }
    #endregion

    #region Spotify path check & Load

    // This checks the userpath for Spotify.exe should work if user is hosted on local server.
    private void LoadPath()
    {
      path = Properties.Settings.Default.UserPath;
      if (path == "" || path == "New Value")
      {
        try
        {
          string userName = Environment.UserName;
          path = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Spotify\\Spotify.exe";
          if (!File.Exists(path))
          {
            userName = Environment.UserName + "." + Environment.UserDomainName;
            path = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Spotify\\Spotify.exe";
          }
        }
        catch
        {
          MessageBox.Show("Please select the Spotify.exe location");

          // this is finding the "usual" path for spotify however it may not always work
          string userName = Environment.UserName;
          path = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Spotify";


          using (var fbd = new OpenFileDialog())
          {
            // open file dialog at the spotify location
            fbd.InitialDirectory = path;
            fbd.Filter = "(*.exe)|*.exe;";
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
            { path = fbd.FileName; }
          }
        }
        Properties.Settings.Default.UserPath = path;
        Properties.Settings.Default.Save();
      }
    }
    #endregion

    #region Timer & countDown


    private void timer1_Tick(object sender, EventArgs e)
    {
      if (hour12 == 0)
      {
        label1.Text = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");
      }
      else
      {
        label1.Text = DateTime.Now.ToString("HH:mm:ss");
      }
      if ((alarm == 1) && (CheckDay() == true))
      {
        int Tempint = Convert.ToInt16(DateTime.Now.ToString("HH"));

        if (Convert.ToInt16(DateTime.Now.ToString("HH")) == getUp.hh &&
            Convert.ToInt32(DateTime.Now.ToString("mm")) == getUp.mm &&
            Convert.ToInt32(DateTime.Now.ToString("ss")) == getUp.ss)
        {
          ProcessStartInfo start = new ProcessStartInfo();
          var proc = Process.GetProcessesByName("Spotify").FirstOrDefault();
          path = Properties.Settings.Default.UserPath;
          start.FileName = path;
          if (proc == null)
          {
            Process.Start(start);
            // this is to give time for spotify to patch/launch
            System.Threading.Thread.Sleep(15000);
          }
          else
          {
            // this brings the window into "Focus"
            SelectWindow("Spotify");
            // this gives enough time for spotify to be brought to focus
            System.Threading.Thread.Sleep(5000);
          }
          SendKeys.Send("{^} {Right}");
        }

        // Loads next alarm into the alarm slot
        NextAlarm();
      }
    }

    private const int SW_SHOWMAXIMIZED = 3;
    private void SelectWindow(string winApp)
    {
      System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(winApp);
      foreach (System.Diagnostics.Process proc in procs)
      {
        ShowWindow(proc.MainWindowHandle, SW_SHOWMAXIMIZED);
        SetForegroundWindow(proc.MainWindowHandle);
      }
    }

    private bool CheckDay()
    {
      bool checkedSum = false;
      string day;

      // what day is it?
      day = DateTime.Now.DayOfWeek.ToString();
      switch (day)
      {
        case "Sunday":
          day = "0";
          break;
        case "Monday":
          day = "1";
          break;
        case "Tuesday":
          day = "2";
          break;
        case "Wednesday":
          day = "3";
          break;
        case "Thursday":
          day = "4";
          break;
        case "Friday":
          day = "5";
          break;
        case "Saturday":
          day = "6";
          break;
      }

      // is that day set to repeat? 
      if (Properties.Settings.Default.UserDays.Contains(day))
      {
        checkedSum = true;
      }

      return checkedSum;
    }

    // Timer until the next alarm. 
    private void UpdateNext()
    {
      double alarmTime = 0;
      string current = DateTime.Now.ToString("HH:mm");
      if (current.Contains(':'))
      { current = current.Replace(":", "."); }
      alarmTime = Convert.ToDouble(getUp.hh + "." + getUp.mm);
      double currentTime = Convert.ToDouble(current);
    }
    #endregion

    #region Button color changes
    private void OnMouseEnter(object sender, EventArgs e)
    {
      addAlarmBtn.BackColor = Color.LightGreen; // or Color.Red or whatever you want
    }
    private void OnMouseLeave(object sender, EventArgs e)
    {
      addAlarmBtn.BackColor = Color.FromArgb(0, 255, 255, 255);
    }
    #endregion

    #region Misc.

    private void button2_Click(object sender, EventArgs e)
    {
      SetAlarm newAlarm = new SetAlarm();
      Alarm    alarm    = new Alarm();
      newAlarm.Tag      = alarm;
      newAlarm.Text     = "add Alarm";
      //this.Hide();

      if(newAlarm.ShowDialog(null) == DialogResult.OK)
      {
        alarmList.Add(new Alarm(alarm.Name, alarm.Hour, alarm.Minute, 0, alarm.Days));
        alarmCount++;
        UpdateUserAlarm();
      }

      NextAlarm();
    }

    private void UpdateUserAlarm()
    {
      string tempUserAlarm;
      string comma = ",";
      int i = 0;
      tempUserAlarm = alarmCount + comma;

      foreach(Alarm alarm in alarmList)
      {
        tempUserAlarm += alarmList[i].Name + comma   + alarmList[i].Hour + comma +
                         alarmList[i].Minute + comma + alarmList[i].Second + comma +
                         alarmList[i].Days + comma; i++;
      }

      Properties.Settings.Default.UserDays = tempUserAlarm;
      Properties.Settings.Default.Save();

      this.toolTip1.SetToolTip(this.label1, tempUserAlarm);
    }


    private void label2_Click(object sender, EventArgs e)
    { }

    private void label1_Click(object sender, EventArgs e)
    {
      if (hour12 == 0) hour12 = 1;
      else hour12 = 0;
    }

    private void label3_Click(object sender, EventArgs e)
    { }

    private void Form_FormClosed(object sender, FormClosedEventArgs e)
    { }

    private void nextAlarm_Click(object sender, EventArgs e)
    { }

    private void toolTip1_Popup(object sender, PopupEventArgs e)
    { }

    private void settingsBtn_Click(object sender, EventArgs e)
    {
      Settings settingsPage = new Settings();
      settingsPage.Show();
      this.Hide();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    { Application.Exit(); }
    #endregion
  }
}