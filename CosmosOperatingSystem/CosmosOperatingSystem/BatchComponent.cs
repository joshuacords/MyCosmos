﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    class BatchComponent : IComponent
    {
        public BatchComponent()
        {
            _utilities = Utilities.getInstance();
            _cmds = new List<string>();
            _cmds.Add("RUN");
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
                case "RUN":
                    output = run(args);
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

        private string run(string[] args)
        {
            int numTimes = _utilities.parseInt(args[0]);
            string fileName = args[1];
            BatchInvoker batch = new BatchInvoker(fileName, numTimes);

            while(batch.hasNext())
            {
                batch.runNext();
            }
            return "";
        }

        protected List<string> _cmds;
        private Utilities _utilities;
    }
}
