using System;

using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IDomainDirichletBoundaryCondition : IDomainDirichletBoundaryCondition<IDofType>
	{
	}

	public interface IDomainDirichletBoundaryCondition<out T> : IDomainBoundaryCondition<T> where T : IDofType
	{
	}
}
