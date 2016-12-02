using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosOperatingSystem
{
    class File
    {
        private string _fileName;
        private string _ext;
        private int _size;
        private List<string> _data;

        public File(string fileName, string ext, List<string> data)
        {
            _fileName = fileName;
            _ext = ext;
            _data = data;
            setSize(data);
        }

        public string getExt()
        {
            return _ext;
        }

        public string getFileName()
        {
            return _fileName;
        }

        public int getSize()
        {
            return _size;
        }

        public List<string> getData()
        {
            return _data;
        }

        public void setExt(string ext)
        {
            _ext = ext;
        }

        public void setFileName(string fileName)
        {
            _fileName = fileName;
        }

        public void setData(List<string> data)
        {
            _data = data;
            setSize(data);
        }

        private void setSize(List<string> data)
        {
            _size = 0;
            foreach (string datum in data)
            {
                _size += datum.Length;
            }
        }

    }


    class FileManagerComponent : IComponent
    {
        private static FileManagerComponent _instance;

        public static FileManagerComponent getInstance()
        {
            if (_instance == null)
            {
                _instance = new FileManagerComponent();
            }

            return _instance;
        }

        public FileManagerComponent()
        {
            _utilities = Utilities.getInstance();
            _cmds = new List<string>();
            _files = new List<File>();
            _cmds.Add("dir");
            _cmds.Add("create");
            _cmds.Add("view");
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
                case "dir":
                    output = dir(args);
                    break;
                case "create":
                    output = create(args);
                    break;
                case "view":
                    output = getFile(args).ToString();
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

        private List<string> collectData()
        {
            Console.WriteLine("Enter data (type \"save\" to end):");
            List<string> data = new List<string>();
            string input = "";
            while(!_utilities.equalString(input, "save"))
            {
                input = Console.ReadLine();
                
                if (!_utilities.equalString(input, "save"))
                {
                    data.Add(input);
                }
                
            }
            return data;
        }

        private string create(string[] args)
        {
            char[] delimiterChars = { '.' };

            string[] array = args[0].Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            string fileName = array[0];
            string ext = array[1];
            if (_utilities.equalString(fileName, "") || _utilities.equalString(ext, ""))
            {
                return "Error: file must follow filename.ext";
            }
            List<string> data = collectData();

            File file = new File(fileName, ext, data);

            _files.Add(file);

            displayFile(file);
            return "";
        }

        private string dir(string[] args)
        {
            foreach(File file in _files)
            {
                displayFile(file);
            }

            return "";
        }

        private void displayFile(File file)
        {
            Console.WriteLine(file.getFileName() + "." + file.getExt() + "\tsize: " + file.getSize());
        }

        public File getFile(string[] fileName)
        {
            foreach(File file in _files)
            {
                if(_utilities.equalString(file.getFileName(), fileName[0])){
                    return file;
                }
            }

            return null;
        }


        private List<File> _files;
        private Utilities _utilities;
        protected List<string> _cmds;
    }
}
