using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleEight_Task3.Methods
{
    internal class MethodFolderSize
    {
        public static long FolderSize(string path)
        {
            DirectoryInfo directory;
            if (Directory.Exists(path))
            {
                directory = new DirectoryInfo(path);

                long size = 0;

                try
                {
                    foreach (var file in directory.GetFiles())
                        size += file.Length;
                }
                catch { }

                try
                {
                    foreach (var direct in directory.GetDirectories())
                        size += FolderSize(direct.FullName);
                }
                catch { }

                return size;
            }
            else
            {
                Console.WriteLine("Папка не найдена!");
                return 0;
            }
        }
    }
}
