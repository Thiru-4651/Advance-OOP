using System;
namespace LinearSearch;
class Program 
{
    public static void Main(string[] args)
    {
        int [] values={12,24,14,19,32,34,45,09,23,212};
        int position=LinearSearch(values,19);
        if(position>-1)
        {
            System.Console.WriteLine("Element is found "+position);
        }
        else
        {
            System.Console.WriteLine("Element is not found");
        }

    }
    public static int LinearSearch(int[]values,int searchElement)
    {
        int position=-1;
        for(int i=0;i<values.Length;i++)
        {
            if(values[i].Equals(searchElement))
            {
                position=i;
                break;
            }
        }
        return position;
    }
}