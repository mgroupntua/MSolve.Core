namespace MGroup.MSolve.AnalysisWorkflow
{
	using MGroup.LinearAlgebra.Vectors;

	public interface INonLinearSubdomainUpdater
	{
		void ScaleConstraints(double scalingFactor);

		IVector GetRhsFromSolution(IVectorView solution, IVectorView dSolution);

		void UpdateState();

		void ResetState();
	}
}
