using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TMFileParser;

namespace TMFileConverter
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static async Task Main(string[] args)
        {
            var rootCommand = new RootCommand();

            var helpCommand = new Command("help", "Instructions for using the parser.");
            helpCommand.Handler = CommandHandler.Create(() =>
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
                Console.WriteLine("This tool can be used to parse tm7 and tb7 file.");
                Console.WriteLine();
                Console.WriteLine("Options - ");
                Console.WriteLine("json -  Converts the file to json file and saves in given output path.");
                Console.WriteLine();
                Console.WriteLine("Instructions - ");
                Console.WriteLine("tmfileparser --input-path [Path of tm7 or tb7 file] --convert [Convert operation] --output-path [Path to store the output]");
            });
            rootCommand.AddCommand(helpCommand);

            var inputPathOption = new Option<FileInfo>(
                    "--input-path",
                    "Input tm7 file path.");
            inputPathOption.AddAlias("-i");

            var formatOption = new Option<string>(
                    "--save-format",
                    "Output file format to convert.");
            formatOption.AddAlias("-s");

            var actionOption = new Option<string[]>(
                    "--get",
                    "Data to be retieved.");
            actionOption.AddAlias("-g");

            var outputPathOption = new Option<FileInfo>(
                    "--output-path",
                    "Path to store output.");
            outputPathOption.AddAlias("-o");

            rootCommand.AddOption(inputPathOption);
            rootCommand.AddOption(formatOption);
            rootCommand.AddOption(outputPathOption);
            rootCommand.AddOption(actionOption);
            rootCommand.Description = "Command line tool to parser tm7 and tb7 files.";
            rootCommand.Handler = CommandHandler.Create<FileInfo, string, string[], FileInfo>(RunCommand);
            await rootCommand.InvokeAsync(args);
        }

        public static void PrintError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        public static void RunCommand(FileInfo inputpath, string saveformat, string[] get, FileInfo outputpath)
        {
            try
            {
                if (inputpath == null || saveformat == null || get == null || outputpath == null)
                {
                    throw new ArgumentNullException("Missing inputs. -i/--input-path, -g/--get, -o/--output-path and -s/--save-format are required.");
                }
                var extenison = inputpath.Extension.ToLower();
                if (extenison != ".tm7" && extenison != ".tb7")
                {
                    throw new ArgumentException("Invalid -i/--input-path.");
                }
                var parser = new Parser(inputpath);
                foreach (string category in get)
                {
                    var result = parser.GetData(category);
                    switch (saveformat)
                    {
                        case "json":
                            string outputJson = JsonSerializer.Serialize(result);
                            var outputFilePath = Path.Combine(outputpath.FullName, Path.GetFileNameWithoutExtension(inputpath.FullName) + "-" + category + ".json");
                            try
                            {
                                File.WriteAllText(outputFilePath, outputJson);
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Error occured while converting.");
                            }

                            Console.WriteLine();
                            Console.WriteLine("File saved. Path : " + outputFilePath);
                            break;
                        default:
                            throw new ArgumentException("Invalid -s/--save-format:" + saveformat);
                    }
                }
            }
            catch (Exception e)
            {
                PrintError(e.Message);
            }
            
            
        }
                  
    }
}
