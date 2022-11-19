using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface INodalBoundaryCondition : INodalBoundaryCondition<IDofType>
	{

	}

	public interface INodalBoundaryCondition<out T> : INodalModelQuantity<T> where T : IDofType
	{
		INodalBoundaryCondition<T> WithAmount(double amount);
	}
}
