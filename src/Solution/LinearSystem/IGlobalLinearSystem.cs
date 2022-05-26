using System.Collections.Generic;

namespace MGroup.MSolve.Solution.LinearSystem
{
	/// <summary>
	/// A system of linear equations. It consists of a square matrix, a right hand side vector and a solution (or left 
	/// hand side) vector. In general objects implementing IAnalyzer determine the matrix and right hand side vector,  
	/// while objects implementing ISolver calculate the solution vector.
	/// </summary>
	public interface IGlobalLinearSystem
	{
		HashSet<ILinearSystemObserver> Observers { get; }

		IGlobalMatrix Matrix { get; set; }

		IGlobalVector RhsVector { get; set; }

		IGlobalVector Solution { get; }
	}
}
