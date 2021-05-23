using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileOperation
{
    public class FileSystem
    {
        readonly File root;

        File currentRoot;

        public FileSystem()
        {
            root = new File("/",true);
            currentRoot = root;

        }

        public string GetCurrentDirName()
        {
            return currentRoot.Name;
        }

        public void MD(string directoryName)
        {
            // Can not Create a File
            if (!currentRoot.IsDirectory) return;

            if (currentRoot.Child == null)
            {
                currentRoot.Child = new File(directoryName, true);
                currentRoot.Child.Parent = currentRoot;
                return;
            }

            File tempDir = currentRoot.Child;

            while(tempDir.Sibling != null)
            {
                tempDir = tempDir.Sibling;
            }
            tempDir.Sibling = new File(directoryName, true);

            tempDir.Sibling.Parent = currentRoot;
        }


        public void MF(string fileName)
        {
            // Can not Create a File
            if (!currentRoot.IsDirectory) return;

            if (currentRoot.Child == null)
            {
                currentRoot.Child = new File(fileName, false);
                currentRoot.Child.Parent = currentRoot;
                return;
            }

            File tempDir = currentRoot.Child;

            while (tempDir.Sibling != null)
            {
                tempDir = tempDir.Sibling;
            }
            tempDir.Sibling = new File(fileName, false);

            tempDir.Sibling.Parent = currentRoot;
        }
        

        public void CD(string path)
        {
            if(path.Equals(".."))
            {
                if (currentRoot.Parent != null)
                    currentRoot = currentRoot.Parent;
            }
            else
            {
                File tempDir = currentRoot.Child;

                while(!tempDir.Name.Equals(path))
                {
                    tempDir = tempDir.Sibling;
                }

                if (tempDir != null && tempDir.Name.Equals(path))
                {
                    if(!tempDir.IsDirectory)
                    {
                        Console.WriteLine($"{path} is not a Directory");
                    }
                    else
                    currentRoot = tempDir;
                }

                if(tempDir == null)
                {
                    Console.WriteLine($"{path} Directory not available");
                }
            }
        }

        public void DIR(string options = "")
        {
            if(options.Equals(""))
            {
                File tempDir = currentRoot.Child;

                while(tempDir != null)
                {
                    Console.WriteLine(tempDir.Name);
                    tempDir = tempDir.Sibling;
                }
            }
            else if(options.Equals("/s"))
            {
                PrintAllDir(currentRoot.Child);
            }            
        }

        public void DIRO(string options = "")
        {
            if (options.Equals(""))
            {
                File tempDir = currentRoot.Child;

                while (tempDir != null)
                {
                    if(tempDir.IsDirectory)
                    Console.WriteLine(tempDir.Name);
                    tempDir = tempDir.Sibling;
                }
            }
            else if (options.Equals("/s"))
            {
                PrintAllDirO(currentRoot.Child);
            }


        }

        public void FILE(string options = "")
        {
            if (options.Equals(""))
            {
                File tempDir = currentRoot.Child;

                while (tempDir != null)
                {
                    if(!tempDir.IsDirectory)
                    Console.WriteLine(tempDir.Name);
                    tempDir = tempDir.Sibling;
                }
            }
            else if (options.Equals("/s"))
            {
                PrintAllFile(currentRoot.Child);
            }
        }

        public void Help()
        {

            Console.WriteLine(" << File System Help Page>>");
            Console.WriteLine("   md <Directory Name> : Used to Create Directroy");
            Console.WriteLine("   mf <File Name> : Used to Create File");
            Console.WriteLine("   cd <Directory Name> : Change to next Directory");
            Console.WriteLine("   cd .. : Change to parent Directory");
            Console.WriteLine("   dir : List item from current directory");
            Console.WriteLine("   dir \\s: List item from current directory and sub directory");
            Console.WriteLine("   exit : To exit from the program");

        }

        private void PrintAllDir(File dir)
        {
            if (dir == null) return;

            Console.WriteLine(dir.Name);

            PrintAllFile(dir.Sibling);

            PrintAllFile(dir.Child);
        }


        private void PrintAllDirO(File dir)
        {
            if (dir == null) return;

            if(dir.IsDirectory)
            Console.WriteLine(dir.Name);

            PrintAllFile(dir.Sibling);

            PrintAllFile(dir.Child);
        }

        private void PrintAllFile(File dir)
        {
            if (dir == null) return;

            if(!dir.IsDirectory)
            Console.WriteLine(dir.Name);

            PrintAllFile(dir.Sibling);

            PrintAllFile(dir.Child);
        }
    }
}
