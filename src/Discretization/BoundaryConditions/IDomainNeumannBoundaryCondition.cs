using System;

using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IDomainNeumannBoundaryCondition : IDomainNeumannBoundaryCondition<IDofType>
	{
	}

	public interface IDomainNeumannBoundaryCondition<out T> : IDomainBoundaryCondition<T> where T : IDofType
	{
	}
}
