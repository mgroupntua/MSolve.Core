using System.Collections.Generic;

using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public interface IInitialConditionSet : IInitialConditionSet<IDofType>
	{
	}

	public interface IInitialConditionSet<out T> where T : IDofType
	{
		/// <summary>
		/// Get equivalent nodal initial conditions.
		/// </summary>
		/// <returns>IEnumerable<INodalBoundaryCondition></returns>
		IEnumerable<INodalInitialCondition<T>> EnumerateNodalInitialConditions();
		//IEnumerable<IDomainInitialCondition<T>> EnumerateDomainInitialConditions();
		IInitialConditionSet<T> CreateInitialConditionSetOfSubdomain(ISubdomain subdomain);
	}
}
