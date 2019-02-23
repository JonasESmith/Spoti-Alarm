using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotiAlarm
{
  public partial class AddAlarm : Form
  {
    public AddAlarm()
    {
      this.BackColor = Color.FromArgb(17, 17, 17);
      this.closeBtn.ForeColor = Color.White;
      this.closeBtn.BackColor = Color.FromArgb(25, 25, 25);
      this.closeBtn.FlatStyle = FlatStyle.Flat;
      this.closeBtn.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);

      InitializeComponent();
    }
  }
}
