using MGroup.MSolve.Discretization.BoundaryConditions;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Solution.LinearSystem;

using System.Collections.Generic;

namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface IAnalyzerProvider
	{
		void AssignRhs();

		void ClearMatrices();

		void Reset();

		//void GetProblemDofTypes();
		// TODO: This should be removed as EquivalentNeumannBoundaryConditions can be calculated a priori, at AssignRhs()
		IEnumerable<INodalNeumannBoundaryCondition<IDofType>> EnumerateEquivalentNeumannBoundaryConditions(int subdomainID);
	}
}
