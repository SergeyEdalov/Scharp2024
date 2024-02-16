namespace Homework_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * Объедините две предыдущих работы (практические работы 2 и 3): 
             * поиск файла и поиск текста в файле написав утилиту которая ищет файлы определенного расширения с указанным текстом. 
             * Рекурсивно. Пример вызова утилиты: utility.exe txt текст.
             */

            string path = @"D:\Study_programmist\Курс. Разработка приложений на C#\Scharp\Homework_8";

            //string typeFile = "*.txt";
            string typeFile = "*." + args[0];

            //string textInFile = "class";
            string textInFile = args[1];

            if (!FindFile(typeFile, path, textInFile))  
                Console.WriteLine("Нет совпадений"); 

            
        }

        static bool FindFile(string typeFile, string directory, string text)
        {
            foreach (string name in Directory.EnumerateFiles(directory, typeFile))
            {
                using (StreamReader streamReader = new StreamReader(name))
                {
                    string line = streamReader.ReadToEnd();
                    if (line.Contains(text)) 
                    {
                        Console.WriteLine($"Найдено в файле - {Path.GetFileName(name)},\nрасположение - {Path.GetFullPath(name)} ");
                        Console.WriteLine(line);
                        return true;
                    }
                }
            }
            foreach (string dir in Directory.GetDirectories(directory))
            {
                if (FindFile(typeFile, dir, text)) return true;
            }
            return false;
        }

    }
}
