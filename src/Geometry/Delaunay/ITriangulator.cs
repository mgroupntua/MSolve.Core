namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public interface ITriangulator
	{
		Mesh Triangulate(IList<Vertex> points, Configuration config);
	}
}
