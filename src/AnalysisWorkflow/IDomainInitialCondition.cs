using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public interface IDomainInitialCondition<out T> : IDomainModelQuantity<T> where T : IDofType
	{
		DifferentiationOrder DifferentiationOrder { get; }

		IDomainInitialCondition<T> WithAmount(double amount);
	}
}
