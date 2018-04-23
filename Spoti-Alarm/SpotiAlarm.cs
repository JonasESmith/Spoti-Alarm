// <Summary>
// Programmer :  Jonas Smith
// program    :  SpotiAlarm
// Purpose    :  Start spotify to play the last playlist at a specific time. 
// Set startup:  https://stackoverflow.com/questions/674628/how-do-i-set-a-program-to-launch-at-startup
// </Summary>

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SpotifyAPI;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using System.Threading;

namespace SpotiAlarm
{

  public partial class SpotiAlarm : MetroFramework.Forms.MetroForm
  {
  private SpotifyLocalAPIConfig _config;
  private SpotifyLocalAPI _spotify;


    // <Summary>
    //    hour12 = 24/12       
    //    alarm = 0/1
    // </Summary>
    private int hour12 = 0, alarm = 0;

    // <Summary>
    //    These are necessary for the Selection of the window. 
    //    These function to move the spotify application to the front
    //    so that the keypress will occur on the application instead
    //    of any other window that may be selected. 
    // </Summary>
    [DllImport("user32")]     private static extern bool SetForegroundWindow(IntPtr hwnd);
    [DllImport("user32.dll")] static extern bool         ShowWindow(IntPtr hWnd, int nCmdShow);

    public bool                spotifyRunning = false;
    public int                 alarmCount;
    public string              paths;
    public string              fileName;
    private static List<Alarm> alarmList = new List<Alarm>();
    private static Alarm       mainAlarm = new Alarm();

    private string path;


    public SpotiAlarm()
    {
      InitializeComponent();

      ///<summary>
      /// Authorizes the spotify application for use. 
      /// </summary>
      AuthSpotify();

      /// <summary>
      ///   Loads path to the location in which spotify is installed.
      /// </summary>
      LoadPath();

      /// <summary>
      ///   Loads all assets for the alarm system. Like alarms that 
      ///   are stored in local user settings for the applicaiton. 
      /// </summary>
      LoadAssets();

      /// <summary>
      ///  Starts the timer that is used for all time keeping for the 
      ///  alarm system/play system. 
      /// </summary>
      timer1.Start();

      /// <summary> 
      /// This is used to show the correct icon for spoti-alarm.
      /// </summary>
      ShowIcon = false;

      #region styles 

      /// <summary>
      /// loads correct theme from MetroFramework.
      /// <summary>
      StyleManager  = msmMain;
      msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
      msmMain.Style = MetroFramework.MetroColorStyle.Green;

      /// <Summary>
      ///    changes text colors for the dark theme above. 
      ///    Note: label1 is a terrible name... but I made this application my
      ///      very first week of programming one and want to keep it for now
      ///      as a reminder. :)
      /// </Summary>
      timeDisplay.ForeColor      = Color.White;
      addAlarmBtn.ForeColor = Color.White;

      /// <Summary>
      ///    Loading style for the add alarm button.
      /// </Summary>
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
      // <Summary>
      //    For getting the location of exe file ( it can change when you change the location of exe)
      // </Summary>
      paths = System.Reflection.Assembly.GetEntryAssembly().Location;


      // <Summary>
      //    For getting the name of exe file( it can change when you change the name of exe)
      // </Summary>
      fileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

      // <Summary>
      //     start the exe autometically when computer is stared.
      // </Summary>
      StartExeWhenPcStartup(fileName, paths);
    }

    #endregion

    /// <summary>
    /// Creates a start up registry to start the application on startup. 
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="filepaths"></param>
    public void StartExeWhenPcStartup(string filename, string filepaths)
    {
      Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
      key.SetValue(filename, filepaths);
    }

    #region Spotify Authentication and connection
    /// <summary>
    /// Used to authenticate and initialize the spotify application
    /// on startup. 
    /// </summary>
    public void AuthSpotify()
    {
      _config = new SpotifyLocalAPIConfig
      { ProxyConfig = new ProxyConfig() };

      _spotify = new SpotifyLocalAPI(_config);
    }

