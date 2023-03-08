using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Discretization
{
	public interface IElementModelQuantity : IElementModelQuantity<IDofType>
	{

	}

	public interface IElementModelQuantity<out T> where T : IDofType
	{
		T DOF { get; }
		IElementType Element { get; }
		double Multiplier { get; }

		IElementModelQuantity<T> WithMultiplier(double multiplier);
		double[] Amount(double[] coordinates);
	}
}
