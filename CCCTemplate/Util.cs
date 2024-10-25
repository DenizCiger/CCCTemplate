using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCCTemplate
{
    internal class Util
    {

        const string OUTPUT_DIR = "output";
        public static string[][] GetInputs(int level, string path = "./")
        {
            Console.WriteLine("Starting reading of inputs...");
            string dirname = $"{path}level{level}";

            if (!Directory.Exists(dirname))
            {
                throw new ArgumentException($"Directory {dirname} does not exist.");
            }

            string[] fileNames = Directory.GetFiles(dirname, "*.in");

            string[][] inputs = new string[fileNames.Length][];

            for (int i = 0; i < fileNames.Length; i++)
            {
                inputs[i] = File.ReadAllLines(fileNames[i]);
            }

            Console.WriteLine("Completed reading inputs!");
            return inputs;
        }

        public static void GenerateOutputs(int level, string[][] outputContent, string path = "./")
        {
            Console.WriteLine("Starting generation of output files...");
            string dirname = $"{path}level{level}";

            if (!Directory.Exists(dirname))
            {
                throw new ArgumentException($"Directory {dirname} does not exist.");
            }

            if (!Directory.Exists($"{dirname}/{OUTPUT_DIR}"))
            {
                Directory.CreateDirectory($"{dirname}/{OUTPUT_DIR}");
            }

            string[] inFileNames = Directory.GetFiles(dirname, "*.in");
            string[] outFileNames = inFileNames.Select(f => Path.Combine(Path.GetDirectoryName(f), OUTPUT_DIR, Path.GetFileNameWithoutExtension(f) + ".out")).ToArray();

            for (int i = 0; i < outFileNames.Length; i++)
            {
                File.WriteAllLines(outFileNames[i], outputContent[i]);
            }
            Console.WriteLine("Output files generated!");
        }

        public static bool CompareExampleOutEquals(int level, string fileName, string path = "./")
        {
            string dirname = $"{path}level{level}";

            if (!Directory.Exists(dirname))
            {
                Console.WriteLine($"Directory {dirname} does not exist.");
                return false;
            }

            if (File.Exists($"{dirname}/{fileName}") && File.Exists($"{dirname}/{OUTPUT_DIR}/{fileName}"))
            {
                bool equals = File.ReadAllText($"{dirname}/{fileName}") == File.ReadAllText($"{dirname}/{OUTPUT_DIR}/{fileName}");
                Console.ForegroundColor = equals ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("Example output files are " + (!equals ? "not " : "") + "equals");
                Console.ResetColor();
                return equals;
            }
            else
            {
                Console.WriteLine($"File {fileName} or {fileName.Replace(".in", ".out")} does not exist.");
                return false;
            }

        }
    }
}