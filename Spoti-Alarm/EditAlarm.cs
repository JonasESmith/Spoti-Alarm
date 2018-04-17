// Programmer :  Jonas Smith
// program    :  SpotiAlarm

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpotiAlarm
{
  public partial class EditAlarm : MetroFramework.Forms.MetroForm
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
      // <Summary>
      //    loads "dark" style to match spotify 
      // </Summary>
      #region MetroTheme
      this.StyleManager = msmMain;
      msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
      msmMain.Style = MetroFramework.MetroColorStyle.Green;
      #endregion

      alarmListTemp = (List<Alarm>)this.Tag;

      LoadPanel();
    }

    private void LoadPanel()
    {
      int firstBtn = 0, secondBtn = 0;
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
          alarmComponenet.Width       = 205;
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
          firstBtn += 265;

          Button editButton = new Button();
          editButton.Text = "Edit";
          editButton.Name = "edit" + i;
          editButton.Font = new Font("Arial", 8, FontStyle.Bold);
          editButton.Click += new EventHandler(onClick);
          editButton.Width = 75;
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
          secondBtn += 80;

          Button delButton = new Button();
          delButton.Text = "Delete";
          delButton.Name = "del" + i;
          delButton.Font = new Font("Arial", 8, FontStyle.Bold); 
          delButton.Click += new EventHandler(onClick);
          delButton.Width = 60;
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
          secondBtn += 80;

          if (i > 1)
          {
            this.Size = new Size(400, 195 + ((i - 1) * 55));
          }

          if(i <= 1)
          {
            this.Size = new Size(400, 195 + ((i - 1) * 55));
          }

          this.alarmFlowLayoutPanel.Controls.Add(alarmComponenet);
          this.alarmFlowLayoutPanel.Controls.Add(editButton);
          this.alarmFlowLayoutPanel.Controls.Add(delButton);
        }
      }
      else
      {
        Label noAlarms = new Label();
        noAlarms.Text = "                                        Currently no alarms";
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
  }
}
