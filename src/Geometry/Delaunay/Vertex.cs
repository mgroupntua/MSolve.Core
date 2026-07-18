namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Vertex : Point
	{
		internal int hash;
		internal VertexType type;

		internal Vertex(double x, double y)
			: this(x, y, 0)
		{
		}

		internal Vertex(double x, double y, int label)
			: base(x, y, label)
		{
			type = VertexType.InputVertex;
		}

		public double this[int i] => i switch
		{
			0 => x,
			1 => y,
			_ => throw new ArgumentOutOfRangeException("Index must be 0 or 1."),
		};
	}
}
