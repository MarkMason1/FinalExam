using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzamen2
{
    class MyConsole
    {
        private DirectoryInfo dir;
        public MyConsole()
        {
            dir = new DirectoryInfo(".");
        }

        public void csl()
        {
            Console.Clear();
        }
        public void help()
        {
            Console.WriteLine("cls to clear console"); //5
            Console.WriteLine("dir to see containing"); //1
            Console.WriteLine("<cd_file> move the file "); //2 file
            Console.WriteLine("copy + folder name to copy"); //3
            Console.WriteLine("del + folder name to delete"); //8
            Console.WriteLine("mkdir + folder name to create");
            Console.WriteLine("start + folder name to create");
            Console.WriteLine("<open> file name");
            Console.WriteLine("<search> for a file"); //9
            Console.WriteLine("attr + name"); //6
        }

        public void DirInfo()
        {
            Console.WriteLine($"{"Name",-15}      {"Time",-10}       Length");
            foreach (var d in dir.GetDirectories())
            {
                Console.WriteLine($"{d.Name,-15}  DIR {d.CreationTime.ToShortTimeString(),-10}");
            }
            foreach (var f in dir.GetFiles())
            {
                Console.WriteLine($"{f.Name,-15} {f.Extension,4} {f.CreationTime.ToShortTimeString(),-10} {f.Length / 1024.0:0.00} KB");
            }
        }

        /*public void Cd(string[] args)
        {
            dir = new DirectoryInfo(args[1]);
            Directory.SetCurrentDirectory(args[1]);
        }*/
        public void trans() //2 file
        {
            string rootFolderPath = @"C:\Users\mark2\RiderProjects\Test4Project2\Test4Project2\mark.txt";
            string destinationPath = @"C:\Users\mark2\RiderProjects\Test4Project2\Test4Project2\Properties\mark.txt";
            if (File.Exists(rootFolderPath))
            {
                using (FileStream fs = File.Create(rootFolderPath)){}
                
            }

            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }
            File.Move(rootFolderPath,destinationPath);
            Console.WriteLine("{0} was moved to {1}.", rootFolderPath, destinationPath);

            if (File.Exists(rootFolderPath))
            {
                Console.WriteLine("The process failed ");
            }
            else
            {
                Console.WriteLine("The process was a success ");
            }
        }

        public void copy( string[] args)
        {
            dir = new DirectoryInfo(args[1]);
            DirectoryInfo destination = new DirectoryInfo(args[2]);
            if (!System.IO.Directory.Exists(destination.Name))
            {
                System.IO.Directory.CreateDirectory(destination.Name);
            }
            String[] files = Directory.GetFiles(dir.Name);
            String[] directories = Directory.GetDirectories(dir.Name);
            foreach (string s in files)
            {
                File.Copy(s, Path.Combine(destination.Name, Path.GetFileName(s)), true);
            }
            foreach (string d in directories)
            {
                Directory.Move(Path.Combine(dir.Name, Path.GetFileName(d)), Path.Combine(destination.Name, Path.GetFileName(d)));
            }
        }

        public void del(string[] args)
        {
            dir = new DirectoryInfo(args[1]);
            dir.Delete();
        }

        public void mkdir(string[] args)
        {
            dir = new DirectoryInfo(args[1]);
            dir.CreateSubdirectory("New folder");
        }
        
        public void SearchbyPartialName()
        {
            Console.WriteLine("VVV look for a file with a partial name VVV");
            string partialName = Console.ReadLine();
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\mark2\RiderProjects\Regex");
            var searchByPartialName = dir.EnumerateFiles("*" + partialName + "*.*", SearchOption.AllDirectories)
                .ToList();
            if (searchByPartialName.Capacity == 0)
            {
                Console.WriteLine("No file with such name was created");
            }
            else
            {
                foreach (var z in searchByPartialName)
                {
                    Console.WriteLine($"full name: {z.FullName} \t Creation time: {z.CreationTime}");
                }
            }
        }
        
        public void GetAtribute()
        {
            string name;
            name = Console.ReadLine();
            Console.WriteLine( File.GetAttributes($"{name}.txt"));
        }
        public void Start(string[] args)
        {
            Process.Start(args[1]);
        }
        public void OpenFile()
        {
            try
            {
                string name;
                name = Console.ReadLine();
                string line;
                StreamReader sr = new StreamReader(name);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
