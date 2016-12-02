using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    class BatchInvoker
    {
        File _file;
        int _currentLine;
        int _currentRun;
        int _maxRun;

        public BatchInvoker(string fileName, int run)
        {
            string[] args = { "fileName" };
            _currentLine = 0;
            _currentRun = 0;
            _maxRun = run;
            _fileManager = FileManagerComponent.getInstance();
            _file = _fileManager.getFile(args);
        }

        public void runNext()
        {
            while(_currentRun < _maxRun)
            {
                while (_currentLine < _file.getData().Count)
                {
                    _currentLine++;
                    //Kernel.runInternal(_file.getData().ElementAt(_currentLine));
                }
                _currentRun++;
            }
            Console.WriteLine(_file.getFileName() + " batch finished");
        }

        public bool hasNext()
        {
            if (_currentRun < _maxRun && _currentLine < _file.getData().Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private FileManagerComponent _fileManager;
    }
}
