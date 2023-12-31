﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Task_Manager_with_DB
{
    internal static class Program
    {
        internal static Model model;
        internal static Control control;
        internal static Form view;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            //model.FillInEntireList();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            model = new Model();
            control = new Control(new InitializationState(),model,view);
            Application.Run(control.View);
        }
    }
}
