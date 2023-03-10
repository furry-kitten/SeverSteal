using System;
using System.IO;
using SeverSteal.FtpsParser;
using SeverSteal.Models;

namespace SeverSteal
{
    /*
     * На собеседовании договорились, что задание можно выполнить в консоли.
     *
     * После парса можно добавить всё полученное в параметы бизнес процесса метод Set().
     * Если использовать ATF.Repository то тут ещё проще, просто создаёшь сущность с нужными данными и связываешь по существующему id (что указан в задании, например)
     * Так же можно доавить через ESQ.
     *
     * Дожен обратить внимание на то, что файл должен был быть в формате .json, но пришёл в таблице. Я вытянул из него строку, но не понял, куда делось нормальное для json формата оформление. Полетели кодировки, но, видимо, excel любит ломать их и своими ручками не смог их восстановить. Поэтому просто скопировал строку в блокнот и сохранил в формате .json.
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteInfo();
            Console.Write("Введите путь к файлу: ");
            var path = Console.ReadLine();
            var data = File.ReadAllText(path);
            var conversion = LogParser.Parse(data);
            WriteConversion(conversion);
            Console.ReadKey();
        }

        private static void WriteConversion(Conversion conversion)
        {
            Console.WriteLine($"{Environment.NewLine}Информация в файле{Environment.NewLine}");
            Console.WriteLine($"{nameof(Conversion.MessageId)}: {conversion.MessageId}");
            Console.WriteLine($"{nameof(Conversion.Recipient)}: {conversion.Recipient}");
            Console.WriteLine($"{nameof(Conversion.Sender)}: {conversion.Sender}");
            Console.WriteLine($"{nameof(Conversion.Subject)}: {conversion.Subject}");
        }

        private static void WriteInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("На собеседовании договорились, что задание можно выполнить в консоли.".ToUpper());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"После парса можно добавить всё полученное в параметы бизнес процесса метод Set().{Environment.NewLine}Если использовать ATF.Repository то тут ещё проще, просто создаёшь сущность с нужными данными и связываешь по существующему id(что указан в задании, например){Environment.NewLine}Так же можно доавить через ESQ.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Дожен обратить внимание на то, что файл должен был быть в формате .json, но пришёл в таблице. Я вытянул из него строку, но не понял, куда делось нормальное для json формата оформление. Полетели кодировки, но, видимо, excel любит ломать их и своими ручками не смог их восстановить. Поэтому просто скопировал строку в блокнот и сохранил в формате .json.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}