    /// <summary>
    /// Used to connect to the spotify local application for use, with 
    /// the alarm clock. 
    /// </summary>
    public void Connect()
    {
      if (!SpotifyLocalAPI.IsSpotifyRunning())
      {
        spotifyRunning = true;
        ProcessStartInfo startSpotify = new ProcessStartInfo();
        path = Properties.Settings.Default.UserPath;
        startSpotify.FileName = path;
        Process.Start(startSpotify);
        return;
      }

      bool successful = _spotify.Connect();
      if (successful)
      {
        _spotify.ListenForEvents = true;
      }
      else
      {
        DialogResult res = MessageBox.Show(@"Couldn't connect to the spotify client. Retry?", @"Spotify", MessageBoxButtons.YesNo);
        if (res == DialogResult.Yes)
          Connect();
      }
    }
    #endregion

    #region LoadAssets();

    /// <summary>
    /// Loads all "assets" for the application. This can include themes/alarms
    /// </summary>
    private void LoadAssets()
    {
      // <Summary>
      //    alarm = 1; Is used for a conditional check
      //    to test if the alarm time is coming soon. 
      // </Summary>
      alarm = 1;
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
                                                Convert.ToInt32(words[4 + j]), words[5 + j]));
          j = i;
        }
        NextAlarm();
      }
    }

    private void SortAlarm()
    {
      alarmList.Sort((x, y) => x.AlarmTime.CompareTo(y.AlarmTime));
      alarmList.Reverse();
    }

    private void NextAlarm()
    {
      alarm = 1; 
      string   tooltip       = "There is currently no alarm.";
      DateTime currentTime   = DateTime.Now;
      uint     currentTimeMs = (uint)currentTime.TimeOfDay.TotalMilliseconds;

      // <Summary>
      //     num of miliseconds in a day
      // </Summary>
      uint     msToNextAlarm = 86400000;

      SortAlarm();

      for (int i = 1; i <= alarmList.Count; i++)
      {
        // <Summary>
        //     Num of miliseconds for the current alarm in AlarmList
        // </Summary>
        uint totalAlarmMs = (uint)alarmList[i - 1].AlarmTime.TotalMilliseconds;


        if (totalAlarmMs > currentTimeMs)
        {
          if((totalAlarmMs - currentTimeMs) < msToNextAlarm)
          {
            msToNextAlarm = (totalAlarmMs - currentTimeMs);

            mainAlarm.Hour = alarmList[i - 1].Hour;
            mainAlarm.Minute = alarmList[i - 1].Minute;
            mainAlarm.Days = alarmList[i - 1].Days;

            tooltip = "Next alarm at " + mainAlarm.Hour + ":" + mainAlarm.Minute;
          }
        }
        else if (totalAlarmMs < currentTimeMs && msToNextAlarm <= 86400000)
        {
          //msToNextAlarm +=
          // I can use this for finding the time until the next alarm. 
        }
      }

      // <Summary>
      //    Sets the tooltip for the digital Clock 
      // </Summary>
      this.toolTip1.SetToolTip(this.addAlarmBtn, "Right click to edit Alarms");
      this.toolTip1.SetToolTip(this.timeDisplay, tooltip);
    }
    #endregion

    #region Spotify path check & Load

    /// <Summary>
    ///     This checks the userpath for Spotify.exe should
    ///     work if user is hosted on local server.
    /// </Summary>
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

          // <Summary>
          //     this is finding the "usual" path for spotify however it may not always work
          // </Summary>
          string userName = Environment.UserName;
          path = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Spotify";


          using (var fbd = new OpenFileDialog())
          {
            // <Summary>
            //     Open file dialog at the spotify location
            // </Summary>
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
      int currentHour, currentMint, currentScnt;

      /// <summary>
      /// Updates the time on the UI for ever second that passes. 
      /// </summary>
      if (hour12 == 0)
      {
        timeDisplay.Text = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");
      }
      else
      {
        timeDisplay.Text = DateTime.Now.ToString("HH:mm:ss");
      }

      /// <summary>
      /// If an alarm will be occuring today then check for times. otherwise do not. 
      /// </summary>
      if ((alarm == 1) && (CheckDay() == true))
      {
        currentHour = Convert.ToInt16(DateTime.Now.ToString("HH"));
        currentMint = Convert.ToInt32(DateTime.Now.ToString("mm"));
        currentScnt = Convert.ToInt32(DateTime.Now.ToString("ss"));

        /// This will start the selected song when the alarm is true
        if (currentHour == mainAlarm.Hour   &&
            currentMint == mainAlarm.Minute &&
            currentScnt == mainAlarm.Second)
        { _spotify.Play(); NextAlarm(); }

        /// this will start spotify a minute before the alarm goes off
        else if (currentHour     == mainAlarm.Hour   &&
                 currentMint + 1 == mainAlarm.Minute &&
                 currentScnt     == mainAlarm.Second)
        { Connect(); }
      }

      /// Load's next alarm every 5 minutes
      if(Convert.ToInt32(DateTime.Now.ToString("mm")) % 5 == 0)
      {  NextAlarm(); }
    }

    /// <summary>
    /// Checks the current day and returns a boolean value.
    /// This method needs work
    /// </summary>
    /// <returns></returns>
    private bool CheckDay()
    {
      bool checkedSum = false;
      string day;

      // <Summary>
      //     what day is it?
      // </Summary>
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

      // <Summary>
      //     Is that day set to repeat? 
      // </Summary>
      if (mainAlarm.Days.Contains(day))
      {
        checkedSum = true;
      }
      return checkedSum;
    }


    /// <summary>
    /// Updates the alarm listing to say when the next alarm needs to be. 
    /// </summary>
    private void UpdateNext()
    {
      double alarmTime = 0;
      string current = DateTime.Now.ToString("HH:mm");
      if (current.Contains(':'))
      { current = current.Replace(":", "."); }
      alarmTime = Convert.ToDouble(mainAlarm.Hour + "." + mainAlarm.Minute);
      double currentTime = Convert.ToDouble(current);
    }
    #endregion

    #region Button color changes
    private void OnMouseEnter(object sender, EventArgs e)
    {
      addAlarmBtn.BackColor = Color.LightGreen;
    }
    private void OnMouseLeave(object sender, EventArgs e)
    {
      addAlarmBtn.BackColor = Color.FromArgb(0, 255, 255, 255);
    }
    #endregion


    /// <summary>
    /// calls the setAlarm form that will be able to add alarms. 
    /// </summary>
    private void AddAlarm()
    {
      SetAlarm newAlarm = new SetAlarm();
      Alarm alarm = new Alarm();
      newAlarm.Tag = alarm;
      newAlarm.Text = "Add Alarm";

      if (newAlarm.ShowDialog(null) == DialogResult.OK)
      {
        alarmList.Add(new Alarm(alarm.Name, alarm.Hour, alarm.Minute, 0, alarm.Days));
        alarmCount++;
        UpdateUserAlarm();
      }
      NextAlarm();
    }

    /// <summary>
    /// Allows the user to see and edit previouse alarms they have added. 
    /// </summary>
    private void EditAlarm()
    {
      EditAlarm editAlarm = new EditAlarm();
      Alarm alarm = new Alarm();
      editAlarm.Tag = alarmList;
      editAlarm.Text = "Edit Alarm";

      if (editAlarm.ShowDialog(null) == DialogResult.OK)
      {
        UpdateUserAlarm();
      }
      alarmList = (List<Alarm>)editAlarm.Tag;
      alarmCount = alarmList.Count;
      UpdateUserAlarm();
      NextAlarm();
    }

    /// <summary>
    /// This saves all changes to made to new/old alarms when called. 
    /// </summary>
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

      Properties.Settings.Default.UserAlarms = tempUserAlarm;
      Properties.Settings.Default.Save();
    }

    private void label1_Click(object sender, EventArgs e)
    {
      if (hour12 == 0) hour12 = 1;
      else hour12 = 0;
    }
    
    /// <summary>
    /// Allows user to change if the application is started with windows and
    /// allows the user to change the path of spotify in case the launcher
    /// did not select the correct location or it is installed elsewhere. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void settingsBtn_Click(object sender, EventArgs e)
    {
      Settings settingsPage = new Settings();
      settingsPage.Show();
      this.Hide();
    }

    /// <summary>
    /// This simply allows our button to have multiple click events
    /// so that I can better utilize space in the application. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void addAlarmBtn_MouseUp(object sender, MouseEventArgs e)
    {
      switch (e.Button)
      {
        // <Summary>
        //    Right clicking the alarms button will let users 
        //      open a dialog for editing button values. 
        // </Summary>
        case MouseButtons.Right:
          EditAlarm();
          break;

        case MouseButtons.Left:
          AddAlarm();
          break;
      }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    { Application.Exit(); }
  }
}