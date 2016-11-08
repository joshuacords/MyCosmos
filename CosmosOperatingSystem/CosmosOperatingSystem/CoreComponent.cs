using System.Collections.Generic;

namespace CosmosOperatingSystem
{
    public class CoreComponent : IComponent
    {
        public CoreComponent()
        {
            _cmds = new List<string>();
            _cmds.Add("echo");
        }

        public bool contains(string cmd)
        {
            return _cmds.Contains(cmd);
        }

        public string executeIfContains(string cmd, string[] args)
        {
            string output = null;
            switch (cmd)
            {
                case "echo": output = echo(args);
                    break;
                default: output = null;
                    break;
            }

            return output;
        }

        public List<string> getCommands()
        {
            return _cmds;
        }

        private string echo(string[] args)
        {
            if(args == null){
                return "";
            }

            int i = 0;
            for (; i < args.Length; i++)
            {
                args[i] = _math.translate(args[i]);
            }

            List<string> output = new List<string>();
            int size = 0;
            foreach (string arg in args) {
                size += arg.Length + 1;
                output.Add(arg + " ");
            }

            char[] charArray = new char[size - 1];
            i = 0;
            
            foreach (string word in output)
            {
                foreach (char letter in word)
                {
                    charArray[i++] = letter;
                }
            }

            string outputString = new string(charArray);

            return outputString;
        }

        private MathComponent _math = MathComponent.getInstance();
        protected List<string> _cmds;
    }
}
