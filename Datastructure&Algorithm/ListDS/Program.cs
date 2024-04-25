using System;
using System.Collections.Generic;

namespace ListDS;
class Program 
{
    public static void Main(string[] args)
    {
        CustomList<int> numberList =new CustomList<int>();
        
        //Add Method
        numberList.Add(10);
        numberList.Add(20);
        numberList.Add(30);
        numberList.Add(40);
        numberList.Add(50);
        CustomList<int> numebers=new CustomList<int>();
        numebers.Add(60);
        numebers.Add(70);

        //AddRange Method
        numberList.AddRange(numebers);

        //Contains Methohd
        System.Console.WriteLine(numberList.Contains(40));
        
        //IndexOf Method
        System.Console.WriteLine(numberList.IndexOf(20));

        //Insert Method
        numberList.Insert(2,50);
        
        //RemoveAt method
        numberList.RemoveAt(2);
        
        //Remove Method
        bool temp=numberList.Remove(60);

        //Reverse Method
        numberList.Reverse();

        //InsertRange Method
        numberList.InsertRange(2,numebers);

        //Sort Method
        numberList.Sort();

        foreach(int value in numberList)
        {
            System.Console.WriteLine(value);
        }

    }
}