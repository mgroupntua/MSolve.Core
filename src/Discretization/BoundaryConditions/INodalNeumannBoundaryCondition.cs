using System;

using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface INodalNeumannBoundaryCondition : INodalNeumannBoundaryCondition<IDofType>
	{
	}

	public interface INodalNeumannBoundaryCondition<out T> : INodalBoundaryCondition<T> where T : IDofType
	{
	}
}
