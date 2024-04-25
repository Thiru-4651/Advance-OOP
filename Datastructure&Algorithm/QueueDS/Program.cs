using System;
namespace QueueDS;
class Program 
{
    public static void Main(string[] args)
    {
        CustomQueue<int>myQueue=new CustomQueue<int>();
        
        //Enqueue
        myQueue.Enqueue(11);
        myQueue.Enqueue(12);
        myQueue.Enqueue(13);
        myQueue.Enqueue(14);
        myQueue.Enqueue(15);

        foreach (int value in myQueue)
        {
            System.Console.WriteLine("Value: "+value);
        }
        System.Console.WriteLine();
        
        //Peek
        System.Console.WriteLine(myQueue.Peek());
        
        System.Console.WriteLine();

        //Dequeue
        System.Console.WriteLine(myQueue.Dequeue());
        System.Console.WriteLine(myQueue.Dequeue());
        System.Console.WriteLine(myQueue.Dequeue());
        System.Console.WriteLine(myQueue.Dequeue());
        System.Console.WriteLine(myQueue.Dequeue());
        System.Console.WriteLine(myQueue.Dequeue());        //Empty Queue Returns default data


    }
}