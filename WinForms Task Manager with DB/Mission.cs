using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Task_Manager_with_DB
{
    enum Difficulty
    {
        VeryEasy,
        Easy,
        Normal,
        Hard,
        VeryHard
    }
    enum Priority
    {
        VeryLow,
        Low,
        Medium,
        High,
        VeryHigh
    }
    enum State
    {
        InProgress,
        Frozen,
        Failed,
        Late,
        Done
    }
    internal class Mission
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State State 
        { 
            get{ return State; } 
            set
            {
                if (value == State.Done)
                {
                    this.State = value;
                    this.RealFinishingDate = DateTime.Now;
                }
                else { this.State = value; }
            }
        }
        public int? Parent { get; set; }
        public int?[] Children {get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? RealFinishingDate { get; private set; }
        public Difficulty Difficulty { get; set; }
        public Priority Priority { get; set; }

        //Constructors
        #region 
        public Mission(int id, string name, string descript, Difficulty dif, Priority priority, DateTime? deadLine)
        {
            this.Id = id;
            this.Name = name;
            this.Description = descript;
            this.Difficulty = dif;
            this.Priority = priority;
            this.DeadLine = deadLine;
        }
        public Mission(int id, string name, string descript, Difficulty dif, Priority priority) 
            : this(id, name, descript, dif, priority, null)
        {

        }
        public Mission(int id, string name, string descript, Difficulty dif, DateTime? deadLine)
            : this(id, name, descript, dif, Priority.Medium, deadLine)
        {

        }
        public Mission(int id, string name, string descript, Priority priority, DateTime? deadLine)
            : this(id, name, descript, Difficulty.Normal, priority, deadLine)
        {

        }
        public Mission(int id, string name, string descript)
            : this(id, name, descript, Difficulty.Normal, Priority.Medium, null)
        {

        }
        public Mission(int id, string name)
            : this(id, name,MissionText.DefaultDescription, Difficulty.Normal, Priority.Medium, null)
        {

        }
        public Mission(int id)
            : this(id, MissionText.DefaultName, MissionText.DefaultDescription, Difficulty.Normal, Priority.Medium, null)
        {

        }
        #endregion
    }
}
