using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public interface INodalInitialCondition : INodalInitialCondition<IDofType>
	{

	}

	public interface INodalInitialCondition<out T> : INodalModelQuantity<T> where T : IDofType
	{
		DifferentiationOrder DifferentiationOrder { get; }

		INodalInitialCondition<T> WithAmount(double amount);
	}
}
