﻿using static System.ConsoleColor;
using static System.IO.Directory;
using static EbExtensionExecuter.Helpers.ColoredConsole;

namespace EbExtensionExecuter.Steps
{
    public class CreateDirectory : IStep
    {
        private readonly string _directory;

        public CreateDirectory(string directory)
        {
            _directory = directory;
        }

        public bool Execute()
        {
            WriteLine($"===== Create Directory: {_directory} =====", Yellow);
            WriteLine("Checking if directory exists");
            if (Exists(_directory))
            {
                WriteLine("Directory already exists", White);
            }
            else
            {
                WriteLine("Creating directory");
                CreateDirectory(_directory);
                WriteLine("Directory created");
            }
            WriteLine($"===== End Create Directory: {_directory} =====", Yellow);
            return true;
        }
    }
}
