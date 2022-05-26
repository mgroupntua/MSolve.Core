using System;
using System.Linq;
using System.Collections.Generic;
using MGroup.MSolve.Discretization.Entities;
using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public abstract class TransientBoundaryConditionSet<T> : ITransientBoundaryConditionSet<T> where T : IDofType
	{
		protected readonly IEnumerable<IBoundaryConditionSet<T>> boundaryConditionSets;
		protected readonly Func<double, double, double> timeFunc;

		public TransientBoundaryConditionSet(IEnumerable<IBoundaryConditionSet<T>> boundaryConditionSets, Func<double, double, double> timeFunc)
		{
			this.boundaryConditionSets = boundaryConditionSets;
			this.timeFunc = timeFunc;
		}

		public double CurrentTime { get; set; } = 0;

		public IEnumerable<IDomainBoundaryCondition<T>> EnumerateDomainBoundaryConditions()
			=> boundaryConditionSets.SelectMany(x => x.EnumerateDomainBoundaryConditions().Select(bc => bc.WithAmount(timeFunc(CurrentTime, bc.Amount))));

		public IEnumerable<INodalBoundaryCondition<T>> EnumerateNodalBoundaryConditions()
			=> boundaryConditionSets.SelectMany(x => x.EnumerateNodalBoundaryConditions().Select(bc => bc.WithAmount(timeFunc(CurrentTime, bc.Amount))));

		public abstract IEnumerable<INodalNeumannBoundaryCondition<T>> EnumerateEquivalentNodalNeumannBoundaryConditions(IEnumerable<IElementType> elements);

		public abstract IBoundaryConditionSet<T> CreateBoundaryConditionSetOfSubdomain(ISubdomain subdomain);
	}
}
