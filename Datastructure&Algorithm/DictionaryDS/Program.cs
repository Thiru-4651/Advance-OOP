using System;
using DictionaryDS;
using System.Collections.Generic;
namespace Dictionary;
class Program 
{
    public static void Main(string[] args)
    {
        CustomDictionary<string,string> mydictionary=new CustomDictionary<string,string>();
        mydictionary.Add("SF3001","Thiru");
        mydictionary.Add("SF3002","Santosh");
        mydictionary.Add("SF3002","kiruba");
        mydictionary.Add("SF3004","Arasu");

        foreach (KeyValue<string,string>data in mydictionary)
        {
            System.Console.WriteLine("Key: "+data.Key+"\n"+"Value: "+data.Value);
        }

        mydictionary["SF3001"]="Thiruna";
        string name=mydictionary["SF3001"];

        System.Console.WriteLine("Name is: "+name);

        


    }
}