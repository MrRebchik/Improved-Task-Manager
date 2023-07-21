using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Task_Manager_with_DB
{
    enum Role
    {
        Guest,
        Ordinary,
        Moderator
    }
    internal class User
    {
        private int id;
        private string name;
        private string password;
        private string email;
        private Role role;
        private string MissionDBConnectionString;
    }
}
