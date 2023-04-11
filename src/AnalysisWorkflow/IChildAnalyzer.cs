using MGroup.LinearAlgebra.Iterative;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IChildAnalyzer : IAnalyzer
	{
		IterativeStatistics AnalysisStatistics { get; }
		IParentAnalyzer ParentAnalyzer { get; set; }

		public IGlobalVector CurrentAnalysisLinearSystemRhs { get; }
	}
}
