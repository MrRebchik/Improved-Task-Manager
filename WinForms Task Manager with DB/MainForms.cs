using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Task_Manager_with_DB
{
    public partial class MainForm : Form
    {
        private View.RoundButton switchPanelButton1;
        private View.RoundButton switchPanelButton2;
        private View.RoundButton switchPanelButton3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Color tabsColor = Color.PowderBlue;
        public MainForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(815, 690);
            panel1.Paint += (sender,e) => panel1_Paint(sender, e);
        }
        private void InitializeComponent()
        {
            panel1 = new Panel()
            {
                Location = new Point(10, 40),
                Size = new Size(780, 600),
                BackColor = tabsColor
            };
            panel2 = new Panel();
            panel3 = new Panel();
            Controls.Add(panel1);
            switchPanelButton1 = new View.RoundButton(25)
            {
                Location = new Point(10, 10),
                Size = new Size(120, 60),
                BackColor = tabsColor,
                Text = "Списки",
                TextAlign = ContentAlignment.TopCenter
            };
            switchPanelButton2 = new View.RoundButton(25)
            {
                Location = new Point(130, 10),
                Size = new Size(120, 60),
                BackColor = tabsColor,
                Text = "План на день",
                TextAlign = ContentAlignment.TopCenter
            };
            switchPanelButton3 = new View.RoundButton(25)
            {
                Location = new Point(250, 10),
                Size = new Size(120, 60),
                BackColor = tabsColor,
                Text = "Настройки",
                TextAlign = ContentAlignment.TopCenter
            };
            Controls.Add(switchPanelButton1);
            Controls.Add(switchPanelButton2);
            Controls.Add(switchPanelButton3);
        }
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddLine(radius, 0, panel1.Width - radius, 0);
            path.AddArc(panel1.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(panel1.Width, radius, panel1.Width, panel1.Height - radius);
            path.AddArc(panel1.Width - radius, panel1.Height - radius, radius, radius, 0, 90);
            path.AddLine(panel1.Width - radius, panel1.Height, radius, panel1.Height);
            path.AddArc(0, panel1.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, panel1.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            panel1.Region = new Region(path);
        }

    }
}

