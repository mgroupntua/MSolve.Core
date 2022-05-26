using System;
using System.Collections.Generic;
using System.Text;

using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.Solution.AlgebraicModel
{
	/// <summary>
	/// This component is responsible for the linear algebra representation, namely global vectors and matrices, of the physical 
	/// model. It is also responsible for conversions between the physical and algebraic representations.  
	/// </summary>
	public interface IAlgebraicModel : IGlobalMatrixAssembler, IGlobalVectorAssembler, IVectorValueExtractor, IElementIterator 
	{
		IGlobalLinearSystem LinearSystem { get; }
		//TODO: Goat - remove the setter and define a solution workflow object that will initialize this at its constructor
		public IAlgebraicModelInterpreter BoundaryConditionsInterpreter { get; set; }
		void OrderDofs();

		/// <summary>
		/// Same effect as <see cref="OrderDofs"/>, but avoids repeating dof ordering computations from previous analysis 
		/// iterations, as much as possible.
		/// </summary>
		void ReorderDofs();
	}
}
