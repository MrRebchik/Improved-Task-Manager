using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinForms_Task_Manager_with_DB
{
    internal class LogInForm : Form
    {
        private Control control;
        private Button enter;
        internal LogInForm(Control c)
        {
            control = c;
            enter = new Button
            {
                Location = new Point(150, 150),
                Size = new Size(100,40),
                Text = "Войти"
            };
            this.Controls.Add(enter);
            enter.Click += (s, e) => { c.Forward(); };
        }
    }
}
