namespace MSolve.Core.Tests.Geometry
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using MGroup.MSolve.Geometry.Coordinates;
	using MGroup.MSolve.Geometry.Triangulation;

	public class Utilities
	{
		public static bool AreTrianglesEqual<TVertex>(Triangle2D<TVertex> triangleA, Triangle2D<TVertex> triangleB)
			where TVertex : class, IPoint
		{
			var pointsA = new List<TVertex>(triangleA.Vertices);
			var pointsB = new List<TVertex>(triangleB.Vertices);

			for (int p = 0; p < 3; p++)
			{
				TVertex pointA = pointsA[pointsA.Count - 1];
				TVertex pointB = null;
				foreach (TVertex trialB in pointsB)
				{
					if (ArePoints2DEqual(pointA, trialB))
					{
						pointB = trialB;
						break;
					}
				}

				if (pointB == null) // No points in triangle B matches this point of triangle A
				{
					return false;
				}
				else // Remove these 2 points from further comparisons
				{
					pointsA.RemoveAt(pointsA.Count - 1);
					pointsB.Remove(pointB);
				}
			}

			return true; // At this stage, every point in triangle A has a matching point in triangle B.
		}

		public static bool ArePoints2DEqual(IPoint pointA, IPoint pointB)
		{
			if (pointA.Coordinates.Length != pointB.Coordinates.Length)
			{
				return false;
			}

			for (int d = 0; d < pointA.Coordinates.Length; d++)
			{
				if (pointA.Coordinates[d] != pointB.Coordinates[d])
				{
					return false;
				}
			}
			
			return true;
		}

	}
}
