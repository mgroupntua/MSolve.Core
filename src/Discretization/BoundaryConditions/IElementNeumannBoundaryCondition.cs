using System;

using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IElementNeumannBoundaryCondition : IElementNeumannBoundaryCondition<IDofType>
	{
	}

	public interface IElementNeumannBoundaryCondition<out T> : IElementBoundaryCondition<T> where T : IDofType
	{
	}
}
