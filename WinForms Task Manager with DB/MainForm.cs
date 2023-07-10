using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinForms_Task_Manager_with_DB
{
    internal class MainForm : Form
    {
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabControl tabControl1;
        private Graphics graphics;

        public MainForm()
        {
            InitializeComponent();
            graphics = CreateGraphics();
            this.BackColor = Color.BlanchedAlmond;
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            SizeChanged += (sender, args) =>
            {
                ResizeTabs();
            };
            Paint += (sender, args) => 
            { 
                //RoundCornerTabControl(sender, args);
                //Invalidate();
            };
        }
        private void RoundCornerTabControl(object sender, PaintEventArgs e)
        {
            GraphicsPath pagePath = new GraphicsPath();
            Rectangle pageRectangle = tabControl1.ClientRectangle;
            tabControl1.Region = new Region(pagePath);
            int radius = 10;
            int tabLength = 20;

            e.Graphics.DrawPath(new Pen(Color.Aqua, 2), pagePath);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            pagePath.AddArc(0, 0, radius, radius, 180, 90);
            pagePath.AddLine(new Point(radius, radius), new Point(radius + tabLength, radius));
            pagePath.AddArc(radius + tabLength, radius, radius, radius, 270, 90);
            pagePath.AddLine(new Point(2 * radius + tabLength, 2 * radius), new Point(300, 72));
            pagePath.AddArc(300, 72, 36, 36, 270, 90);
            pagePath.AddLine(new Point(336, 108), new Point(336, 264));
            pagePath.AddArc(300, 264, 36, 36, 0, 90);
            pagePath.AddLine(new Point(300, 300), new Point(72, 300));
            pagePath.AddArc(0, 264, 36, 36, 90, 90);

            tabControl1.Region = new Region(pagePath);


        }
        private void InitializeComponent()
        {
            this.tabPage1 = new TabPage();
            this.tabPage2 = new TabPage();
            this.tabPage3 = new TabPage();
            this.tabControl1 = new TabControl();
             

            tabPage1.Text = "Список заданий";
            tabPage1.TabIndex = 0;
            tabPage1.BackColor = Color.Blue;

            tabPage2.Text = "Планировщик";
            tabPage2.TabIndex = 1;
            tabPage2.BackColor = Color.DarkSlateBlue;

            tabPage3.Text = "Настройки";
            tabPage3.TabIndex = 2;
            tabPage3.BackColor = Color.Blue;


            tabControl1.SelectedIndex = 0;
            tabControl1.TabIndex = 0;
            this.Text = "Планировщик дел";

            //// Adds controls to the first tab page.
            //tabPage1.Controls.Add(this.tab1Label1);
            //tabPage1.Controls.Add(this.tab1Button1);
            // Adds the TabControl to the form.
            this.Controls.Add(this.tabControl1);
            // Adds the tab pages to the TabControl.
            tabControl1.Controls.Add(this.tabPage1);
            tabControl1.Controls.Add(this.tabPage2);
            tabControl1.Controls.Add(this.tabPage3);
        }
        private void ResizeTabs()
        {
            tabControl1.Location = new Point(0, 0);
            tabControl1.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
        }
        
        

        private void tab1Button1_Click(object sender, System.EventArgs e)
        {
            // Inserts the code that should run when the button is clicked.
        }

    }
}
