using System.Collections.Generic;
using static System.ConsoleColor;
using static EbExtensionExecuter.Helpers.ColoredConsole;

namespace EbExtensionExecuter.Steps
{
    public class StepsExecutor : IStepsExecutor
    {
        private readonly IList<IStep> _steps = new List<IStep>();

        public void Add(IStep step)
        {
            _steps.Add(step);
        }

        public void ExecuteAll()
        {
            foreach (var step in _steps)
            {
                var @continue = step.Execute();
                if (!@continue)
                    break;
                WriteLine("");
            }
            WriteLine("All steps executed", Green);
        }
    }
}