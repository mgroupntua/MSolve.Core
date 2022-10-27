using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IChildAnalyzer : IAnalyzer
	{
		IParentAnalyzer ParentAnalyzer { get; set; }

		public IGlobalVector CurrentAnalysisLinearSystemRhs { get; }
	}
}
