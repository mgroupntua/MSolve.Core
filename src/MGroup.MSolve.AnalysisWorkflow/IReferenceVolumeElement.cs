namespace MGroup.MSolve.AnalysisWorkflow
{
	using MGroup.LinearAlgebra.Matrices;
	using MGroup.MSolve.Discretization;

	public interface IReferenceVolumeElement
	{
		void ApplyBoundaryConditions();

		IMatrixView CalculateKinematicRelationsMatrix(ISubdomain subdomain);

		double CalculateRveVolume();
	}
}
