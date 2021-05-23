using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileOperation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to File System Manager");

            string command = Console.ReadLine();

            FileSystem fs = new FileSystem();

            while(!command.ToLower().Contains("exit"))
            {
                string cmd = command.Split(' ')[0];
                string parameter = string.Empty;

                if (command.Split(' ').Length > 1)
                {
                    parameter = command.Split(' ')[1];
                }
                
                switch (cmd)
                {
                    case "md":
                        fs.MD(parameter);
                        break;
                    case "mf":
                        fs.MF(parameter);
                        break;
                    case "cd":
                        fs.CD(parameter);
                        break;
                    case "dir":
                        fs.DIR(parameter);
                        break;
                    case "file":
                        fs.FILE(parameter);
                        break;
                    case "diro":
                        fs.DIRO(parameter);
                        break;
                    case "help":
                        fs.Help();
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }

                Console.WriteLine();
                command = Console.ReadLine();

            }

        }
    }
}
