using System;
using System.Collections.Generic;

using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IBoundaryConditionSet : IBoundaryConditionSet<IDofType>
	{
	}

	public interface IBoundaryConditionSet<out T> where T : IDofType
	{
		/// <summary>
		/// Get equivalent Nodal Boundary Conditions.
		/// </summary>
		/// <returns>IEnumerable<INodalBoundaryCondition></returns>
		IEnumerable<INodalBoundaryCondition<T>> EnumerateNodalBoundaryConditions(IEnumerable<IElementType> elements);
		//IEnumerable<IDomainBoundaryCondition<T>> EnumerateDomainBoundaryConditions();
		IEnumerable<INodalNeumannBoundaryCondition<T>> EnumerateEquivalentNodalNeumannBoundaryConditions(IEnumerable<IElementType> elements, IEnumerable<(int NodeID, IDofType DOF)> dofsToExclude);
		IBoundaryConditionSet<T> CreateBoundaryConditionSetOfSubdomain(ISubdomain subdomain);
	}
}
