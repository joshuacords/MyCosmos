using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    class Variable
    {
        private Utilities _utilities;
        public string name;
        public double value;

        public Variable(string name, double value)
        {
            this.name = name;
            this.value = value;
            _utilities = Utilities.getInstance();
        }

        public bool sameName(Variable var)
        {
            return _utilities.equalString(var.name, name);
        }

        public bool sameName(string varName)
        {
            return _utilities.equalString(varName, name);
        }
    }

    class VariableStorage
    {
        public VariableStorage()
        {
            _utilities = Utilities.getInstance();
            _reservedWords = new List<string>();
            _namedVars = new List<Variable>();
        }

        public void setReservedWords(List<string> reservedWords)
        {
            _reservedWords = reservedWords;
        }

        public string setVar(string varName, double value)
        {
            string result = varName + " = " + value;
            
            if (_utilities.containsString(_reservedWords, varName))
            {
                result = "Error: \"" + varName + "\" is a reserved word.";
            } else
            {
                addVar(new Variable(varName, value));
            }
            
            return result;
        }

        public string translate(string varName)
        {
            Variable temp = getVar(varName);
            if (temp != null)
            {
                return temp.value.ToString();
            }
            else
            {
                return varName;
            }
        }

        private Variable getVar(string varName)
        {
            Variable temp = null;
            foreach (Variable x in _namedVars)
            {
                if (x.sameName(varName))
                {
                    temp = x;
                }
            }
            return temp;
        }

        private void addVar(Variable var)
        {
            Variable temp = getVar(var.name);
            
            if(temp != null)
            {
                temp.value = var.value;
            } else
            {
                _namedVars.Add(var);
            }
           
        }



        

        private List<string> _reservedWords;
        private Utilities _utilities;
        private List<Variable> _namedVars;
    }
}
