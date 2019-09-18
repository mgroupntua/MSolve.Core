using System.Collections.Generic;
using MGroup.MSolve.Geometry.Coordinates;
using MGroup.MSolve.Geometry.Shapes;

namespace MGroup.MSolve.Discretization.Mesh
{
    public class Polygonal2DBoundary: IDomain2DBoundary
    {
        private readonly ConvexPolygon2D polygon;

        public Polygonal2DBoundary(IReadOnlyList<CartesianPoint> vertices)
        {
            polygon = ConvexPolygon2D.CreateUnsafe(vertices); 
        }

        public bool IsInside(CartesianPoint point)
        {
            var pos = polygon.FindRelativePositionOfPoint(point);
            if (pos == PolygonPointPosition.Inside) return true;
            else return false;
        }
    }
}
