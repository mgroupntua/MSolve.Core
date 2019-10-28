using MGroup.LinearAlgebra.Matrices;

namespace MGroup.MSolve.Constitutive
{
	public interface IContinuumMaterial3D : IFiniteElementMaterial
	{
		/// <summary>
		/// Interface for materials laws implementations to be used in 3D finite elements
		/// </summary>
		double[] Stresses { get; }
		IMatrixView ConstitutiveMatrix { get; }
		void UpdateMaterial(double[] strains);
	}
}
