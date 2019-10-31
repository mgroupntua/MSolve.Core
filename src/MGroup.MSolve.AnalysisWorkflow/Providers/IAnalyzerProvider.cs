using MGroup.MSolve.Discretization.Loads;

namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface IAnalyzerProvider
	{
		//TODO: This should be accessed by the solver. Any element matrix providers should be passed there.
		IDirichletEquivalentLoadsAssembler DirichletLoadsAssembler { get; }
		void ClearMatrices();
		void Reset();
	}
}
