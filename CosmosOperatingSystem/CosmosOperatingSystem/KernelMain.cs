using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    class KernelMain
    {
        public KernelMain()
        {
            Console.WriteLine("Cosmos booted. Adding components...");
            _components = new List<IComponent>();
            _reservedWords = new List<string>();

            _components.Add(new CoreComponent());
            FileManagerComponent file = FileManagerComponent.getInstance();
            _components.Add(file);
            _components.Add(new BatchComponent());
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

        public void Run()
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

            foreach (IComponent component in _components)
            {
                result = component.executeIfContains(cmd, args);
                if (result != null)
                {
                    Console.WriteLine(result);
                    break;
                }
            }

        }

        public static void runInternal(string input)
        {
            string[] array = input.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            string cmd = array[0];
            string[] args = getArgs(array);

            string result = null;

            foreach (IComponent component in _components)
            {
                result = component.executeIfContains(cmd, args);
                if (result != null)
                {
                    Console.WriteLine(result);
                    break;
                }
            }
        }

        private static string[] getArgs(string[] array)
        {
            if (array.Length == 1)
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

        private static List<IComponent> _components;
        private List<string> _reservedWords;
    }
}
