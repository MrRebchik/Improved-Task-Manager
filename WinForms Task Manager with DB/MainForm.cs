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
        #region объявление TabControl
        private RoundButton switchPanelButton1;
        private RoundButton switchPanelButton2;
        private RoundButton switchPanelButton3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        #endregion
        #region объявление элементов вкладки Списков
        private TableLayoutPanel tableLayoutPanel1;
        private Panel baseForButtonPanel;
        private Panel buttonPanel;
        private RoundButton lists;
        private RoundButton stickers;
        private RoundButton hierarchy;
        private Panel panel1ContentHolderPanel;
        private Panel listPanel;
        private Panel stickersPanel;
        private Panel hierarchyPanel;

        #endregion
        private Color tabsColor = Color.PowderBlue;
        public MainForm()
        {
            InitializeAllComponents();
            this.MinimumSize = new Size(815, 690);
            #region подписка на события
            panel1.Paint += (sender, e) => panel_Paint(panel1, sender, e);
            panel2.Paint += (sender, e) => panel_Paint(panel2, sender, e);
            panel3.Paint += (sender, e) => panel_Paint(panel3, sender, e);
            switchPanelButton1.Click += (sender, e) => switchPanelButton1_Click(sender, e);
            switchPanelButton2.Click += (sender, e) => switchPanelButton2_Click(sender, e);
            switchPanelButton3.Click += (sender, e) => switchPanelButton3_Click(sender, e);
            buttonPanel.Paint += (sender, e) => panel_Paint(buttonPanel, sender, e);
            lists.Click += (sender, e) => lists_Click(sender, e);
            stickers.Click += (sender, e) => stickers_Click(sender, e);
            hierarchy.Click += (sender, e) => hierarchy_Click(sender, e);
            #endregion
        }
        private void InitializeAllComponents()
        {
            #region создание TabControl
            panel1 = new Panel()
            {
                Location = new Point(10, 40),
                Size = new Size(780, 600),
                BackColor = tabsColor
            };
            panel2 = new Panel()
            {
                Location = new Point(10, 40),
                Size = new Size(780, 600),
                BackColor = tabsColor
            };
            panel3 = new Panel()
            {
                Location = new Point(10, 40),
                Size = new Size(780, 600),
                BackColor = tabsColor
            };
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            panel2.Hide();
            panel3.Hide();
            switchPanelButton1 = new RoundButton(25)
            {
                Location = new Point(10, 10),
                Size = new Size(120, 60),
                BackColor = tabsColor,
                Text = "Списки",
                TextAlign = ContentAlignment.TopCenter
            };
            switchPanelButton2 = new RoundButton(25)
            {
                Location = new Point(130, 10),
                Size = new Size(120, 60),
                BackColor = tabsColor,
                Text = "План на день",
                TextAlign = ContentAlignment.TopCenter
            };
            switchPanelButton3 = new RoundButton(25)
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
            #endregion
            InitializeMissionsTabComponents();
            InitializeManagerTabComponents();
            InitializePreferencesTabComponents();
        }
        private void InitializeMissionsTabComponents()
        {
            // создание Главной вкладки списков заданий
            tableLayoutPanel1 = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Size = new Size(panel1.Width, panel1.Height),
                BackColor = Color.Orchid,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble,
                Padding = new Padding(0),
            };

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            baseForButtonPanel = new Panel()
            {
                BackColor = tableLayoutPanel1.BackColor,
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };

            panel1ContentHolderPanel = new Panel()
            {
                BackColor = tableLayoutPanel1.BackColor,
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };

            buttonPanel = new Panel
            {
                BackColor = Color.PaleGreen,
                Dock = DockStyle.None,
                Anchor = AnchorStyles.None,
                Size = new Size(80, 230),
            };
            baseForButtonPanel.Controls.Add(buttonPanel);

            lists = new RoundButton(10)
            {
                Size = new Size(70, 70),
                Location = new Point(5, 5),
                BackColor = Color.Salmon,
                Text = "Таблица",
            };
            stickers = new RoundButton(10)
            {
                Size = new Size(70, 70),
                Location = new Point(5, 80),
                BackColor = Color.DeepSkyBlue,
                Text = "Стикеры",
            };
            hierarchy = new RoundButton(10)
            {
                Size = new Size(70, 70),
                Location = new Point(5, 155),
                BackColor = Color.Chocolate,
                Text = "Иерархия",
            };

            buttonPanel.Controls.Add(lists);
            buttonPanel.Controls.Add(stickers);
            buttonPanel.Controls.Add(hierarchy);

            listPanel = new Panel()
            {
                Location = new Point(0, 0),
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = Color.Salmon,
            };
            stickersPanel = new Panel()
            {
                Location = new Point(0, 0),
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = Color.DeepSkyBlue,
            };
            hierarchyPanel = new Panel()
            {
                Location = new Point(0, 0),
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = Color.Chocolate,
            };

            tableLayoutPanel1.Controls.Add(baseForButtonPanel, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1ContentHolderPanel, 1, 0);


            panel1ContentHolderPanel.Controls.Add(listPanel);
            panel1ContentHolderPanel.Controls.Add(stickersPanel);
            panel1ContentHolderPanel.Controls.Add(hierarchyPanel);
            panel1.Controls.Add(tableLayoutPanel1);
            stickersPanel.Hide();
            hierarchyPanel.Hide();
            buttonPanel.Location = new Point(5, 5);

            // Дальше наполнение 
        }
        private void InitializeManagerTabComponents()
        {
            // создание вкладки Менеджера заданий
        }
        private void InitializePreferencesTabComponents()
        {
            // создание вкладки Настроек
        }

        // Дальше под-вкладки
        private void InitializeListPanelComponents()
        {

        }
        private void InitializeStickersPanelComponents()
        {

        }
        private void InitializeHierarchyPanelComponents()
        {

        }
        void panel_Paint(Panel p, object sender, PaintEventArgs e)
        {
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddLine(radius, 0, p.Width - radius, 0);
            path.AddArc(p.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(p.Width, radius, p.Width, p.Height - radius);
            path.AddArc(p.Width - radius, p.Height - radius, radius, radius, 0, 90);
            path.AddLine(p.Width - radius, p.Height, radius, p.Height);
            path.AddArc(0, p.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, p.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            p.Region = new Region(path);
        }
        #region обработчики событий переключения вкладок
        private void switchPanelButton1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }
        private void switchPanelButton2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }
        private void switchPanelButton3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
        }
        #endregion
        #region обработчики событий переключения панелей первой вкладки
        private void lists_Click(object sender, EventArgs e)
        {
            listPanel.Show();
            stickersPanel.Hide();
            hierarchyPanel.Hide();
            buttonPanel.Location = new Point(5, 5);
        }
        private void stickers_Click(object sender, EventArgs e)
        {
            listPanel.Hide();
            stickersPanel.Show();
            hierarchyPanel.Hide();
            buttonPanel.Location = new Point(5, 5);
        }
        private void hierarchy_Click(object sender, EventArgs e)
        {
            listPanel.Hide();
            stickersPanel.Hide();
            hierarchyPanel.Show();
            buttonPanel.Location = new Point(5, 5);
        }
        #endregion
    }
}


