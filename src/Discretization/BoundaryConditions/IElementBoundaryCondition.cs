using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface IElementBoundaryCondition<out T> : IElementModelQuantity<T> where T : IDofType
	{
		IElementBoundaryCondition<T> WithMultiplier(double amount);
	}
}
