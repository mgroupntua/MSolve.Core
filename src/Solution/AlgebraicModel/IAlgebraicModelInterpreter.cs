using System.Collections.Generic;

using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Entities;
using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Solution.AlgebraicModel
{
	public interface IAlgebraicModelInterpreter
	{
		ActiveDofs ActiveDofs { get; }
		IDictionary<(int NodeID, IDofType DOF), (int Index, INode Node, double Amount)> GetDirichletBoundaryConditionsWithNumbering();
		IDictionary<(int NodeID, IDofType DOF), (int Index, INode Node, double Amount)> GetDirichletBoundaryConditionsWithNumbering(int subdomainID);
	}
}
