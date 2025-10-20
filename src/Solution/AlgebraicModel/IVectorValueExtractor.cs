namespace MGroup.MSolve.Solution.AlgebraicModel
{
	using System.Collections.Generic;

	using MGroup.LinearAlgebra.Vectors;
	using MGroup.MSolve.Discretization;
	using MGroup.MSolve.Discretization.Dofs;
	using MGroup.MSolve.Discretization.Entities;

	public interface IVectorValueExtractor
	{
		/// <summary>
		/// If the requested <paramref name="element"/> has dofs that are not included in <paramref name="vector"/>,
		/// then the corresponding entries of the returned vector will be 0.
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="element"></param>
		/// <returns></returns>
		double[] ExtractElementVector(IVector vector, IElementType element);

		double[] ExtractNodalValues(IVector vector, INode node, IDofType[] dofs);

		/// <summary>
		/// If the requested (<paramref name="node"/>, <paramref name="dof"/>) pair is not a free dof or otherwise not included 
		/// in <paramref name="vector"/>, then <see cref="KeyNotFoundException"/> will be thrown.
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="node"></param>
		/// <param name="dof"></param>
		/// <returns></returns>
		double ExtractSingleValue(IVector vector, INode node, IDofType dof); //TODO: Also support batch requests
	}
}
