namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IChildAnalyzer: IAnalyzer
	{
		IParentAnalyzer ParentAnalyzer { get; set; }
	}
}
