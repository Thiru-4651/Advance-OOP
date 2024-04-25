using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeDetails
{
    //Enum

    /// <summary>
    /// Enum Gender used to create a instance for Student <see cref="StudentAdmission"/> 
    /// </summary>
    public enum Gender { Select, Male, Female, Transgender }
    public class StudentDetails
    {
       
        //Properties

        private static int s_studentID = 3000;

        public string StudentID { get; }  //Read only

        public string StudentName { get; set; }

        public string FatherName { get; set; }

        public DateTime DOB { get; set; }

        public Gender Gender { get; set; }

        public int Physics { get; set; }

        public int Chemistry { get; set; }

        public int Maths { get; set; }

        //Constructor

        public StudentDetails(string studentName, string fatherName, DateTime dOB, Gender gender, int physics, int chemistry, int maths)
        {
            //Auto Incrementation
            s_studentID++;

            //Assigining values to the Property

            StudentID = "SF" + s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dOB;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }

        //Method 1

        public double Average()
        {
            int total = Physics + Chemistry + Maths;

            double average = (double)total / 3;

            return average;
        }

        //Method 2
        public bool CheckEligibity(double cutOff)
        {

            if (Average() >= cutOff)
            {
                return true;
            }
            return false;
        }
    }
}