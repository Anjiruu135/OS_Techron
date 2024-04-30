using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cosmos.System.FileSystem;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;

namespace OS_CosmosBuild
{
    public class Kernel : Sys.Kernel
    {
        Canvas canvas;

        private readonly Bitmap bitmap = new Bitmap(10, 10,
                new byte[] { 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255,
                    23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 153, 57, 12, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 0, 255, 243, 255, 153, 57, 12, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243,
                    255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72, 72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72,
                    72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255,
                    10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148,
                    255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, }, ColorDepth.ColorDepth32);

        Sys.FileSystem.CosmosVFS FileSystem = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FileSystem);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine("Techron OS booted successfully. By Group 3.");
        }

        protected override void Run()
        {
            Console.WriteLine("");
            Console.Write("$ ");
            string input = Console.ReadLine();
            Console.WriteLine("");
            ExecuteCommand(input);
        }

        private void ExecuteCommand(string input)
        {
            if (input == "help")
            {
                Console.WriteLine("calc        -- calculator");
                Console.WriteLine("clear       -- clear all system text");
                Console.WriteLine("dircrt      -- create a directory");
                Console.WriteLine("dirdlt      -- delete a directory");
                Console.WriteLine("dirfiles    -- read all files in directory");
                Console.WriteLine("dirs        -- show list of all directories");
                Console.WriteLine("disk        -- show list of all disks");
                Console.WriteLine("draw        -- draw a shape");
                Console.WriteLine("filecrt     -- create a file");
                Console.WriteLine("filedlt     -- delete a file");
                Console.WriteLine("filemov     -- move a file");
                Console.WriteLine("filerd      -- read a file");
                Console.WriteLine("files       -- show list of all files");
                Console.WriteLine("filewrt     -- write on a file");
                Console.WriteLine("help        -- show the list of all commands");
                Console.WriteLine("sysbuild    -- show build information");
                Console.WriteLine("sysinfo     -- show system information");
                Console.WriteLine("sysrestart  -- restart system");
                Console.WriteLine("sysshutdown -- shutdown system");
                Console.WriteLine("sysuptime   -- show system uptime");
            }

            else if (input == "calc")
            {
                int firstnum, secondnum, result;
                Console.Write("Enter first number: ");
                string firstnumstr = Console.ReadLine();

                bool isFirstnumValid = int.TryParse(firstnumstr, out firstnum);

                if (!isFirstnumValid)
                {
                    Console.WriteLine("Invalid input.");
                }

                Console.Write("Enter operation: ");
                string operation = Console.ReadLine();

                Console.Write("Enter second number: ");
                string secondnumstr = Console.ReadLine();

                bool isSecondnumValid = int.TryParse(secondnumstr, out secondnum);

                if (!isSecondnumValid)
                {
                    Console.WriteLine("Invalid input.");
                }

                if (operation == "+")
                {
                    result = firstnum + secondnum;
                    Console.WriteLine("");
                    Console.WriteLine("Result: ", result);
                }
                else if (operation == "-")
                {
                    result = firstnum - secondnum;
                    Console.WriteLine("");
                    Console.WriteLine("Result: ", result);
                }
                else if (operation == "/")
                {
                    result = firstnum / secondnum;
                    Console.WriteLine("");
                    Console.WriteLine("Result: ", result);
                }
                else if (operation == "*")
                {
                    result = firstnum * secondnum;
                    Console.WriteLine("");
                    Console.WriteLine("Result: ", result);
                }
                else
                {
                    Console.Write("Invalid Operation. ");
                }
            }

            else if (input == "clear")
            {
                Console.Clear();
                Console.WriteLine("Techron OS booted successfully. By Group 3.");
            }

            else if (input == "dircrt")
            {
                Console.Write("Enter directory to create: ");
                string directoryname = Console.ReadLine();
                try
                {
                    Directory.CreateDirectory($@"0:\{directoryname}\");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "dirdlt")
            {
                Console.Write("Enter directory to delete: ");
                string directoryname = Console.ReadLine();
                try
                {
                    Directory.Delete($@"0:\{directoryname}\");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "dirfiles")
            {
                Console.Write("Enter directory to read: ");
                string directoryname = Console.ReadLine();
                Console.WriteLine("");
                try
                {
                    var directory_list = Directory.GetFiles($@"0:\{directoryname}");
                    try
                    {
                        foreach (var file in directory_list)
                        {
                            Console.WriteLine(file);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "dirs")
            {
                var directory_list = Directory.GetDirectories(@"0:\");

                foreach (var directory in directory_list)
                {
                    Console.WriteLine(directory);
                }
            }

            else if (input == "disk")
            {
                var disks = FileSystem.GetDisks();
                Console.WriteLine("Available disks:");
                Console.WriteLine("");
                var fs_type = FileSystem.GetFileSystemType(@"0:\");
                Console.WriteLine("File System Type: " + fs_type);
                foreach (var disk in disks)
                {
                    disk.DisplayInformation();
                }
            }

            else if (input == "draw")
            {
                Console.Write("Enter shape and color: ");
                string userInput = Console.ReadLine();

                string[] inputs = userInput.Split(' ');
                string shape;
                string colorInput;

                if (inputs.Length >= 2)
                {
                    shape = inputs[0];
                    colorInput = inputs[1];
                }
                else
                {
                    shape = inputs[0];
                    colorInput = "red";
                }

                Color color = ParseColor(colorInput);

                canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
                canvas.Clear(Color.White);
                Pen pen = new Pen(color);
                try
                {
                    if (shape == "rectangle")
                    {
                        canvas.DrawFilledRectangle(pen, 120, 140, 120, 60);
                    }
                    else if (shape == "square")
                    {
                        canvas.DrawSquare(pen, 120, 140, 100);
                    }
                    else if (shape == "circle")
                    {
                        canvas.DrawFilledCircle(pen, 120, 140, 600);
                    }
                    else if (shape == "triangle")
                    {
                        canvas.DrawTriangle(pen, new Sys.Graphics.Point(200, 200), new Sys.Graphics.Point(150, 250), new Sys.Graphics.Point(250, 250));
                    }
                    canvas.Display();
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occurred: " + e.Message);
                }
                finally
                {
                    canvas.Disable();
                }
            }

            else if (input == "filecrt")
            {
                try
                {
                    Console.Write("Enter file to create: ");
                    string filename = Console.ReadLine();
                    var file_stream = File.Create($@"0:\{filename}.txt");
                    Console.Write("Write on file: ");
                    string filecontent = Console.ReadLine();
                    File.WriteAllText($@"0:\{filename}.txt", $"{filecontent}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "filedlt")
            {
                try
                {
                    Console.Write("Enter file to delete: ");
                    string filename = Console.ReadLine();
                    File.Delete($@"0:\{filename}.txt");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "filemov")
            {
                try
                {
                    Console.Write("Enter file to move: ");
                    string filename = Console.ReadLine();
                    string file = $@"0:\{filename}.txt";

                    Console.Write("Enter new location: ");
                    string locationname = Console.ReadLine();
                    string location = $@"0:\{locationname}";

                    File.Copy(file, location);
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "filerd")
            {
                try
                {
                    Console.Write("Enter file to read: ");
                    string filename = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine(File.ReadAllText($@"0:\{filename}.txt"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "files")
            {
                var files_list = Directory.GetFiles(@"0:\");
                foreach (var file in files_list)
                {
                    Console.WriteLine(file);
                }
            }

            else if (input == "filewrt")
            {
                try
                {
                    Console.Write("Enter file to write: ");
                    string filename = Console.ReadLine();
                    Console.Write("Write on file: ");
                    string filecontent = Console.ReadLine();
                    File.WriteAllText($@"0:\{filename}.txt", $"{filecontent}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "sysbuild")
            {
                Console.WriteLine("Operating System Build:");
                Console.WriteLine("- Build Date: April 2024");
                Console.WriteLine("- Build Version: 1.0");
                Console.WriteLine("- Developed By: Group 3 (Beljano, Gandawali, Gitalan, Martinez, Quirante)");
            }

            else if (input == "sysinfo")
            {
                string systemType = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
                Console.WriteLine("System Information:");
                Console.WriteLine("- OS Version: Techron 1.0");
                Console.WriteLine("- Kernel Version: Cosmos Kernel");
                Console.WriteLine($"- Processor: {Cosmos.Core.CPU.GetCPUBrandString()}");
                Console.WriteLine($"- Memory: {Cosmos.Core.CPU.GetAmountOfRAM()} MB");
                Console.WriteLine($"- System Type: {systemType}");
            }

            else if (input == "sysrestart")
            {
                Console.Write("Restarting system");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Sys.Power.Reboot();
            }

            else if (input == "sysshutdown")
            {
                Console.Write("Shutting down system");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                Sys.Power.Shutdown();
            }

            else if (input == "sysuptime")
            {
                Console.WriteLine($"System Uptime: {Cosmos.Core.CPU.GetCPUUptime()} ms");
            }
        }

        static Dictionary<string, Color> colorMap = new Dictionary<string, Color>
        {
            { "black", Color.Black },
            { "white", Color.White },
            { "red", Color.Red },
            { "green", Color.Green },
            { "blue", Color.Blue },
            { "yellow", Color.Yellow },
            { "cyan", Color.Cyan },
            { "magenta", Color.Magenta },
            { "orange", Color.Orange },
            { "purple", Color.Purple },
            { "brown", Color.Brown },
            { "pink", Color.Pink },
            { "gray", Color.Gray },
        };

        static Color ParseColor(string colorInput)
        {
            string colorName = colorInput.ToLower();

            if (colorMap.ContainsKey(colorName))
            {
                return colorMap[colorName];
            }
            else
            {
                return Color.Red;
            }
        }
    }
}
