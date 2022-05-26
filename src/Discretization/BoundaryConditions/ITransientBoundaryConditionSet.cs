using System;
using System.Collections.Generic;

using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface ITransientBoundaryConditionSet<out T> : IBoundaryConditionSet<T> where T : IDofType
	{
		double CurrentTime { get; set; }
	}
}
