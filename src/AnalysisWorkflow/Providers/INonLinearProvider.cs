namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	using MGroup.LinearAlgebra.Vectors;
	using MGroup.MSolve.DataStructures;

	public interface INonLinearProvider : IAnalyzerProvider
	{
		IVector CalculateResponseIntegralVector(IVector solution);
		double CalculateRhsNorm(IVector rhs);
		void ProcessInternalRhs(IVector solution, IVector rhs);
		void UpdateState(IHaveState externalState);
	}
}
