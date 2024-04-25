using System;
namespace SingleInheritance;
class Program
{
    public static void Main(string[] args)
    {
        //Personal Details Object
        PersonalDetails personal = new PersonalDetails("Thiru", "Dhanapal", Gender.Male, 9894583822);
        //System.Console.WriteLine($"UserID: {personal.UserID}\nName: {personal.Name}\nFatherName: {personal.FatherName}\nGender: {personal.Gender}\nPhoneNumber: {personal.PhoneNumber}");

        //Student details object
        StudentDetails student = new StudentDetails(personal.UserID,personal.Name, personal.FatherName, personal.Gender, personal.PhoneNumber, "10th", 2017);
        System.Console.WriteLine($"User ID: {student.UserID}\nName: {student.Name}\nFather Name: {student.FatherName}\nGender: {student.Gender}\nPhone Number: {student.PhoneNumber}\nStandard: {student.Standard}\nYearOfJoining: {student.YearOfJoining}");
    }
}