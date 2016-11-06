using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    abstract public class BaseComponent
    {
        public BaseComponent()
        {
            _cmds = new List<string>();
        }
        public bool contains(string cmd)
        {
            return _cmds.Contains(cmd);
        }

        public string executeIfContains(string cmd, string[] args)
        {
            foreach(string _cmd in _cmds)
            {
                if (true /*_cmd.Equals(cmd)*/)
                {
                    return _invodeMethod(cmd, args);
                }
            }

            return null;
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
