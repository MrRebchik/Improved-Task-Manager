using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Task_Manager_with_DB
{
    internal class Control
    {
        public IControlState State { get; set; }
        private Model model;
        public Form View
        {
            get;
            set;
        }
        private User user;
        public Control(IControlState st, Model m, Form v)
        {
            State = st;
            model = m;
            View = v;
            this.Forward();
        }
        public void Forward()
        {
            State.Forward(this);
        }
        public bool LogIn()
        {
            return false;
        }
        public bool LogOut()
        {
            return false;
        }
        public bool IsInternetConnectionSet()
        {
            return false;
        }
        public void LocalLoad()
        {
            model.FillInEntireList();
        }
        

    }

    internal interface IControlState
    {
        void Forward(Control c);
    }
    internal class InitializationState : IControlState
    {
        public void Forward(Control c)
        {
            c.State = new LogInState(c);
        }
    }
    internal class LogInState : IControlState
    {
        internal LogInState(Control c)
        {
            c.View = new LogInForm(c);
        }
        public void Forward(Control c)
        {
            if(c.LogIn())
            {
                c.State = new AuthorizedState(c);
            }
            else
            {
                c.State = new GuestState(c);
                c.Forward();
            }
        }
    }
    internal class AuthorizedState : IControlState
    {
        internal AuthorizedState(Control c)
        {
            c.View = new MainForm(c);
            Application.Run(c.View);
        }
        public void Forward(Control c)
        {

        }
    }
    internal class GuestState : IControlState
    {
        internal GuestState(Control c)
        {
            c.View = new MainForm(c);
            //Thread myThread1 = new Thread(Application.Run(c.View));
        }
        public void Forward(Control c)
        {
            c.State = new LocalLoadState(c);
            c.Forward();
        }
    }
    internal class CheckConnectedState : IControlState
    {
        public void Forward(Control c)
        {

        }
    }
    internal class ConnectedState : IControlState
    {
        public void Forward(Control c)
        {

        }
    }
    internal class DisConnectedState : IControlState
    {
        public void Forward(Control c)
        {

        }
    }
    internal class LocalLoadState : IControlState
    {
        internal LocalLoadState(Control c)
        {
            c.LocalLoad();
        }
        public void Forward(Control c)
        {

        }
    }
    internal class RemotedLoadState : IControlState
    {
        public void Forward(Control c)
        {

        }
    }

}
