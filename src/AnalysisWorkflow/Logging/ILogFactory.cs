//TODO: The logs should be created by the user and injected into the analyzers. This way they are accessible by the
//      user during and after the analysis.
namespace MGroup.MSolve.AnalysisWorkflow.Logging
{
    /// <summary>
    /// Used by the analyzers to create the logs.
    /// </summary>
    public interface ILogFactory
    {
        IAnalysisWorkflowLog[] CreateLogs();
    }
}
