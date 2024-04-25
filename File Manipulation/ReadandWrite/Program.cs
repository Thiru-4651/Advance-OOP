using System;
using System.Collections.Generic;
using System.IO;
namespace ReadandWrite
{
    class Program
    {
        static List<Student> studentsList = new List<Student>();

        static string folderName = "TestFolder";
        public static void Main(string[] args)
        {
            
            if (!Directory.Exists(folderName))
            {
                System.Console.WriteLine("Creating the folder");
                Directory.CreateDirectory(folderName);
                // if(Directory.Exists(folderName+"/Data.csv"))
                // {
                    
                // }
            }
            else
            {
                System.Console.WriteLine("Folder already exits");
            }

            //Creating the csv files

            string fileName1 = folderName + "/Data.csv";
            if (!File.Exists(fileName1))
            {
                System.Console.WriteLine("Creating the csv file");
                File.Create(fileName1);
            }
            else
            {
                System.Console.WriteLine("csv File already exits");
            }

            //Creating the json files

            string fileName2 = folderName + "/Data1.json";
            if (!File.Exists(fileName2))
            {
                System.Console.WriteLine("Creating the json file");
                File.Create(fileName2);
            }
            else
            {
                System.Console.WriteLine("json File already exits");
            }


            studentsList.Add(new Student() { Name = "Thiru", FatherName = "Dhanapal", Gender = Gender.Male, DOB = new DateTime(2002, 12, 12), Marks = 473 });
            studentsList.Add(new Student() { Name = "Santhosh", FatherName = "Sekar", Gender = Gender.Male, DOB = new DateTime(2002, 02, 23), Marks = 480 });
            studentsList.Add(new Student() { Name = "Kiruba", FatherName = "Dhanapal", Gender = Gender.Male, DOB = new DateTime(2005, 04, 13), Marks = 419 });

            WriteCSV(studentsList);
            ReadCSV();

        }
        static void WriteCSV(List<Student> List)
        {
            StreamWriter sw = new StreamWriter(folderName + "/Data.csv");

            foreach (Student Student in List)
            {
                string line = Student.Name + "," + Student.FatherName + "," + Student.Gender + "," + Student.DOB.ToString("dd/MM/yyyy") + "," + Student.Marks;
                sw.WriteLine(line);
            }
            sw.Close();
        }

        static void ReadCSV()
        {
            StreamReader sr = new StreamReader(folderName + "/Data.csv");

            List<Student> newLocalList = new List<Student>();

            string Line = sr.ReadLine();

            while (Line != null)
            {
                string[] values = Line.Split(",");

                if (values[0] != "")
                {
                    Student student = new Student()
                    {
                        Name = values[0],
                        FatherName = values[1],
                        Gender = Enum.Parse<Gender>(values[2]),
                        DOB = DateTime.ParseExact(values[3], "dd/MM/yyyy", null),
                        Marks = int.Parse(values[4])
                    };
                    newLocalList.Add(student);
                }
                Line = sr.ReadLine();
            }
            sr.Close();
            // studentsList.AddRange(newLocalList);
            foreach (Student student in newLocalList)
            {
                System.Console.WriteLine($"Name: {student.Name}\nFather Name: {student.FatherName}\nGender: {student.Gender}\nDOB: {student.DOB.ToString("dd/MM/yyyy")}\nMarks: {student.Marks}");
                System.Console.WriteLine();
            }
        }
    }
}