using System;
using TMFileParser;

namespace TMFileParserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ________________________________________");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                  TMT                   |");
            Console.WriteLine("|              File Converter            |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|________________________________________|");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("TM7/TB7 file path: ");
            var filePath = Console.ReadLine();
            //Console.Write("Output path: ");
            //var outputPath = Console.ReadLine();
            var parser = new TMParser();
            var result = parser.ReadV7(filePath);
            Console.ReadLine();
        }
    }
}
 