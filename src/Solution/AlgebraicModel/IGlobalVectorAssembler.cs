using System;
using System.Collections.Generic;
using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Providers;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.Solution.AlgebraicModel
{
	public interface IGlobalVectorAssembler
	{
		IGlobalVector CreateZeroVector();
		void AddToGlobalVector(IGlobalVector vector, IElementVectorProvider vectorProvider);
		void AddToGlobalVector(Func<int, IEnumerable<INodalModelQuantity<IDofType>>> accessLoads, IGlobalVector vector);
		// void AddToGlobalVector(IEnumerable<IDomainModelQuantity<IDofType>> loads, IGlobalVector vector);
	}
}
