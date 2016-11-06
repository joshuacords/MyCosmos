using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosOperatingSystem
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted. Adding components...");
            _components = new List<CoreComponent>();
            _components.Add(new CoreComponent());
            Console.WriteLine("Components ready. Booting complete.");
        }

        //protected override void Run()
        //{
        //    Console.Write("Ready: ");
        //    string input = Console.ReadLine();

        //    char[] delimiterChars = { ' ', ',', '\n' };

        //    string[] cmd = input.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

        //    switch (cmd[0])
        //    {
        //        case "echo": echo(cmd);
        //            break;
        //        default: Console.WriteLine("No such command " + cmd[0]);
        //            break;
        //    }
        //}

        //private void echo(string[] cmd)
        //{
        //    Console.Write("\'");
        //    for(int i = 1; i < cmd.Length; i++)
        //    {
        //        Console.Write(cmd[i] + " ");
        //    }
        //    Console.WriteLine("\'");
        //}

        protected override void Run()
        {
            Console.Write("Ready: ");
            string input = Console.ReadLine();

            while (input == null || input == "")
            {
                Console.Write("Ready: ");
                input = Console.ReadLine();
            }

            char[] delimiterChars = { ' ', ',', '\n' };

            string[] array = input.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            string cmd = array[0];
            string[] args = getArgs(array);

            string result = null;
           
            foreach(CoreComponent component in _components){
                result = component.executeIfContains(cmd, args);
                if (result != null)
                {
                    Console.WriteLine(result);
                    break;
                }
            }

        }

        private string[] getArgs(string[] array)
        {
            if(array.Length == 1)
            {
                return null;
            }

            string[] args = new string[array.Length - 1];

            for (int i = 1; i < array.Length; i++)
            {
                args[i - 1] = array[i];
            }

            return args;
        }
        
        private List<CoreComponent> _components;
    }
}
