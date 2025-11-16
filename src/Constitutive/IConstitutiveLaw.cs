namespace MGroup.MSolve.Constitutive
{
	using System;

	using MGroup.LinearAlgebra.Matrices;
	using MGroup.MSolve.DataStructures;

	/// <summary>
	/// Interface for constitutive laws to be adhered to, for spatial discretization (e.g.: FEM) 
	/// </summary>
	public interface IConstitutiveLaw : ICreateState, ICloneable
	{
		IReadOnlyMatrix ConstitutiveMatrix { get; }

		double[] UpdateConstitutiveMatrixAndEvaluateResponse(double[] stimuli);
	}
}
