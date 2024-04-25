using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeDetails;

namespace Application
{
    //Static Class

    public static class Operations
    {
        //Global Object Creation
        static StudentDetails currentLoggedInStudent;

        //Static List Creation 

        static List<StudentDetails> StudentList = new List<StudentDetails>();

        public static List<DepartmentDetails> DepartmentList = new List<DepartmentDetails>();

        public static List<AdmissionDetails> AdmissionList = new List<AdmissionDetails>();

        //Main Menu

        public static void MainMenu()
        {
            System.Console.WriteLine("-------------Welcome to the Syncfusion College of Engineering and Technology-------------");

            bool mainFlag = true;
            do
            {

                //Need to show the main menu option

                System.Console.WriteLine("MainMenu: \n1.Student Registration\n2.Student Login\n3.Department wise seat availabilty\n4.Exit");

                //Need to get the input from the user and validate

                System.Console.Write("Enter the option from MainMenu: ");
                int mainOption = int.Parse(Console.ReadLine());


                //Need to create MainMenu Structure
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("**************Student Registration**************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("**************Student Login**************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("**************Department Wise Seat Availabity**************");
                            DepartmentWiseSeatAvailabilty();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("**************Application Exited Successfully**************");
                            mainFlag = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Option :( ");
                            System.Console.WriteLine("You are Reirected MainMenu ");
                            break;
                        }
                }

                //Need to iterate until the option is exit

            } while (mainFlag);
        }

        //Student Registration
        public static void StudentRegistration()
        {
            //Need to get required Details
            System.Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter your Father Name: ");
            string fatherName = Console.ReadLine();

            System.Console.Write("Enter your Date Of Birth (dd/MM/yyy): ");
            DateTime DOB = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            System.Console.Write("Enter your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter your Physics Mark: ");
            int physicsMark = int.Parse(Console.ReadLine());

            System.Console.Write("Enter your Chemistry Mark: ");
            int chemistryMark = int.Parse(Console.ReadLine());

            System.Console.Write("Enter your Maths mark: ");
            int mathsMark = int.Parse(Console.ReadLine());

            //Need to create an Object
            StudentDetails student = new StudentDetails(name, fatherName, DOB, gender, physicsMark, chemistryMark, mathsMark);
            //Need to add the details to the list
            StudentList.Add(student);
            //Need to display the confirmation message and ID
            System.Console.WriteLine($"\nRegistration Successfull:) Student ID is: {student.StudentID}");
        }

        //Student Login
        public static void StudentLogin()
        {
            //Need ask the student ID
            System.Console.Write("Enter your Student ID: ");
            string loginID = Console.ReadLine();

            //check whether it is in the list 
            bool isInside = true;
            foreach (StudentDetails student in StudentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    isInside = false;

                    //Assigning Current user to global variable
                    currentLoggedInStudent = student;
                    System.Console.WriteLine("You are Logged in Successfully :) ");

                    //Need to call SubMenu
                    Submenu();
                    break;
                }

            }
            if (isInside)
            {
                System.Console.WriteLine("Invalid Student ID or ID is not present ");
            }
            //If not print Invalid 
        }//Login ends

