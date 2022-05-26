using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IDomainBoundaryCondition<out T> where T : IDofType
	{
		T DOF { get; }

		double Amount { get; }
		IDomainBoundaryCondition<T> WithAmount(double amount);
	}
}
