namespace MGroup.MSolve.Solution.LinearSystem
{
	using System.Collections.Generic;

	using MGroup.LinearAlgebra.Matrices;
	using MGroup.LinearAlgebra.Vectors;

	/// <summary>
	/// A system of linear equations. It consists of a square matrix, a right hand side vector and a solution (or left 
	/// hand side) vector. In general objects implementing IAnalyzer determine the matrix and right hand side vector,  
	/// while objects implementing ISolver calculate the solution vector.
	/// </summary>
	public interface IGlobalLinearSystem
	{
		HashSet<ILinearSystemObserver> Observers { get; }

		IMatrix Matrix { get; set; }

		IVector RhsVector { get; set; }

		IVector Solution { get; set; }
	}
}
