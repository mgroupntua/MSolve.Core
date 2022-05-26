using System;

using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface INodalDirichletBoundaryCondition : INodalDirichletBoundaryCondition<IDofType>
	{
	}

	public interface INodalDirichletBoundaryCondition<out T> : INodalBoundaryCondition<T> where T : IDofType
	{
	}
}
