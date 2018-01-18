using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SpotiAlarm
{
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        public string path = Properties.Settings.Default.UserPath;
        public Settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            #region Loading style 
            // loads correct theme from MetroFramework.
            this.StyleManager = msmMain;

            msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
            msmMain.Style = MetroFramework.MetroColorStyle.Green;

            // Button theme for save
            saveBtn.TabStop = false;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            saveBtn.MouseEnter += OnMouseEnter;
            saveBtn.MouseLeave += OnMouseLeave;
            saveBtn.ForeColor = Color.White;

            // spotiPathBtn
            changePathBtn.ForeColor = Color.Gray;
            changePathBtn.TabStop = false;
            changePathBtn.FlatStyle = FlatStyle.Flat;
            changePathBtn.FlatAppearance.BorderSize = 0;
            changePathBtn.FlatAppearance.BorderColor = Color.LightGreen;
            // adds the green hoover effect to the buttons
            changePathBtn.MouseEnter += OnMouseEnterPath;
            changePathBtn.MouseLeave += OnMouseLeavePath;
            changePathBtn.ForeColor = Color.LightGray;

            #endregion

            bool startup = Properties.Settings.Default.UserStartup;
            if (startup == true) 
            {
                onStartupCheck.Checked = true;
            }
        }

        private void OnMouseEnterPath(object sender, EventArgs e)
        {
            changePathBtn.BackColor = Color.LightGreen;
        }
        private void OnMouseLeavePath(object sender, EventArgs e)
        {
            changePathBtn.BackColor = Color.FromArgb(0, 255, 255, 255);
        }


        private void OnMouseEnter(object sender, EventArgs e)
        {
            saveBtn.BackColor = Color.LightGreen; // or Color.Red or whatever you want
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            saveBtn.BackColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserStartup = onStartupCheck.Checked;

            Properties.Settings.Default.Save();

            // hides the alarm and makes a new instance of the opening form. 
            this.Hide();
            SpotiAlarm ShowAlarm = new SpotiAlarm();
            ShowAlarm.Show();
            this.Close();
        }

        private void changePathBtn_Click(object sender, EventArgs e)
        {   // create openfiledialog for the button press
            OpenFileDialog openExe = new OpenFileDialog();

            // this is finding the "usual" path for spotify however it may not always work
            string userName = Environment.UserName;
            path = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Spotify";
            openExe.Filter = "EXE files (*.exe)|*.exe";

            // open file dialog at the spotify location
            openExe.InitialDirectory = path;
            if (openExe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // sets the new path to execute.
                String filePath = openExe.FileName;
                Properties.Settings.Default.UserPath = filePath;
                Properties.Settings.Default.Save();
            }
        }

        private void onStartupCheck_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (onStartupCheck.Checked)
                rk.SetValue("SpotiAlarm", Application.ExecutablePath.ToString());
            else
                rk.DeleteValue("SpotiAlarm", false);
        }
    }
}
