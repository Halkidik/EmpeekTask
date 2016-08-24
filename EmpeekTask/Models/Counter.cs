using System;
using System.IO;

namespace EmpeekTask.Models
{
    public class Counter
    {
        private static int mbyte = 1000000;
        private int[] count { get; set; }
        public int[] Count(string path)
        {
            count = new int[3];
            WalkDirectoryTree(new DirectoryInfo(path));
            return count;
        }
        private void WalkDirectoryTree(DirectoryInfo root)
        {
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
            catch (IOException ex)
            {
                return;
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    if (fi.Length <= 10 * mbyte)
                        count[0]++;
                    else if (fi.Length <= 50 * mbyte)
                        count[1]++;
                    else if (fi.Length > 100 * mbyte)
                        count[2]++;

                }
                subDirs = root.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }
        }
    }

}