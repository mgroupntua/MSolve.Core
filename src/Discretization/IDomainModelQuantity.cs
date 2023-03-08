using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization
{
	public interface IDomainModelQuantity<out T> where T : IDofType
	{
		T DOF { get; }
		double Multiplier { get; }

		IDomainModelQuantity<T> WithMultiplier(double multiplier);
		double Amount(double[] coordinates);
	}
}
