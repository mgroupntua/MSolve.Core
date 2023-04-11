namespace MGroup.MSolve.AnalysisWorkflow
{
	using System.Collections;
	using System.Collections.Generic;

	using MGroup.LinearAlgebra.Iterative;

	public interface IParentAnalyzer : IAnalyzer
	{
		IList<IterativeStatistics> AnalysisStatistics { get; }
		IChildAnalyzer ChildAnalyzer { get; }
		void BuildMatrices();
	}
}
