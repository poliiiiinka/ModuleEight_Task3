using ModuleEight_Task3.Methods;

namespace ModuleEight_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите адрес папки: ");
            string FolderName = Console.ReadLine();

            long firstPlace = MethodFolderSize.FolderSize(FolderName);
            Console.WriteLine($"Исходный размер папки: {firstPlace}");
            MethodGetFolder.GetFolder(FolderName);

            long secondPlace = MethodFolderSize.FolderSize(FolderName);
            Console.WriteLine($"Текущий размер папки: {secondPlace}");

            long freePlace = firstPlace - secondPlace;
            Console.WriteLine($"Места освобождено: {freePlace}");
        }
    }
}
