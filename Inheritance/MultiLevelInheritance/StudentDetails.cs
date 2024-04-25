using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLevelInheritance
{
    public class StudentDetails : PersonalDetails
    {
        private static int s_studentID = 200;

        public string StudentID { get; }
        public string Standard { get; set; }
        public int YearOfJoining { get; set; }

        public StudentDetails(string userID,string name, string fatherName, Gender gender, long phoneNumber, string standard, int yearOfJoining) : base(userID,name, fatherName, gender, phoneNumber)
        {
            s_studentID++;
            StudentID = "SD" + s_studentID;
            Standard = standard;
            YearOfJoining = yearOfJoining;
        }

        public StudentDetails(string studentID,string userID,string name, string fatherName, Gender gender, long phoneNumber, string standard, int yearOfJoining) : base(userID,name, fatherName, gender, phoneNumber)
        {
            StudentID = studentID;
            Standard = standard;
            YearOfJoining = yearOfJoining;
        }

        
    }

}