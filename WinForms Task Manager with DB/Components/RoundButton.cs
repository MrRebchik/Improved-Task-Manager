using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Task_Manager_with_DB
{
    internal class RoundButton : Button
    {
        private int radius;
        internal RoundButton(int radius)
        {
            base.FlatAppearance.BorderSize = 0;
            base.FlatStyle = FlatStyle.Flat;
            this.radius = radius;
            base.Paint += (sender, e) => RoundButton_Paint(sender, e);
        }
        private void RoundButton_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(radius, 0, base.Width - radius, 0);
            path.AddArc(base.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(base.Width, radius, base.Width, base.Height - radius);
            path.AddArc(base.Width - radius, base.Height - radius, radius, radius, 0, 90);
            path.AddLine(base.Width - radius, base.Height, radius, base.Height);
            path.AddArc(0, base.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, base.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            base.Region = new Region(path);
        }
    }
}
