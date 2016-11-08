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
            _components = new List<IComponent>();
            _reservedWords = new List<string>();

            _components.Add(new CoreComponent());
            _components.Add(new FileManagerComponent());
            MathComponent math = MathComponent.getInstance();
            _components.Add(math);

            foreach (IComponent component in _components)
            {
                foreach (string word in component.getCommands())
                {
                    _reservedWords.Add(word);
                }
            }

            math.setReservedWords(_reservedWords);

            Console.WriteLine("Components ready. Booting complete.");
        }

        protected override void Run()
        {
            Console.Write("Ready: ");
            string input = Console.ReadLine();

            while (input == null || input == "")
            {
                Console.Write("Ready: ");
                input = Console.ReadLine();
            }

            string[] array = input.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            string cmd = array[0];
            string[] args = getArgs(array);

            string result = null;
           
            foreach(IComponent component in _components){
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
        
        private List<IComponent> _components;
        private List<string> _reservedWords;
    }
}
