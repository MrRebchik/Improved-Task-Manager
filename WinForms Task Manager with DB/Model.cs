using System;
using System.CodeDom;
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
        public List<Mission> EntireList { get; set; }
        public string ConnectionString { get; private set; }
        public Model()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MissionsDB"].ConnectionString;
        }
        /// <summary>
        /// Метод для заполнения списка заданий из таблицы с сохраненными
        /// </summary>
        public void FillInEntireList()
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * From EntireMissionsDB", cn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        Mission item = new Mission(id)
                        {
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            State = (State)reader.GetInt32(3),
                            Parent = reader.GetInt32(4),
                            DeadLine = reader.GetDateTime(5),
                            CreationDate = reader.GetDateTime(6),
                            RealFinishingDate = reader.GetDateTime(7),
                            Difficulty = (Difficulty)reader.GetInt32(8),
                            Priority = (Priority)reader.GetInt32(9),

                        };

                        EntireList.Add(item);
                    }
                }
            }
        }
        /// <summary>
        /// Добавление очередного задания. Дублируется в список модели и в базу данных
        /// </summary>
        public void AddNewMission(Mission item) // добавить заполнение таблицы с дочерними индексами
        {
            EntireList.Add(item);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", item.Name),
                new SqlParameter("@Description", item.Description),
                new SqlParameter("@State", (int)item.State),
                new SqlParameter("@Parent", item.Parent),
                new SqlParameter("@DeadLine", item.DeadLine),
                new SqlParameter("@CreationDate", item.CreationDate),
                new SqlParameter("@RealFinishingDate", item.RealFinishingDate),
                new SqlParameter("@Difficulty", (int)item.Difficulty),
                new SqlParameter("@Priority", (int)item.Priority)
        };
            SqlHelper.ExecuteNonQuery(
                ConnectionString, 
                "Insert Into EntireMissionsDB " +
                "(Name, Description, State, Parent, DeadLine, CreationDate, RealFinishingDate, Difficulty, Priority) " +
                "Values (N@Name, N@Description, @State, @Parent, @DeadLine, @CreationDate, @RealFinishingDate, @Difficulty, @Priority)",
                CommandType.Text,
                parameters
                );

        }
        /// <summary>
        /// Метод для изменения параметров задания. Обновляет значение в списке модели и в базе данных.
        /// </summary>
        /// <param name="id"> номер задания </param>
        /// <param name="propertyName"> название поля для изменения</param>
        /// <param name="value"> требуемое значение </param>
        public void EditMission<T>(int missionId, string propertyName, T value)
        {
            var item = EntireList.Where(x => x.Id == missionId);
            Type type = typeof(Mission);
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo.PropertyType != typeof(T))
            {
                throw new Exception("incorrect type");
            }
            propertyInfo.SetValue(item, value);
            string commandText = 
                "Update EntireMissionsDB set " 
                + propertyName 
                + " = " 
                + value
                +"where id = "
                + missionId;
            SqlParameter[] parameters = null;
            SqlHelper.ExecuteNonQuery(ConnectionString, commandText, CommandType.Text,parameters);

        }
        /// <summary>
        /// Метод для удаления задания под номером <i>id</i>
        /// </summary>
        /// <param name="id">номер задания</param>
        public void DeleteMission(int id)
        {
            EntireList.Remove(EntireList.Where(x => x.Id == id).ToList()[0]);
            string commandText = "DELETE  FROM EntireMissionsDB WHERE id =" + id.ToString();
            SqlParameter[] parameters = null;
            SqlHelper.ExecuteNonQuery(ConnectionString, commandText, CommandType.Text, parameters);
        }
    }
}