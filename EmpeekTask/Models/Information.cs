using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EmpeekTask.Models
{
    public class Information
    {
        public  string currentPath { get; set; }
        public  List<string> currentFiles { get; set; }
        static public List<string> drivers { get; set; }

        public bool Dots;
        public bool isFile;

        public Information()
        {
            currentFiles = new List<string>();
            drivers = new List<string>();
            GetDrivers();
            Dots = false;

        }
        private void GetDrivers()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                try
                {
                    if (d.TotalSize > 0)
                    {
                        drivers.Add(d.Name);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void GetCurrentFiles(string path)
        {
            currentPath = path;
            if (path == "")
            {
                currentFiles.Clear();
                foreach (string dr in drivers)
                    currentFiles.Add(dr);
                Dots = false;
            }
            else
            {
                currentFiles.Clear();
                SearchCurrentFiles();
                currentFiles.Sort();
                Dots = true;
            }
        }
        public static bool Check(string path)
        {
            if (path == "" || Directory.Exists(path))
                return true;
            return false;
        }
        private void SearchCurrentFiles()
        {
            DirectoryInfo root = new DirectoryInfo(currentPath);
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            
            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    currentFiles.Add(fi.Name);

                }
                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dir in subDirs)
                {
                    currentFiles.Add(dir.Name);
                }
            }
        }

    }
}