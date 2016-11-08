using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    class MathComponent : IComponent
    {
        private static MathComponent _instance;

        public static MathComponent getInstance()
        {
            if (_instance == null)
            {
                _instance = new MathComponent();
            }

            return _instance;
        }

        private MathComponent()
        {
            _utilities = Utilities.getInstance();
            _variableStorage = new VariableStorage();
            _cmds = new List<string>();
            _cmds.Add("ADD");
            _cmds.Add("SUB");
            _cmds.Add("MUL");
            _cmds.Add("DIV");
            _cmds.Add("SET");
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
                case "ADD":
                    output = add(args);
                    break;                
                case "DIV":
                    output = div(args);
                    break;
                case "MUL":
                    output = mul(args);
                    break;
                case "SET":
                    output = set(args);
                    break;
                case "SUB":
                    output = sub(args);
                    break;
                default:
                    output = null;
                    break;
            }

            return output;
        }

        public List<string> getCommands()
        {
            return _cmds;
        }

        public void setReservedWords(List<string> reservedWords)
        {
            _variableStorage.setReservedWords(reservedWords);
        }

        private string add(string[] args)
        {
            if(_utilities.checkArgs(args,3))
            {
                return addSave(args);
            }
            else if(_utilities.checkArgs(args, 2))
            {
                string arg1 = _variableStorage.translate(args[0]);
                string arg2 = _variableStorage.translate(args[1]);

                int num1 = _utilities.parseInt(arg1);
                int num2 = _utilities.parseInt(arg2);
                                
                int sum = num1 + num2;
                string result = sum.ToString();
                return result;
            }
            else
            {
                return "Error: bad arguments";
            }            
        }

        private string addSave(string[] args)
        {
            string arg1 = _variableStorage.translate(args[0]);
            string arg2 = _variableStorage.translate(args[1]);

            int num1 = _utilities.parseInt(arg1);
            int num2 = _utilities.parseInt(arg2);

            string[] setArgs = new string[2];
            
            int sum = num1 + num2;
            setArgs[0] = args[2];
            setArgs[1] = sum.ToString();

            return set(setArgs);
        }

        private string div(string[] args)
        {
            if (_utilities.checkArgs(args, 3))
            {
                return divSave(args);
            }
            else if (_utilities.checkArgs(args, 2))
            {
                string arg1 = _variableStorage.translate(args[0]);
                string arg2 = _variableStorage.translate(args[1]);

                var num1 = _utilities.parseInt(arg1);
                var num2 = _utilities.parseInt(arg2);

                if (num2 == 0)
                {
                    return "Error: DIV by 0";
                }

                double quo = (double)num1 / (double)num2;
                string result = quo.ToString();
                return result;
            }
            else
            {
                return "Error: bad arguments";
            }  
        }

        private string divSave(string[] args)
        {
            string arg1 = _variableStorage.translate(args[0]);
            string arg2 = _variableStorage.translate(args[1]);

            int num1 = _utilities.parseInt(arg1);
            int num2 = _utilities.parseInt(arg2);

            if (num2 == 0)
            {
                return "Error: DIV by 0";
            }

            string[] setArgs = new string[2];
            
            double quo = (double)num1 / (double)num2;
            setArgs[0] = args[2];
            setArgs[1] = quo.ToString();

            return set(setArgs);
        }

        private string mul(string[] args)
        {
            if (_utilities.checkArgs(args, 3))
            {
                return mulSave(args);
            }
            else if (_utilities.checkArgs(args, 2))
            {
                string arg1 = _variableStorage.translate(args[0]);
                string arg2 = _variableStorage.translate(args[1]);

                var num1 = _utilities.parseInt(arg1);
                var num2 = _utilities.parseInt(arg2);

                var pro = num1 * num2;
                string result = pro.ToString();
                return result;
            }
            else
            {
                return "Error: bad arguments";
            }
        }

        private string mulSave(string[] args)
        {
            string arg1 = _variableStorage.translate(args[0]);
            string arg2 = _variableStorage.translate(args[1]);

            int num1 = _utilities.parseInt(arg1);
            int num2 = _utilities.parseInt(arg2);

            string[] setArgs = new string[2];

            var pro = num1 * num2;
            setArgs[0] = args[2];
            setArgs[1] = pro.ToString(); ;

            return set(setArgs);
        }

        private string set(string[] args)
        {
            string val = _variableStorage.translate(args[1]);
            double value = (double)_utilities.parseInt(val);
            string result = _variableStorage.setVar(args[0], value);
            return result;
        }

        private string sub(string[] args)
        {
            if (_utilities.checkArgs(args, 3))
            {
                return subSave(args);
            }
            else if (_utilities.checkArgs(args, 2))
            {
                string arg1 = _variableStorage.translate(args[0]);
                string arg2 = _variableStorage.translate(args[1]);

                var num1 = _utilities.parseInt(arg1);
                var num2 = _utilities.parseInt(arg2);

                var diff = num1 - num2;
                string result = diff.ToString();
                return result;
            }
            else
            {
                return "Error: bad arguments";
            }
        }

        private string subSave(string[] args)
        {
            string arg1 = _variableStorage.translate(args[0]);
            string arg2 = _variableStorage.translate(args[1]);

            int num1 = _utilities.parseInt(arg1);
            int num2 = _utilities.parseInt(arg2);

            string[] setArgs = new string[2];

            var diff = num1 - num2;
            setArgs[0] = args[2];
            setArgs[1] = diff.ToString(); ;

            return set(setArgs);
        }

        public string translate(string varName)
        {
            return _variableStorage.translate(varName);
        }

        protected List<string> _cmds;
        private VariableStorage _variableStorage;
        private Utilities _utilities;
    }
}

