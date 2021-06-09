using System;
using System.IO;
using System.Text.Json;
using TMFileParser;

namespace TMFileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endParser = false;
            //Display title - TMT File Converter 
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

            while (!endParser)
            {
                //Ask user for file path
                Console.Write("Give TM7/TB7 file path, and then press Enter: ");
                var filePath = Console.ReadLine();

                //File path checks
                if (Path.GetExtension(filePath) != ".tm7" && Path.GetExtension(filePath) != ".tb7")
                {
                    Console.WriteLine();
                    Console.WriteLine("InvalidTM7/TB7 file path.");
                    Console.WriteLine("Click E/e - Exit or nny other key to Retry:");
                    var retryReply = Console.ReadKey().KeyChar;
                    if (retryReply == 'E' || retryReply == 'e') endParser = true;
                    Console.WriteLine();
                    Console.WriteLine();
                    continue;
                }

                var doneWithFile = false;
                while (!doneWithFile)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Save as Json");
                    Console.WriteLine("N/n - Parse another tm7/tb7 file.");
                    Console.WriteLine("E/e - Exit");
                    Console.Write("Select one option from above:");
                    var parser = new Parser(filePath);
                    var result = parser.ReadFile();
                    var outputOption = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine();
                    outputOption = char.ToLower(outputOption);
                    switch (outputOption)
                    {
                        case '1':
                            string outputJson = JsonSerializer.Serialize(result);
                            Console.Write("Give path to save the json file: ");
                            var outputDirectory = Console.ReadLine();
                            var outputFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".json");
                            try
                            {
                                File.WriteAllText(outputFilePath, outputJson);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid File Path");
                                break;
                            }

                            Console.WriteLine();
                            Console.Write("JSON file saved. Path : " + outputFilePath);
                            break;
                        case 'n':
                            doneWithFile = true;
                            break;
                        case 'e':
                            endParser = true;
                            break;
                        default:
                            break;

                    }
                }

                //Spacing
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
