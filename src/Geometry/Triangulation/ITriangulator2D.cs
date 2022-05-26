using System.Collections.Generic;
using MGroup.MSolve.Geometry.Coordinates;

namespace MGroup.MSolve.Geometry.Triangulation
{
    public interface ITriangulator2D<TVertex> where TVertex : IPoint
    {
        IReadOnlyList<Triangle2D<TVertex>> CreateMesh(IEnumerable<TVertex> points);
        IReadOnlyList<Triangle2D<TVertex>> CreateMesh(IEnumerable<TVertex> points, double maxTriangleArea);
    }
}
