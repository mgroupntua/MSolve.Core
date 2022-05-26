namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IParentAnalyzer: IAnalyzer
	{
		IChildAnalyzer ChildAnalyzer { get; }
	}
}
