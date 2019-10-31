using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.Discretization;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IReferenceVolumeElement
	{
		void ApplyBoundaryConditions();
		IMatrixView CalculateKinematicRelationsMatrix(ISubdomain subdomain);
		double CalculateRveVolume();
	}
}
