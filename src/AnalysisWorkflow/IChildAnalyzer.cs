namespace MGroup.MSolve.AnalysisWorkflow
{
	using MGroup.LinearAlgebra.Iterative;
	using MGroup.LinearAlgebra.Vectors;

	public interface IChildAnalyzer : IAnalyzer
	{
		IterativeStatistics AnalysisStatistics { get; }
		IParentAnalyzer ParentAnalyzer { get; set; }

		public IVector CurrentAnalysisLinearSystemRhs { get; }
	}
}
