namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Configuration
	{
		public Configuration()
			: this(() => RobustPredicates.Default, () => new TrianglePool())
		{
		}

		public Configuration(Func<IPredicates> predicates)
			: this(predicates, () => new TrianglePool())
		{
		}

		public Configuration(Func<IPredicates> predicates, Func<TrianglePool> trianglePool)
		{
			Predicates = predicates;
			TrianglePool = trianglePool;
		}

		public Func<IPredicates> Predicates { get; set; }

		public Func<TrianglePool> TrianglePool { get; set; }
	}
}
