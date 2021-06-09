using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ekzamen2
{
    class Program
    {
        static void Main(string[] args)
        {

            MyConsole dir = new MyConsole();

            string str = String.Empty;

            while (true)
            {
                str = Console.ReadLine();
                args = str.Split();
                

                switch (args[0])
                {
                    
                    case "help": //last last one 
                        dir.help();
                        break;
                    case "cls": // 5
                        dir.csl();
                        break;
                    case "dir": // 1
                        dir.DirInfo();
                        break;
                    case "cd_file": //2
                        try
                        {
                            dir.trans();
                        }
                        catch
                        {
                            Console.WriteLine("InvalydSyntax");
                        }
                        break;
                    case "copy": //3
                        try
                        {
                            dir.copy(args);
                        }
                        catch
                        {
                            Console.WriteLine("InvalydSyntax");
                        }
                        break;
                    case "del": //8a
                        try
                        {
                            dir.del(args);
                        }
                        catch
                        {
                            Console.WriteLine("InvalydSyntax");
                        }
                        break;
                    case "mkdir": //8b
                        try
                        {
                            dir.mkdir(args);
                        }
                        catch
                        {
                            Console.WriteLine("InvalydSyntax");
                        }
                        break;
                    case "atribute":  //6
                        dir.GetAtribute();
                        break;
                    case "start": //8
                        try
                        {
                            dir.Start(args);
                        }
                        catch
                        {
                            Console.WriteLine("InvalydSyntax");
                        }
                        break;
                    case "search":
                        try
                        {
                            dir.SearchbyPartialName();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case "open": //4a 
                        dir.OpenFile();
                        break;

                }
            }
        }
    }
}
