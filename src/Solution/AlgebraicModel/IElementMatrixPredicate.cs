using System;
using System.Collections.Generic;
using System.Text;
using MGroup.MSolve.Discretization;

//TODO: Perhaps this functionality can be included in the IElementMatrixProvider. This is more loosely coupled though.
namespace MGroup.MSolve.Solution.AlgebraicModel
{
	public interface IElementMatrixPredicate 
	{
		bool MustBuildMatrixForElement(IElementType element);

		void ProcessElementAfterBuildingMatrix(IElementType element);

		void ProcessElementAfterNotBuildingMatrix(IElementType element);

	}
}
