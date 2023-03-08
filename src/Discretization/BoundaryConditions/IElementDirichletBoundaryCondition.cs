using System;

using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IElementDirichletBoundaryCondition : IElementDirichletBoundaryCondition<IDofType>
	{
	}

	public interface IElementDirichletBoundaryCondition<out T> : IElementBoundaryCondition<T> where T : IDofType
	{
	}
}
