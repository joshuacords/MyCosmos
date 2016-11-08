using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    public class Utilities
    {
        private static Utilities _instance;

        private Utilities() {}

        public static Utilities getInstance()
        {
            if (_instance == null)
            {
                _instance = new Utilities();
            }

            return _instance;
        }

        public bool checkArgs(string[] args, int num)
        {
            if(args.Length < num)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < num; i++)
                {
                    if(args[i] == "")
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool containsString(List<string> list, string element)
        {
            bool contains = false;
            foreach (string listElement in list)
            {
                if(equalString(listElement, element))
                {
                    contains = true;
                }
            }
            return contains;
        }
        
        public bool equalString(string listElement, string element)
        {
            if (listElement.Length != element.Length)
            {
                return false;
            }
            char[] listArray = toArray(listElement);
            char[] elementArray = toArray(element);

            for (int i = 0; i < listArray.Length; i++)
            {
                if (listArray[i] != elementArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int parseInt(string input)
        {
            return Int32.Parse(input);
        }

        private char[] toArray(string input)
        {
            char[] array = new char[input.Length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = input[i];
            }

            return array;
        }
    }
}
