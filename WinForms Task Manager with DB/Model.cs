using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Task_Manager_with_DB
{
    internal class Model
    {
        private List<Mission> entireList = new List<Mission>();
        public List<Mission> EntireList { get; set; }
        public string ConnectionString { get; private set; }
        public Model()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MissionsDB"].ConnectionString;
        }
        public void FillInEntireList()
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * From EntireMissionsDB", cn);
                cmd.ExecuteReader();
            }
        }
    }
}
