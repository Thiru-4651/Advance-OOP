//For using the directory and file Manipulation
using System.IO;
using System;
using System.Runtime.ConstrainedExecution;
namespace FilesFolders;
class Program
{
    public static void Main(string[] args)
    {
        string path = @"C:\Users\ThirunavukkarasuDhan\OneDrive - Syncfusion\Desktop\Myfolder";

        string folderPath = path + "/thiru";

        if (!Directory.Exists(folderPath))
        {
            System.Console.WriteLine("Creating the folder...");
            Directory.CreateDirectory(folderPath);
        }
        else
        {
            System.Console.WriteLine("File already exits....");
        }

        string filepath = path + "/textfile" + ".txt";

        if (!File.Exists(filepath))
        {
            System.Console.WriteLine("Creating the file...");
            File.Create(filepath);
        }
        else
        {
            System.Console.WriteLine("Already Exits..");
        }

        System.Console.WriteLine("1.Create folder   2.Create file   3.Delete file   4.Delete folder");
        System.Console.WriteLine("Enter the option");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                {
                    System.Console.WriteLine("Enter the folder name to create");
                    string folderName=Console.ReadLine();
                    if(!Directory.Exists($"{path}/{folderName}"))
                    {
                        System.Console.WriteLine("Creating the folder");
                        Directory.CreateDirectory($"{path}/{folderName}");
                    }
                    else
                    {
                        System.Console.WriteLine("Folder already exits");
                    }
                    break;
                }
            case 2:
                {
                    System.Console.WriteLine("Enter the new file name with extension");
                    string fileName=Console.ReadLine();
                    string filepathcration=path+"/"+fileName;
                    if(!File.Exists(filepathcration))
                    {
                        System.Console.WriteLine("Creating the file");
                        File.Create(filepathcration);
                    }
                    else
                    {
                        System.Console.WriteLine("File Already created");
                    }
                    break;
                }
            case 3:
                {
                    foreach (string files in Directory.GetFiles(path))
                    {
                        System.Console.WriteLine(files);
                    }
                    System.Console.WriteLine("Enter the file name to delete(With extension)");
                    string fileName=Console.ReadLine();

                    foreach (string files in Directory.GetFiles(path))
                    {
                        if(files.Contains(fileName))
                        {
                            System.Console.WriteLine("File deleted successfully");
                            File.Delete(files);
                        }                        
                    }
                    break;
                }
            case 4:
                {
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        System.Console.WriteLine(folder);
                    }
                    System.Console.WriteLine("Enter the folder name to delete");
                    string folderName=Console.ReadLine();
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        if(folder.Contains(folderName))
                        {
                            Directory.Delete(folder);
                            System.Console.WriteLine("Folder deleted successfully");
                            break;
                        }
                    }
                    break;
                }
        }
    }
}