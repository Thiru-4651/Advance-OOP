using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadandWrite
{
    public enum Gender{Male,Female}
    public class Student
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Marks { get; set; }
    }
}