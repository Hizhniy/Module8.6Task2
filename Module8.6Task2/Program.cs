using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите путь к папке для оценки: ");
        string dirPath = Console.ReadLine();        
        if (Directory.Exists(dirPath)) // проверяем, что директория существует
        {
            Console.WriteLine("Размер папки в байтах: " + FolderSize(dirPath));
        }
        else Console.WriteLine("Папка по указанному пути не найдена...");
    }

    static long FolderSize(string path)
    {
        long size = 0;
        try
        {
            var files = Directory.GetFiles(path);
            FileInfo file = null;
            foreach (var f in files)
            {
                file = new FileInfo(f);
                size = size + file.Length;
            }            
            var dirs = Directory.GetDirectories(path);
            foreach (var d in dirs)
            {
                size = size + FolderSize(d);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return size;
    }
}