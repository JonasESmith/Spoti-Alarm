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

namespace DigiClockwithAlarm
{
    public partial class SpotiAlarm : MetroFramework.Forms.MetroForm
    {   // hour12 = army/regular  alarm = 0/1
        private int hour12 = 0, alarm = 0;

        public string paths;
        public string fileName;

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
            button2.ForeColor = Color.White;

            #region loadbutton styles 

            // Loading style for the add alarm button.
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button2.MouseEnter += OnMouseEnter;
            button2.MouseLeave += OnMouseLeave;

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
            // Loading alarm from settings.
            alarm = 1;
            getUp.hh = Properties.Settings.Default.UserHour;
            getUp.mm = Properties.Settings.Default.UserMinute;

            // tool tip for add alarm button/label that shows when the next alarm is. 
            // this is gross but is better than its own label.
            string tooltip = " ";
            if ((getUp.hh == 0) && (getUp.mm == 0))
            {
                tooltip = "There is currently no alarm.";
            }
            else
            {
                tooltip = "Next alarm at " + Properties.Settings.Default.UserHour.ToString("D2") + ":"
                                           + Properties.Settings.Default.UserMinute.ToString("D2");
            }
            this.toolTip1.SetToolTip(this.button2, tooltip);
            this.toolTip1.SetToolTip(this.label1, tooltip);
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
                        // this is to give time for spotify to install/launch
                        System.Threading.Thread.Sleep(15000);
                    }
                    else
                    {
                        // this brings the window into "Focus"
                        Process.Start(start);
                        // this gives enough time for spotify to be brought to the "front" or focus
                        System.Threading.Thread.Sleep(2000);
                    }
                    SendKeys.Send("{^} {Right}");
                }
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
            button2.BackColor = Color.LightGreen; // or Color.Red or whatever you want
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(0, 255, 255, 255);
        }
        #endregion

        #region Misc.

        private void button2_Click(object sender, EventArgs e)
        {
            SetAlarm newAlarm = new SetAlarm();
            newAlarm.Show();
            this.Hide();
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

            settings settingsPage = new settings();
            settingsPage.Show();
            this.Hide();


        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        { Application.Exit(); }
        #endregion
    }
}