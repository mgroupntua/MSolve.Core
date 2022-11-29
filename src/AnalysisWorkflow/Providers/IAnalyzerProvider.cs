using MGroup.MSolve.Discretization.BoundaryConditions;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Solution.LinearSystem;

using System.Collections.Generic;

namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface IAnalyzerProvider
	{
		void Reset();
		IEnumerable<INodalNeumannBoundaryCondition<IDofType>> EnumerateEquivalentNeumannBoundaryConditions(int subdomainID);
	}
}
