using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    public class CoreComponent : IComponent
    {
        public CoreComponent() : base()
        {
            _cmds = new List<string>();
            _cmds.Add("echo");
        }
        
        public string echo(string[] args)
        {
            if(args == null){
                return "";
            }

            List<string> output = new List<string>();
            int size = 0;
            foreach (string arg in args) {
                size += arg.Length + 1;
                output.Add(arg + " ");
            }

            char[] charArray = new char[size - 1];
            int i = 0;

            

            foreach (string word in output)
            {
                foreach (char letter in word)
                {
                    charArray[i++] = letter;
                }
            }

            string outputString = new string(charArray);

            //Console.WriteLine("CoreComponent: outputString: " + outputString);
            //string input = Console.ReadLine();

            return outputString;
        }

        public bool contains(string cmd)
        {
            return _cmds.Contains(cmd);
        }

        public string executeIfContains(string cmd, string[] args)
        {
            string output = null;
            foreach (string _cmd in _cmds)
            {
                if (true /*_cmd.Equals(cmd)*/)
                {
                    //return _invodeMethod(cmd, args);
                    output = echo(args);
                    return output;
                }
            }

            return output;
        }

        private string _invodeMethod(string cmd, string[] args)
        {

            MethodInfo methodInfo = this.GetType().GetMethod(cmd);

            if (methodInfo != null)
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
                return (string)methodInfo.Invoke(methodInfo, args);
            }

            return null;
        }

        protected List<string> _cmds;
    }
}
