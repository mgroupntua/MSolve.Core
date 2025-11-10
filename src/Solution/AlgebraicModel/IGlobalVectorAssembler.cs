namespace MGroup.MSolve.Solution.AlgebraicModel
{
	using System;
	using System.Collections.Generic;

	using MGroup.LinearAlgebra.Vectors;
	using MGroup.MSolve.Discretization;
	using MGroup.MSolve.Discretization.Dofs;
	using MGroup.MSolve.Discretization.Providers;

	public interface IGlobalVectorAssembler
	{
		IVector CreateZeroVector();
		void AddToGlobalVector(IVector vector, IElementVectorProvider vectorProvider);
		void AddToGlobalVector(Func<int, IEnumerable<INodalModelQuantity<IDofType>>> accessLoads, IVector vector);
		// void AddToGlobalVector(IEnumerable<IDomainModelQuantity<IDofType>> loads, IVector vector);
	}
}
