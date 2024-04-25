using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeDetails
{
    public class DepartmentDetails
    {

        // Properties

        private static int s_departmentID=100;

        public string DepartmentID { get; }

        public string DepartmentName { get; set; }

        public int NewOne { get; set; }

        public int NumberOfSeats { get; set; }

        //Constructor

        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            //Auto Increament
            s_departmentID++;

            //Assiging values to the properties

            DepartmentID="DID"+s_departmentID;

            DepartmentName=departmentName;
            
            NumberOfSeats=numberOfSeats;
        }

    }
}