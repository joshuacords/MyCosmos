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
            _kernel = new KernelMain();
        }

        protected override void Run()
        {
            _kernel.Run();
        }
        private KernelMain _kernel;
    }
}
