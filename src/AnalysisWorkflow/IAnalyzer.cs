using System.Collections.Generic;
using MGroup.MSolve.AnalysisWorkflow.Logging;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IAnalyzer
	{
		IAnalysisWorkflowLog[] Logs { get; }

		void BuildMatrices(); //This makes sense for parent analyzers only.

		void Initialize(bool isFirstAnalysis);

		void Solve();
	}
}
