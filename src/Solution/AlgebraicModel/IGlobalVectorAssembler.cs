using System;
using System.Collections.Generic;
using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.BoundaryConditions;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Providers;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.Solution.AlgebraicModel
{
	public interface IGlobalVectorAssembler
	{
		void AddToGlobalVector(IGlobalVector vector, IElementVectorProvider vectorProvider);

		//void AddToGlobalVector(Func<int, IEnumerable<IElementBoundaryCondition>> acessLoads, IGlobalVector vector); // to go


		void AddToGlobalVector(Func<int, IEnumerable<INodalBoundaryCondition<IDofType>>> accessLoads, IGlobalVector vector);


		void AddToGlobalVector(IEnumerable<IDomainBoundaryCondition<IDofType>> loads, IGlobalVector vector);

		IGlobalVector CreateZeroVector();
	}
}
