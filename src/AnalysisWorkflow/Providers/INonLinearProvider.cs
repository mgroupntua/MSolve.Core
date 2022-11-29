using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface INonLinearProvider : IAnalyzerProvider
	{
		double CalculateRhsNorm(IGlobalVector rhs);
		void ProcessInternalRhs(IGlobalVector solution, IGlobalVector rhs);
	}
}
