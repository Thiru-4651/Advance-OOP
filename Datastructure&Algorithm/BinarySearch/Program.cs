using System;
namespace BinarySearch;
class Program 
{
    public static void Main(string[] args)
    {
        int [] values={12,13,21,10,8,11,9};
        Array.Sort(values);
        int position=BinarySearch(values,100);
        if(position>-1)
        {
            System.Console.WriteLine("Element is found");
        }
        else
        {
            System.Console.WriteLine("Element is not found");
        }
    }
    static int BinarySearch(int []values,int searchElement)
    {
        int left=0;
        int right=values.Length-1;
        while(left<=right)
        {
            int middle=left+((right-left)/2);
            if(values[middle]==searchElement)
            {
                return middle;
            }
            else if(values[middle]<searchElement) //if the search element is greater
            {
                //Search the right half by changing value of the left
                left=middle+1;
            }
            else
            {
                //If the element is less than middele then seach in the left half by changing the value of right
                right=middle-1;
            }
        }
        return -1;
    }
}