using System;
using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.DataStructures;

namespace MGroup.MSolve.Constitutive
{
	/// <summary>
	/// Interface for constitutive laws to be adhered to, for spatial discretization (e.g.: FEM) 
	/// </summary>
	public interface IConstitutiveLaw : ICreateState, ICloneable
	{
		IMatrixView ConstitutiveMatrix { get; }
		double[] UpdateConstitutiveMatrixAndEvaluateResponse(double[] stimuli);
	}
}
