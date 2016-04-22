namespace EbExtensionExecuter.Steps
{
    public interface IStepsExecutor
    {
        void Add(IStep step);
        void ExecuteAll();
    }
}