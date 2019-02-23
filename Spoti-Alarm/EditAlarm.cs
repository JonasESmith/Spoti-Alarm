// Programmer :  Jonas Smith
// program    :  SpotiAlarm

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpotiAlarm
{
  public partial class EditAlarm : Form
  {
    public int hh;
    public int mm;
    public int ss;
    public int repeat;
    public string reCheck;
    private static Alarm alarm;
    private static List<Alarm> alarmListTemp;

    public EditAlarm()
    {
      InitializeComponent();
    }

    private void EditAlarm_Load(object sender, EventArgs e)
    {
      this.BackColor = Color.FromArgb(17, 17, 17);
      editCloseBtn.ForeColor = Color.White;
      editCloseBtn.BackColor = Color.FromArgb(25, 25, 25);
      editCloseBtn.FlatStyle = FlatStyle.Flat;
      editCloseBtn.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);

      alarmListTemp = (List<Alarm>)this.Tag;

      LoadPanel();
    }

    private void LoadPanel()
    {
      int firstBtn = 0, secondBtn = 0;
      int panelWidth = alarmFlowLayoutPanel.Width;

      double titleWidthPerc = (0.65 * panelWidth);
      double buttonWidthPerc = (0.155 * panelWidth);

      this.alarmFlowLayoutPanel.Controls.Clear();
      if (alarmListTemp.Count != 0)
      {
        for (int i = 0; i < alarmListTemp.Count; i++)
        {
          Button alarmComponenet      = new Button();
          alarmComponenet.Text        = alarmListTemp[i].Name.ToString();
          alarmComponenet.Font        = new Font("Arial", 8, FontStyle.Bold);
          alarmComponenet.Name        = "button" + i;
          alarmComponenet.Click       += new EventHandler(onClick);
          alarmComponenet.Width       = Convert.ToInt32(titleWidthPerc);
          alarmComponenet.Height      = 50;
          alarmComponenet.Visible     = true;
          alarmComponenet.TabStop     = false;
          alarmComponenet.Location    = new Point(firstBtn + 10, 4);
          alarmComponenet.BackColor   = Color.FromArgb(78, 224, 88);
          alarmComponenet.FlatStyle   = FlatStyle.Flat;
          alarmComponenet.MouseEnter  += new EventHandler(onMouse_Enter);
          alarmComponenet.MouseLeave  += new EventHandler(onMouse_Leave);
          alarmComponenet.FlatAppearance.BorderSize = 0;
          alarmComponenet.Show();
          alarmComponenet.MouseDown += AlarmComponenet_MouseDown;
          firstBtn += alarmComponenet.Width;

          Button editButton = new Button();
          editButton.Text = "Edit";
          editButton.MouseDown += AlarmComponenet_MouseDown;
          editButton.Name = "edit" + i;
          editButton.Font = new Font("Arial", 8, FontStyle.Bold);
          editButton.Click += new EventHandler(onClick);
          editButton.Width = Convert.ToInt32(buttonWidthPerc);
          editButton.Height = 50;
          editButton.TabStop = false;
          editButton.Visible = true;
          editButton.Location = new Point(secondBtn + 50, 4);
          editButton.BackColor = Color.FromArgb(78, 224, 88);
          editButton.FlatStyle = FlatStyle.Flat;
          editButton.MouseEnter += new EventHandler(onMouse_Enter);
          editButton.MouseLeave += new EventHandler(onMouse_Leave);
          editButton.FlatAppearance.BorderSize = 0;
          editButton.Show();
          secondBtn += editButton.Width;

          Button delButton = new Button();
          delButton.Text = "Delete";
          delButton.Name = "del" + i;
          alarmComponenet.MouseDown += AlarmComponenet_MouseDown;
          delButton.Font = new Font("Arial", 8, FontStyle.Bold); 
          delButton.Click += new EventHandler(onClick);
          delButton.Width = Convert.ToInt32(buttonWidthPerc);
          delButton.Height = 50;
          delButton.TabStop = false;
          delButton.Visible = true;
          delButton.Location = new Point(secondBtn + 50, 4);
          delButton.BackColor = Color.FromArgb(250, 88, 72);
          delButton.FlatStyle = FlatStyle.Flat;
          delButton.MouseEnter += new EventHandler(onMouse_Enter);
          delButton.MouseLeave += new EventHandler(onMouse_Leave);
          delButton.FlatAppearance.BorderSize = 0;
          delButton.Show();
          secondBtn += delButton.Width;

          if (i > 1)
          {
            this.Size = new Size(alarmFlowLayoutPanel.Width, 195 + ((i - 1) * 55));
          }

          if (i <= 1)
          {
            this.Size = new Size(alarmFlowLayoutPanel.Width, 195 + ((i - 1) * 55));
          }

          this.alarmFlowLayoutPanel.Controls.Add(alarmComponenet);
          this.alarmFlowLayoutPanel.Controls.Add(editButton);
          this.alarmFlowLayoutPanel.Controls.Add(delButton);
        }
      }
      else
      {
        Label noAlarms = new Label();
        noAlarms.Text = " Currently no alarms";
        noAlarms.Size = new Size(350 , 50);
        noAlarms.ForeColor = Color.White;
        noAlarms.Dock = DockStyle.Top;

        this.alarmFlowLayoutPanel.Controls.Add(noAlarms);
      }
    }

    private void onClick(object sender, EventArgs e)
    {
      bool delete = false; 

      Button button = sender as Button;
      int    index;
      string name = button.Name;

      if (name.Contains("button"))
      {
        name = button.Name.Replace("button", "");
        index = Convert.ToInt32(name);
      }
      else if(name.Contains("del"))
      {
        name = button.Name.Replace("del", "");
        index = Convert.ToInt32(name);

        delete = true;
      }
      else
      {
        name = button.Name.Replace("edit", "");
        index = Convert.ToInt32(name);
      }

      if (delete != true)
      {
        SetAlarm editAlarm = new SetAlarm();
        editAlarm.Tag = alarmListTemp[index];
        editAlarm.Text = "Edit Alarm";

        if (editAlarm.ShowDialog(null) == DialogResult.OK)
        {
          alarmListTemp[index] = (Alarm)editAlarm.Tag;
          //alarmListTemp[index] = new Alarm();

          //UpdateUserAlarm();
        }
        //NextAlarm();
      }
      else
      {
        if (alarmListTemp.Count != 0)
        {
          alarmListTemp.Remove(alarmListTemp[index]);
          int count = alarmListTemp.Count;
          LoadPanel();
        }
      }
    }

    private void onMouse_Enter(object sender, EventArgs e)
    {
      string name = "";
      Button button = sender as Button;
      int index;

      name = button.Name;

      if (name.Contains("button"))
      {
        button.BackColor = Color.FromArgb(78, 200, 72);

        name = button.Name.Replace("button", "");
        index = Convert.ToInt32(name);

        var button2 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "edit" + index);
        button2.BackColor = Color.FromArgb(78, 180, 72);
        button2.Show();

        var button3 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "del" + index);
        button3.BackColor = Color.FromArgb(216, 66, 72);
        button3.Show();
      }
      else if (name.Contains("edit"))
      {
        button.BackColor = Color.FromArgb(78, 200, 72);

        name = button.Name.Replace("edit", "");
        index = Convert.ToInt32(name);

        var button2 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "button" + index);
        button2.BackColor = Color.FromArgb(78, 180, 72);
        button2.Show();

        var button3 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "del" + index);
        button3.BackColor = Color.FromArgb(216, 66, 72);
        button3.Show();
      }
      else
      {
        button.BackColor = Color.FromArgb(216, 66, 72);

        name = button.Name.Replace("del", "");
        index = Convert.ToInt32(name);

        var button2 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "button" + index);
        button2.BackColor = Color.FromArgb(78, 180, 72);
        button2.Show();

        var button3 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "edit" + index);
        button3.BackColor = Color.FromArgb(78, 180, 72);
        button3.Show();
      }

    }

    private void onMouse_Leave(object sender, EventArgs e)
    {
      string name = "";
      Button button = sender as Button;
      int index;
      string btn2Name;

      name = button.Name;
      if (button != null)
      {
        if (name.Contains("button"))
        {
          button.BackColor = Color.FromArgb(78, 224, 88);
          name = button.Name.Replace("button", "");
          index = Convert.ToInt32(name);

          var button2 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "edit" + index);
          button2.BackColor = Color.FromArgb(78, 224, 88);
          button2.Show();

          var button3 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "del" + index);
          button3.BackColor = Color.FromArgb(250, 88, 72);
          button3.Show();
        }
        else if (name.Contains("edit"))
        {
          button.BackColor = Color.FromArgb(78, 224, 88);
          name = button.Name.Replace("edit", "");
          index = Convert.ToInt32(name);
          btn2Name = "button" + index;

          var button2 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == btn2Name);
          button2.BackColor = Color.FromArgb(78, 224, 88);
          button2.Show();

          var button3 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "del" + index);
          button3.BackColor = Color.FromArgb(250, 88, 72);
          button3.Show();
        }
        else
        {
          button.BackColor = Color.FromArgb(250, 88, 72);

          name = button.Name.Replace("del", "");
          index = Convert.ToInt32(name);

          if (index > alarmListTemp.Count)
          {
          var button2 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "button" + index);
          button2.BackColor = Color.FromArgb(78, 224, 88);
          button2.Show();

          var button3 = alarmFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "edit" + index);
          button3.BackColor = Color.FromArgb(78, 224, 88);
          button3.Show();
          }
        }
      }
    }

    private void alarmPanel_Paint(object sender, PaintEventArgs e)
    {
    }

    private void alarmFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void editCloseBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    /// <summary>
    ///  Basic code for letting user drag the window. 
    /// </summary>
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();

    private void alarmFlowLayoutPanel_MouseDown(object sender, MouseEventArgs e)
    {
      WindowDraggable(sender, e);
    }

    private void titlePanel_MouseDown(object sender, MouseEventArgs e)
    {
      WindowDraggable(sender, e);
    }

    public void WindowDraggable(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
      }
    }

    private void AlarmComponenet_MouseDown(object sender, MouseEventArgs e)
    {
      WindowDraggable(sender, e);
    }
  }
}
