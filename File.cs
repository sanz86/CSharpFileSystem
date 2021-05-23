using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileOperation
{
    public class File
    {
        public string Name { get; set; }

        public bool IsDirectory { get; set; }

        public File Sibling { get; set; }

        public File Child { get; set; }

        public File Parent { get; set; }

        public File(string name, bool isDirectory)
        {
            Name = name;
            IsDirectory = isDirectory;

            Sibling = null;
            Child = null;
        }
    }
}
