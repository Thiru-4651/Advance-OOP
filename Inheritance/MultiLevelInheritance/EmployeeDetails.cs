using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLevelInheritance
{
    public class EmployeeDetails : StudentDetails
    {
        private static int s_employeeID = 200;

        public string EmployeeID { get; }
        public string Designation { get; set; }

        public EmployeeDetails(string designation,string userID,string name, string fatherName, Gender gender, long phoneNumber, string standard, int yearOfJoining):base(userID,name,fatherName,gender,phoneNumber,standard,yearOfJoining)
        {
            s_employeeID++;
            EmployeeID = "SD" + s_employeeID;
            Designation=designation;
        }
    }
}