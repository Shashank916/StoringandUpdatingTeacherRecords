using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoringandUpdatingTeacherRecords
{
    public  class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public Teacher(int id, string name, string className, string section)
        {
            ID = id;
            Name = name;
            Class = className;
            Section = section;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Class: {Class}, Section: {Section}";
        }
    }
}
