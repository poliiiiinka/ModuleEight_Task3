using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleEight_Task3.Methods
{
    internal class MethodGetFolder
    {
        public static void GetFolder(string folderName)
        {
            var dir = new DirectoryInfo(folderName);
            /// счётчики для удалённых папок и файлов
            int fileCounter = 0;
            int folderCounter = 0;

            if (Directory.Exists(folderName))
            {
                try
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        /// проверяем время последнего обращения к файлу
                        if (DateTime.Now - file.LastAccessTime >= TimeSpan.FromSeconds(30))
                        {
                            file.Delete();
                            Console.WriteLine($"Файл {file.Name} удалён");
                            fileCounter++;
                        }
                        else
                            Console.WriteLine($"Не удалось удалить файл {file.Name}");
                    }
                    Console.WriteLine($"Удалено файлов: {fileCounter}");

                    foreach (DirectoryInfo direct in dir.GetDirectories())
                    {
                        /// проверяем время последнего обращения к папке
                        if (DateTime.Now - direct.LastAccessTime >= TimeSpan.FromSeconds(30))
                        {
                            direct.Delete(true); /// удаление папки со всем содержимым
                            Console.WriteLine($"Папка {direct.Name} удалена");
                            folderCounter++;
                        }
                        else
                            Console.WriteLine($"Не удалось удалить папку {direct.Name}");
                    }
                    Console.WriteLine($"Удалено папок: {folderCounter}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Не удалось удалить папку: {ex}");
                }
            }
            else
                Console.WriteLine("Папка не найдена!");
        }
    }
}
