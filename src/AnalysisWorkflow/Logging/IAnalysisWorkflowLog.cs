namespace MGroup.MSolve.AnalysisWorkflow.Logging
{
	using System;

	using MGroup.LinearAlgebra.Vectors;

	public interface IAnalysisWorkflowLog
	{
		void StoreResults(DateTime startTime, DateTime endTime, IVector solution);
	}
}
