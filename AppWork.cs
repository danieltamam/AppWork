using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Properties
{
    public  class AppWork
    {
        private IList<Employee> _employees;//private field
        public IList<Employee> Employees
        {
            get { return this._employees; }
            set
            {
                foreach(var employee in value)
                {
                    if (string.IsNullOrEmpty(employee.Name) || employee.Id < 0 || employee.Id.ToString().Length != 8)
                        throw new ArgumentNullException("the employee must be contain legall info!");
                }//end foreach
                _employees = value;
            }
        }

        private IList<Task> _tasks;//private field
        public IList<Task> Tasks
        {
            get { return this._tasks; }
            set { if (value == null) throw new ArgumentNullException("task list has to be list ");_tasks = value; }
        }

        private IDictionary<Task, DoingTask> _doingTasks;//dictionary shows all the employees that doing task and what task they do
        public IDictionary<Task, DoingTask> DoingTasks
        {
            get { return _doingTasks; }
            set
            {
                foreach(var doingTask in value.Values)
                {
                    if (string.IsNullOrEmpty(doingTask.Employee.Name) || doingTask.Employee.Id < 0 || doingTask.Employee.Id.ToString().Length != 8)
                        throw new ArgumentNullException("one of your doing tasks is illegal, sorry can't deal with that");
                }//end foreach
                _doingTasks = value;
            }
        }

        public AppWork(IList<Employee> employees, IList<Task> tasks, IDictionary<Task, DoingTask> doingTasks)//ctor
        {
            Employees = employees;
            Tasks = tasks;
            DoingTasks = doingTasks;
        }

        public void PickRandomEmployeeForRandomTaskAndAddedToTheDic()//this function pick for the user one random employee for the task and added it to the DB 
        {
            int count = 0;
            foreach(var doingTask in DoingTasks.Values)
            {
                if (count == 0)
                {
                    foreach (var e in _employees)
                    {
                        if (!doingTask.Employee.Equals(e))//check if the employee is not doing task
                        {
                            Random rnd = new Random();//create a random object to do the method for employee
                            int employeesIndex = rnd.Next(this._employees.Count);
                            Employee employee = this._employees[employeesIndex];//the random employee is picked

                            Random rnd2 = new Random();//create a random object to do the method for task
                            int TasksIndex = rnd2.Next(this._tasks.Count);
                            Task task = this._tasks[TasksIndex];//the random task is picked
                            DoingTasks[task] = new DoingTask(DateTime.Now, employee);
                            count++;//help me to finish all the loops
                            break;//finish the loop then finish the first loop
                        }
                    }
                }
                else
                    break;//finish the loop
            }
        }
        public void FinishTask(Task task)//this task just update the DB and shows to the user that the employee has finished his task
        {
            _doingTasks.Remove(task);
        } 
        public IList<Employee> GetAllTheEmployeesThatAreInTaskMoreThanXMintues(double X)//insert the time he wants
        {
            List<Employee> employees = new List<Employee>();
            foreach(var employee in _doingTasks.Values)
            {
                if (((DateTime.Now) - (employee.TaskTime)).TotalMinutes > X)//check the time every employee did task
                {
                    employees.Add(employee.Employee);
                }
            } //end foreach
            return employees;
        }

        public override string ToString()
        {
            return $"employees:{string.Join(" , ", _employees)}\ntasks:{string.Join(" , ", _tasks)}\ndoing task:{string.Join(" , ", _doingTasks)}";
        }

        public override bool Equals(object obj)
        {
            return obj is AppWork work &&
                   EqualityComparer<IList<Employee>>.Default.Equals(_employees, work._employees) &&
                   EqualityComparer<IList<Task>>.Default.Equals(_tasks, work._tasks) &&
                   EqualityComparer<IDictionary<Task, DoingTask>>.Default.Equals(_doingTasks, work._doingTasks);
        }

        public override int GetHashCode()
        {
            int hashCode = 1912066760;
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Employee>>.Default.GetHashCode(_employees);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Task>>.Default.GetHashCode(_tasks);
            hashCode = hashCode * -1521134295 + EqualityComparer<IDictionary<Task, DoingTask>>.Default.GetHashCode(_doingTasks);
            return hashCode;
        }
    }
}
