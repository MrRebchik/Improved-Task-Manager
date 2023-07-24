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
        #region ListPanelComponents
        private TableLayoutPanel tableLayoutPanel2;
        private Panel buttonPanel2;
        private RoundButton sortByImportance;
        private RoundButton sortByDifficulty;
        private RoundButton sortDirection;
        private RoundButton sortByDeadline;
        private RoundButton sortDirection2;
        private Panel missionHolderPanel;
        private TableLayoutPanel missionsHolderTable;
        private Panel buttonPanel3;
        private TextBox textBox;
        private RoundButton searchButton;
        #endregion

        private Color tabsColor = Color.PowderBlue;
        internal MainForm(Control c)
        {
            InitializeAllComponents();
            this.MinimumSize = new Size(815, 690);
            #region подписка на события
            panel1.Paint += (sender, e) => Panel_Paint(panel1, sender, e);
            panel2.Paint += (sender, e) => Panel_Paint(panel2, sender, e);
            panel3.Paint += (sender, e) => Panel_Paint(panel3, sender, e);
            switchPanelButton1.Click += (sender, e) => SwitchPanelButton1_Click(sender, e);
            switchPanelButton2.Click += (sender, e) => SwitchPanelButton2_Click(sender, e);
            switchPanelButton3.Click += (sender, e) => SwitchPanelButton3_Click(sender, e);
            buttonPanel.Paint += (sender, e) => Panel_Paint(buttonPanel, sender, e);
            lists.Click += (sender, e) => Lists_Click(sender, e);
            stickers.Click += (sender, e) => Stickers_Click(sender, e);
            hierarchy.Click += (sender, e) => Hierarchy_Click(sender, e);
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
            InitializeListPanelComponents();
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
            tableLayoutPanel2 = new TableLayoutPanel
            {
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                Dock = DockStyle.Fill
            };
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute,50));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            buttonPanel2 = new Panel()
            {
                Dock = DockStyle.Fill,
            };
            missionHolderPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
            };
            buttonPanel3 = new Panel()
            {
                Dock = DockStyle.Fill,
            };
            tableLayoutPanel2.Controls.Add(buttonPanel2,0,0);
            tableLayoutPanel2.Controls.Add(missionHolderPanel, 0, 1);
            tableLayoutPanel2.Controls.Add(buttonPanel3, 0, 2);
            listPanel.Controls.Add(tableLayoutPanel2);

            UpdateMissionTable(Program.model.EntireList);
            missionsHolderTable.AutoScroll = true;

            missionHolderPanel.Controls.Add(missionsHolderTable);

        }
        private void InitializeStickersPanelComponents()
        {

        }
        private void InitializeHierarchyPanelComponents()
        {

        }
        internal void UpdateMissionTable(List<Mission> list)
        {
            missionsHolderTable = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
            };
            missionsHolderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
            missionsHolderTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            missionsHolderTable.Controls.Add(new MissionPanel(), 0, 0);
            int rowsCount = 1;
            foreach(var item in list)
            {
                missionsHolderTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 110));
                missionsHolderTable.Controls.Add(new MissionPanel(item), 0, rowsCount);
                rowsCount++;

            }
        }
        void Panel_Paint(Panel p, object sender, PaintEventArgs e)
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
        private void SwitchPanelButton1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }
        private void SwitchPanelButton2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }
        private void SwitchPanelButton3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
        }
        #endregion
        #region обработчики событий переключения панелей первой вкладки
        private void Lists_Click(object sender, EventArgs e)
        {
            listPanel.Show();
            stickersPanel.Hide();
            hierarchyPanel.Hide();
            buttonPanel.Location = new Point(5, 5);
        }
        private void Stickers_Click(object sender, EventArgs e)
        {
            listPanel.Hide();
            stickersPanel.Show();
            hierarchyPanel.Hide();
            buttonPanel.Location = new Point(5, 5);
        }
        private void Hierarchy_Click(object sender, EventArgs e)
        {
            listPanel.Hide();
            stickersPanel.Hide();
            hierarchyPanel.Show();
            buttonPanel.Location = new Point(5, 5);
        }
        #endregion
    }
}


