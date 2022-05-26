using System;
using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow.Logging
{
    public interface IAnalysisWorkflowLog
    {
        void StoreResults(DateTime startTime, DateTime endTime, IGlobalVector solution);
    }
}
