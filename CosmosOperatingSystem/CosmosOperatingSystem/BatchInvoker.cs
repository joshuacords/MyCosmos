using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    class BatchInvoker
    {
        public BatchInvoker(string fileName, int run)
        {
            string[] args = { "fileName" };
            args[0] = fileName;
            _currentLine = 0;
            _currentRun = 0;
            _maxRun = run;
            _fileManager = FileManagerComponent.getInstance();
            //Console.WriteLine("BatchInvoder\nfileName: " + fileName);
            //Console.WriteLine("args[0]: " + args[0]);
            _file = _fileManager.getFile(args);
            //if(_file != null)
            //{
            //    Console.WriteLine("Got file: " + _file.getFullFileName());
            //}else
            //{
            //    Console.WriteLine("WARNING: Did not find file");
            //}

        }

        public void runNext()
        {
            if(_file != null)
            {
                List<string> data = _file.getData();
                string[] dataArray = data.ToArray();

                while (_currentRun < _maxRun)
                {
                    while (_currentLine < _file.getData().Count)
                    {
                        //Console.WriteLine("Running File\nCurrentRun: " + _currentRun + " of " + _maxRun + "\ncurrentLine: " + _currentLine);
                        //string runLine = _file.getData().ElementAt(_currentLine);
                        KernelMain.runInternal(dataArray[_currentLine]);
                        _currentLine++;
                    }
                    _currentLine = 0;
                    _currentRun++;
                }
                Console.Write(_file.getFullFileName() + " batch finished");
            }
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
        File _file;
        int _currentLine;
        int _currentRun;
        int _maxRun;
    }
}
