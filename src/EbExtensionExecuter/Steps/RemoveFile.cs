using static System.ConsoleColor;
using static System.IO.File;
using static EbExtensionExecuter.Helpers.ColoredConsole;

namespace EbExtensionExecuter.Steps
{
    public class RemoveFile : IStep
    {
        private readonly string _filePath;

        public RemoveFile(string filePath)
        {
            _filePath = filePath;
        }

        public bool Execute()
        {
            WriteLine($"===== Remove File: {_filePath} =====", Yellow);
            WriteLine("Checking if file exists");
            if (Exists(_filePath))
            {
                WriteLine("Removing file");
                Delete(_filePath);
                WriteLine("File removed");
            }
            else
                WriteLine("File does not exists");
            WriteLine($"===== End Remove file: {_filePath} =====", Yellow);
            return true;
        }
    }
}