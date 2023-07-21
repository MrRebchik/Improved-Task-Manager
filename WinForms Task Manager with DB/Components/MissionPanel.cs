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
    internal class MissionPanel:Panel
    {
        private int id;
        static int radius = 10;
        Mission mission = null;
        private TableLayoutPanel table;
        private Label name;
        private Label status;
        private Label difficulty;
        private Label priority;
        internal MissionPanel()
        {
            base.Padding = new Padding(0);
            base.Margin = new Padding(5);
            base.Dock = DockStyle.Fill;
            base.Paint += (sender, e) => RoundPanel_Paint(sender, e);
            table = new TableLayoutPanel()
            {
                Margin = new Padding(0),
                Padding = new Padding(0),
                Dock = DockStyle.Top,
                BackColor = Color.DeepSkyBlue,
            };
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            name = new Label()
            {
                Text = "Название",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
            };
            status = new Label()
            {
                Text = "Статус выполнения",
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill,
            };
            difficulty = new Label()
            {
                Text = "Сложность",
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill,
            };
            priority = new Label()
            {
                Text = "Приоритет",
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill,
            };
            table.Controls.Add(name, 0, 0);
            table.Controls.Add(status, 1, 0);
            table.Controls.Add(difficulty, 2, 0);
            table.Controls.Add(priority, 3, 0);
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.Controls.Add(table);
        }
        internal MissionPanel(Mission item)
        {
            base.Padding = new Padding(0);
            base.Margin = new Padding(5);
            base.Dock = DockStyle.Fill;
            base.Paint += (sender, e) => RoundPanel_Paint(sender, e);
            mission = item;
            id = mission.Id;
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            table = new TableLayoutPanel()
            {
                Margin = new Padding(0),
                Padding = new Padding(0),
                Dock = DockStyle.Top,
                BackColor = Color.Cyan,
            };
            table.RowStyles.Add(new RowStyle(SizeType.Absolute,70));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,40));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            name = new Label()
            {
                Text = mission.Name,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            status = new Label()
            {
                Text = mission.State.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
            };
            difficulty = new Label()
            {
                Text = mission.Difficulty.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
            };
            priority = new Label()
            {
                Text = mission.Priority.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
            };
            table.Controls.Add(name, 0, 0);
            table.Controls.Add(status, 1, 0);
            table.Controls.Add(difficulty, 2, 0);
            table.Controls.Add(priority, 3, 0);
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.Controls.Add(table);
        }

        private void MissionPanel_OnDoubleClick(object sender, EventArgs e)
        {

        }
        private void RoundPanel_Paint(object sender, PaintEventArgs e)
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