        public static void Submenu()
        {
            bool subFlag = true;
            do
            {
                System.Console.WriteLine("******************SubMenu******************");

                //Need to show SubMenu Options
                System.Console.WriteLine("1.Check Eligiblity\n2.Show Details\n3.Take Admission\n4.Cancel Admission\n5.Show Admission Details\n6.Exit");

                //Getting User option
                System.Console.Write("Enter the option from SubMenu: ");
                int subOption = int.Parse(Console.ReadLine());

                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("****************Checking Eligiblity****************");
                            CheckEligibity();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("****************Show Details****************");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("****************Take Admission****************");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("****************Cancel Admission****************");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("****************Show Admission Details****************");
                            ShowAdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("****************You are redirected to the Main Menu****************");
                            subFlag = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Option:( ");
                            System.Console.WriteLine("You Are Redirected to the SubMenu");
                            break;
                        }
                }
                //Iterate till the option is exit

            } while (subFlag);
        }//SubMenu Ends

        //Check Eligliblity
        public static void CheckEligibity()
        {
            //Get the cutoff value as input
            System.Console.WriteLine("Enter the Cutoff Value: ");
            double cutOff = double.Parse(Console.ReadLine());

            //Check the current student is elgible for student admission. if yes -> print eligible
            if (currentLoggedInStudent.CheckEligibity(cutOff))
            {
                System.Console.WriteLine("Student is Eligible :) ");
            }

            //if not -> print not eligible 
            else
            {
                System.Console.WriteLine("Student is not Eligible :( ");
            }
        }//Check Eliglibilty ends

        //Show Details
        public static void ShowDetails()
        {
            //Need to show Current student's details
            System.Console.WriteLine("|StudentID|StudentName|FatherName|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark|");
            System.Console.WriteLine($"|{currentLoggedInStudent.StudentID}\t||{currentLoggedInStudent.StudentName}\t||{currentLoggedInStudent.FatherName}\t||{currentLoggedInStudent.DOB.ToString("dd/MM/yyyy")}\t||{currentLoggedInStudent.Gender}\t||{currentLoggedInStudent.Physics}\t||{currentLoggedInStudent.Chemistry}\t||{currentLoggedInStudent.Maths}\t|");
        }//Show Details ends

        //Take Admission
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentWiseSeatAvailabilty();

            //Ask department ID from user
            System.Console.Write("Select the Department ID: ");
            string departmentID = Console.ReadLine().ToUpper();

            //Check the ID is present or not
            bool flag = true;
            foreach (DepartmentDetails department in DepartmentList)
            {
                if (departmentID.Equals(department.DepartmentID))
                {
                    flag = false;

                    //check the student is eliglible or not
                    if (currentLoggedInStudent.CheckEligibity(75.0))
                    {
                        //check the seat availabality
                        if (department.NumberOfSeats > 0)
                        {
                            //check student already taken a seat
                            int count = 0;
                            foreach (AdmissionDetails admission in AdmissionList)
                            {
                                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if (count == 0)
                            {

                                //Create Admission Object
                                AdmissionDetails admissionTaken = new AdmissionDetails(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);

                                //Reduce seat count
                                department.NumberOfSeats--;

                                //Add to the admission list
                                AdmissionList.Add(admissionTaken);

                                //Display admission successful message
                                System.Console.WriteLine($"Admission took successfully. Your admission ID: {admissionTaken.AdmissionID} ");
                            }
                            else
                            {
                                System.Console.WriteLine("You have already takes an admission :( ");
                            }

                        }
                        else
                        {
                            System.Console.WriteLine("Seats are Not Available :( ");
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("Student is not eligible :( ");
                    }
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid ID or ID not present");
            }

        }//Take Admission ends

        //Cancel Admission
        public static void CancelAdmission()
        {
            //Check the student is taken any admission and display it
            bool flag=true;
            foreach (AdmissionDetails admission in AdmissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    flag=false;
                    //if yes-> Cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;

                    //Return the seat to department
                    foreach(DepartmentDetails department in DepartmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats+=1;
                            System.Console.WriteLine("Admission Canceled Successfully");
                            break;
                        }
                    }
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have not any admission to cancel");
            }


        }//Cancel Admission ends

        //Admission Details
        public static void ShowAdmissionDetails()
        {
            //Need to show current logged in student's admission details
            System.Console.WriteLine("|Student ID|Departmen ID|Admission Date|Admission Status");
            foreach (AdmissionDetails admission in AdmissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    System.Console.WriteLine($"|{admission.StudentID}||{admission.DepartmentID}||{admission.AdmissionDate}||{admission.AdmissionStatus}|");
                }
            }
        }//Admission Details ends


        //Department Wise Seat Availability
        public static void DepartmentWiseSeatAvailabilty()
        {
            //Need to show all department details
            System.Console.WriteLine("_____________________________________________");
            System.Console.WriteLine($"|DepartmentID|Deparment Name|Number of Seats|");
            System.Console.WriteLine("_____________________________________________");
            foreach (DepartmentDetails department in DepartmentList)
            {
                System.Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartmentName,-14}|{department.NumberOfSeats,-15}|");
            }
            System.Console.WriteLine("_____________________________________________");
        }//Department Wise Seat Availability ends

        //Adding Default Datas

        public static void AddingDefaultData()
        {

            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);

            StudentList.AddRange(new List<StudentDetails>() { student1, student2 });

            DepartmentDetails deparment1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails deparment2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails deparment3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails deparment4 = new DepartmentDetails("ECE", 30);

            DepartmentList.AddRange(new List<DepartmentDetails>() { deparment1, deparment2, deparment3, deparment4 });

            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, "DID101", new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), AdmissionStatus.Admitted);

            AdmissionList.AddRange(new List<AdmissionDetails>() { admission1, admission2 });

            //Printing the Default data


            System.Console.WriteLine(); ;



            System.Console.WriteLine();



        }//Adding Default Datas ends
    }
}