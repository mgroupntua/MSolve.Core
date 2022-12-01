using MGroup.MSolve.DataStructures;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface INonLinearProvider : IAnalyzerProvider
	{
		IGlobalVector CalculateResponseIntegralVector(IGlobalVector solution);
		double CalculateRhsNorm(IGlobalVector rhs);
		void ProcessInternalRhs(IGlobalVector solution, IGlobalVector rhs);
		void UpdateState(IHaveState externalState);
	}
}
