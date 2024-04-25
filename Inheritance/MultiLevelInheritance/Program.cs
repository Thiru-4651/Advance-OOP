using System;
namespace MultiLevelInheritance;
class Program
{
    public static void Main(string[] args)
    {
        //Personal Details Object
        PersonalDetails personal = new PersonalDetails("Thiru", "Dhanapal", Gender.Male, 9894583822);
        System.Console.WriteLine($"UserID: {personal.UserID}\nName: {personal.Name}\nFatherName: {personal.FatherName}\nGender: {personal.Gender}\nPhoneNumber: {personal.PhoneNumber}");

        //Student details object
        StudentDetails student = new StudentDetails(personal.UserID,personal.Name, personal.FatherName, personal.Gender, personal.PhoneNumber, "10th", 2017);
        System.Console.WriteLine($"Name: {student.Name}\nFather Name: {student.FatherName}");

        EmployeeDetails employee=new EmployeeDetails("Software Engineer",student.UserID,student.Name,student.FatherName,student.Gender,student.PhoneNumber,student.Standard,student.YearOfJoining);
    }
}