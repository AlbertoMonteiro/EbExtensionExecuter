using static System.ConsoleColor;
using static System.IO.Directory;
using static EbExtensionExecuter.Helpers.ColoredConsole;

namespace EbExtensionExecuter.Steps
{
    public class RemoveDirectory : IStep
    {
        private readonly string _directory;

        public RemoveDirectory(string directory)
        {
            _directory = directory;
        }

        public bool Execute()
        {
            WriteLine($"===== Remove Directory: {_directory} =====", Yellow);
            WriteLine("Checking if directory exists");
            if (Exists(_directory))
            {
                WriteLine("Removing directory");
                Delete(_directory, true);
                WriteLine("Directory removed");
            }
            else
                WriteLine("Directory already exists");
            WriteLine($"===== End Remove Directory: {_directory} =====", Yellow);
            return true;
        }
    }
}