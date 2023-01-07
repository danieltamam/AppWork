using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Properties
{
    public class DoingTask
    {
        private DateTime _taskTime;
        public DateTime TaskTime
        {
            get { return _taskTime; }
            set { if (value == null) throw new ArgumentNullException("time can't be null"); _taskTime = value; }
        }
        private Employee _employee; //private field
        public Employee Employee
        {
            get { return _employee; }
            set { if (value == null || string.IsNullOrEmpty(value.Name) || value.Id < 0 || value.ToString().Length != 8) throw new ArgumentNullException("the name and the id of the employee must be leggal"); _employee = value; }
        }

        public DoingTask(DateTime taskTime, Employee employee)// there are props in the ctor that allowes to set only legall info
        {
            TaskTime = taskTime;
            Employee = employee;
        }

        public override string ToString()
        {
            return $"employee:{_employee}\n did this task on {_taskTime}";//gives info and date for every employee(when he did the task)
        }

        public override bool Equals(object obj)
        {
            return obj is DoingTask task &&
                   _taskTime == task._taskTime &&
                   EqualityComparer<Employee>.Default.Equals(_employee, task._employee);
        }

        public override int GetHashCode()
        {
            int hashCode = -1225114044;
            hashCode = hashCode * -1521134295 + _taskTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Employee>.Default.GetHashCode(_employee);
            return hashCode;
        }
    }
}
