using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Task_Manager_with_DB
{
    internal static class Program
    {
        internal static Model model;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            model = new Model();
            model.FillInEntireList();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
