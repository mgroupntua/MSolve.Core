using System;
using System.Collections.Generic;
using System.Text;
using MGroup.MSolve.Solution.LinearSystem;
using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Solution.AlgebraicModel
{
	public interface IVectorValueExtractor
	{
		/// <summary>
		/// If the requested <paramref name="element"/> has dofs that are not included in <paramref name="vector"/>,
		/// then the corresponding entries of the returned vector will be 0.
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="element"></param>
		/// <returns></returns>
		double[] ExtractElementVector(IGlobalVector vector, IElementType element);

		double[] ExtractNodalValues(IGlobalVector vector, INode node, IDofType[] dofs);

		/// <summary>
		/// If the requested (<paramref name="node"/>, <paramref name="dof"/>) pair is not a free dof or otherwise not included 
		/// in <paramref name="vector"/>, then <see cref="KeyNotFoundException"/> will be thrown.
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="node"></param>
		/// <param name="dof"></param>
		/// <returns></returns>
		double ExtractSingleValue(IGlobalVector vector, INode node, IDofType dof); //TODO: Also support batch requests
	}
}
