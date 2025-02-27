namespace Paintvale.BuildValidationTasks
{
    public interface IValidationTask
    {
        public bool Execute(string projectPath, bool isGitRunner);
    }
}
