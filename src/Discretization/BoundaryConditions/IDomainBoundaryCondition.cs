using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IDomainBoundaryCondition<out T> : IDomainModelQuantity<T> where T : IDofType
	{
		IDomainBoundaryCondition<T> WithMultiplier(double amount);
	}
}
