using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Properties
{
    public class Task
    {
        //private Employee _employee;//private field
        //public Employee Employee
        //{
        //    get { return _employee; }
        //    set { if (value==null||string.IsNullOrEmpty(value.Name) || value.Id < 0 || value.ToString().Length != 8) throw new ArgumentNullException("the name and the id of the employee must be leggal");_employee = value; }
        //}
        //private DateTime _TaskTime;
        //public DateTime DateTime
        //{
        //    get { return this._TaskTime; }
        //    set { if (value == null) throw new FieldAccessException("date must be contain date"); this._TaskTime = value; }
        //}
        private TaskType _type;
        public TaskType Type
        {
            get { return this._type; }//private field
            set { this._type = value; }//it without condition because it is enum that i set
        }

        public Task(TaskType type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Tasktype:{_type}"; 
        }

        public override bool Equals(object obj)
        {
            return obj is Task task &&
                   _type == task._type;
        }

        public override int GetHashCode()
        {
            return -331038658 + _type.GetHashCode();
        }
    }
}
