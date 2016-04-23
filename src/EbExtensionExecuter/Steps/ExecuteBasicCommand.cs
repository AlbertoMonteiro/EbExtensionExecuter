using System;
using System.Diagnostics;
using static System.ConsoleColor;
using static System.IO.File;
using static EbExtensionExecuter.Helpers.ColoredConsole;

namespace EbExtensionExecuter.Steps
{
    public class ExecuteBasicCommand : IStep
    {
        private readonly string _exe;
        private readonly string _arguments;
        private bool _checkIfExeExists;
        private bool _waitForExit;

        public ExecuteBasicCommand(string exe, string arguments)
        {
            _exe = exe;
            _arguments = arguments;
        }

        public bool Execute()
        {
            WriteLine($"===== Execute basic command: {_exe} =====", Yellow);
            if (!_checkIfExeExists)
                return ExecuteExe();

            WriteLine("Checking if exe exists");
            if (Exists(_exe))
            {
                WriteLine("The exe exists");
                return ExecuteExe();
            }
            WriteLine("The does not exe exists", Red);
            return true;
        }

        public ExecuteBasicCommand CheckIfExeExists()
        {
            _checkIfExeExists = true;
            return this;
        }

        private bool ExecuteExe()
        {
            var startInfo = new ProcessStartInfo(_exe, _arguments) { UseShellExecute = false };
            var process = new Process { StartInfo = startInfo };
            WriteLine($"Executing: {startInfo.FileName} {startInfo.Arguments}");
            process.Start();
            _waitForExit = process.WaitForExit((int)TimeSpan.FromSeconds(10).TotalMilliseconds);
            WriteLine($"Executed: {startInfo.FileName} {startInfo.Arguments}");
            WriteLine($"===== End Execute basic command: {_exe} =====", Yellow);
            return _waitForExit;
        }
    }
}