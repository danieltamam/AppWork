using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Properties
{
    public class Employee
    {
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("name cant be empty");_name=value; }
        }
        private int _id;
        public int Id
        {
            get { return this._id; }
            set { if (value < 0 || value.ToString().Length!=8) throw new ArgumentNullException("id must be possitive number and has to contain 8 figurs!");_id = value; }
        }

        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return $"name:{_name}\nid:{_id}";
        }

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   _name == employee._name &&
                   _id == employee._id;
        }

        public override int GetHashCode()
        {
            int hashCode = -2015382392;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            return hashCode;
        }
    }
}
