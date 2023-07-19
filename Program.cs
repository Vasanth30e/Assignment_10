using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fileOperation;
            Console.WriteLine("Enter the Operation you wnat to perform: ");
            fileOperation = int.Parse(Console.ReadLine());

            switch (fileOperation)
            {
                case 1:
                    Console.WriteLine("\n---Creation---\n");
                    Console.WriteLine("Enter the File Path");
                    string filePath = Console.ReadLine();   
                    Console.WriteLine("Enter the file name you want to create");
                    string fName = Console.ReadLine();
                    CreateFile(filePath, fName);
                    break;
                case 2:
                    Console.WriteLine("\n---Read Operation---\n");
                    Console.WriteLine("Enter the File Path");
                    string fPathRead = Console.ReadLine();
                    Console.WriteLine("Enter the file name you want to read");
                    string fNameRead = Console.ReadLine();
                    ReadFile(fPathRead, fNameRead); 
                    break;
                case 3:
                    Console.WriteLine("\n---Append Operation---\n");
                    Console.WriteLine("Enter the file path");
                    string fpathAppend = Console.ReadLine();
                    Console.WriteLine("Enter the file name you want to add text");
                    string fNameAppend = Console.ReadLine();
                    Console.WriteLine("Enter the content");
                    string contentToAppend = Console.ReadLine();
                    AppendToFile(fpathAppend, fNameAppend, contentToAppend);
                    break;
                case 4:
                    Console.WriteLine("\n---Delete Operation---");
                    Console.WriteLine("Enter the file path");
                    string fpathDelete = Console.ReadLine();
                    Console.WriteLine("Enter the file name you want to delete");
                    string fNameDelete = Console.ReadLine();
                    DeleteFile(fpathDelete, fNameDelete);
                    break;
                default:
                    Console.WriteLine("File Operation is not exists");
                    break;
            }

            Console.ReadKey();

        }        
        
        static public void CreateFile(string path, string fName)
        {                      
            string fPath = path + fName;

            if (File.Exists(fPath))
            {
                Console.WriteLine("File is already exists");
            }
            else 
            { 
                File.Create(fPath);
                Console.WriteLine("File is Created Successfully");
            }
        }

        static public void ReadFile(string path,string fName)
        {

            string fPath = path + fName;

            if (File.Exists(fPath))
            {
                string[] lines = File.ReadAllLines(fPath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("The File does not exists");
            }
        }

        static public void AppendToFile(string path, string fName, string content)
        {


            string fPath = path + fName;

            if (File.Exists(fPath))
            {
                Console.WriteLine(content);
            }
            else
            {
                StreamWriter sw = File.AppendText(fPath);
                sw.WriteLine(content);

                sw.Dispose();
                sw.Close();

                Console.WriteLine("Text is written in the file");
            }
        }

        static public void DeleteFile(string path, string fName)
        {          
            string fPath = path + fName;

            if (!File.Exists(fPath))
            {
                Console.WriteLine("File name you entered is not in the folder");
            }
            else
            {
                File.Delete(fPath);
                Console.WriteLine("File Deleted!");
            }
        }
    }
}
