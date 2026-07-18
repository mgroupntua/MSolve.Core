namespace MSolve.Core.Tests.Geometry
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using MGroup.MSolve.Geometry.Coordinates;
	using MGroup.MSolve.Geometry.Triangulation;

	using Xunit;

	public class TriangulationTests
	{

		[Fact]
		public static void TestDealunyRectangle()
		{
			// 4--------5--------6
			// |\      /\      / |
			// | \    /  \    /  |
			// |  \  /    \  /   |
			// |   \/      \/    |
			// 0----1------2-----3

			var points = new CartesianPoint[7];
			points[0] = new CartesianPoint(0.0,  0.0);
			points[1] = new CartesianPoint(4.0,  0.0);
			points[2] = new CartesianPoint(8.0,  0.0);
			points[3] = new CartesianPoint(12.0, 0.0);
			points[4] = new CartesianPoint(0.0,  5.0);
			points[5] = new CartesianPoint(6.0,  5.0);
			points[6] = new CartesianPoint(12.0, 5.0);

			var trianglesExpected = new Triangle2D<CartesianPoint>[5];
			trianglesExpected[0] = new Triangle2D<CartesianPoint>(points[0], points[1], points[4]);
			trianglesExpected[1] = new Triangle2D<CartesianPoint>(points[1], points[5], points[4]);
			trianglesExpected[2] = new Triangle2D<CartesianPoint>(points[1], points[2], points[5]);
			trianglesExpected[3] = new Triangle2D<CartesianPoint>(points[2], points[6], points[5]);
			trianglesExpected[4] = new Triangle2D<CartesianPoint>(points[2], points[3], points[6]);

			var triangulator = new Triangulator2D<CartesianPoint>((x,y) => new CartesianPoint(x,y));
			IReadOnlyList<Triangle2D<CartesianPoint>> triangles = triangulator.CreateMesh(points);

			Assert.True(AreTriangulationsEqual(trianglesExpected, triangles));
		}

		private static bool AreTriangulationsEqual(
			IReadOnlyList<Triangle2D<CartesianPoint>> meshA, IReadOnlyList<Triangle2D<CartesianPoint>> meshB)
		{
			int numTriangles = meshA.Count;
			if (meshB.Count != numTriangles)
			{
				return false;
			}

			var trianglesA = new List<Triangle2D<CartesianPoint>>(meshA);
			var trianglesB = new List<Triangle2D<CartesianPoint>>(meshB);
			for (int t = 0; t < numTriangles; t++)
			{
				Triangle2D<CartesianPoint> triangleA = trianglesA[trianglesA.Count - 1];
				Triangle2D<CartesianPoint> triangleB = null;
				foreach (Triangle2D<CartesianPoint> trialB in trianglesB)
				{
					if (Utilities.AreTrianglesEqual(triangleA, trialB))
					{
						triangleB = trialB;
						break;
					}
				}

				if (triangleB == null) // No triangles in mesh B matches this triangle of mesh A
				{
					return false;
				}
				else // Remove these 2 triangles from further comparisons
				{
					trianglesA.RemoveAt(trianglesA.Count - 1);
					trianglesB.Remove(triangleB);
				}
			}

			return true; // At this stage, every triangle in mesh A has a matching triangle in mesh B.
		}
	}
}
