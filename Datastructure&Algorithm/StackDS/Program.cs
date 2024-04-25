using System;
namespace StackDS;
class Program 
{
    public static void Main(string[] args)
    {
        CustomStack<int>myStack=new CustomStack<int>();

        myStack.Push(11);
        myStack.Push(12);
        myStack.Push(13);
        myStack.Push(14);
        myStack.Push(15);

        System.Console.WriteLine(myStack.Peek());

        System.Console.WriteLine(myStack.Pop());
        System.Console.WriteLine(myStack.Pop());
        System.Console.WriteLine(myStack.Pop());
        System.Console.WriteLine(myStack.Pop());
        System.Console.WriteLine(myStack.Pop());
        System.Console.WriteLine(myStack.Pop());        //Empty Stack retruns the default value

    }
}