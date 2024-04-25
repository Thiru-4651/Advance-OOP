using System;
namespace HierachicalInheritance;
class Program
{
    public static void Main(string[] args)
    {
        //Personal Details Object
        PersonalDetails personal = new PersonalDetails("Thiru", "Dhanapal", Gender.Male, 9894583822);
        System.Console.WriteLine($"UserID: {personal.UserID}\nName: {personal.Name}\nFatherName: {personal.FatherName}\nGender: {personal.Gender}\nPhoneNumber: {personal.PhoneNumber}");

        //Student details object
        StudentDetails student = new StudentDetails(personal.UserID,personal.Name, personal.FatherName, personal.Gender, personal.PhoneNumber, "10th", 2017);
        //System.Console.WriteLine($"Name: {student.Name}\nFather Name: {student.FatherName}");

        //Customer Details Object

        CustomerDetails customer=new CustomerDetails(personal.UserID,personal.Name,personal.FatherName,personal.Gender,personal.PhoneNumber,300);
        System.Console.WriteLine($"A{customer.UserID}\n{customer.Name}\n{customer.FatherName}\n{customer.Gender}\n{customer.PhoneNumber}\n{customer.Balance}");
    }
}