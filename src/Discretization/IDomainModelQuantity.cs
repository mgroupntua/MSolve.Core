using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization
{
	public interface IDomainModelQuantity<out T> where T : IDofType
	{
		T DOF { get; }

		double Amount { get; }
		IDomainModelQuantity<T> WithAmount(double amount);
	}
}
