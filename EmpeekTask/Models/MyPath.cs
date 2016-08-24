using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpeekTask.Models
{
    public class MyPath
    {
        public string path { get; set; }
        public string folder { get; set; }

        private string Concat()
        {
            if (path == null || path == "")
                return folder;
            return path[path.Length - 1] == '\\' ? path + folder : path + "\\" + folder;
        }
        public override string ToString()
        {
            if (folder == "...")
            {
                folder = "";
                int checker = Concat().Split('\\').Length;
                if (checker == 2 || checker == 1)
                    return "";
                path = path.Remove(path.LastIndexOf("\\"));
                if (path == "C:")
                    return path + "\\";
                return path;
            }
            return Concat();
        }
    }

}