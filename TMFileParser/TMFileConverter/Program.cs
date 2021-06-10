using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Text.Json;
using TMFileParser;

namespace TMFileConverter
{
    class Program
    {
        static int Main(string[] args)
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
            var convertOption = new Option<string>(
                    "--convert",
                    "Output file format to convert.");
            var outputPathOption = new Option<FileInfo>(
                    "--output-path",
                    "Path to store output.");

            rootCommand.AddOption(inputPathOption);
            rootCommand.AddOption(convertOption);
            rootCommand.AddOption(outputPathOption);
            rootCommand.Handler = CommandHandler.Create<FileInfo, string, FileInfo>((inputpath, convert, outputpath) => {
                {
                    if (inputpath == null || convert == null)
                    {
                        throw new ArgumentNullException("Missing inputs. --input-path and --convert are required.");
                    }
                    if (inputpath.Extension != ".tm7" && inputpath.Extension != ".tb7")
                    {
                        throw new ArgumentException("Invalid --input-path.");
                    }
                    var parser = new Parser(inputpath);
                    var result = parser.ReadFile();
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
                    switch (convert)
                    {
                        case "json":
                            if (outputpath == null)
                            {
                                throw new ArgumentNullException("Missing inputs. --output-path are required to convert to json.");
                            }
                            string outputJson = JsonSerializer.Serialize(result);
                            var outputFilePath = Path.Combine(outputpath.FullName, Path.GetFileNameWithoutExtension(inputpath.FullName) + ".json");
                            try
                            {
                                File.WriteAllText(outputFilePath, outputJson);
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Error occured while converting to json.");
                            }

                            Console.WriteLine();
                            Console.Write("JSON file saved. Path : " + outputFilePath);
                            break;
                        default:
                            throw new ArgumentException("Invalid --convert.");
                    }
                }
            });
            rootCommand.Description = "Command line tool to parser tm7 and tb7 files.";
            return rootCommand.InvokeAsync(args).Result;
        }
    }
}
