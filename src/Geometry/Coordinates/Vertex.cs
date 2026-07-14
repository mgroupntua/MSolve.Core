namespace MGroup.MSolve.Core.Geometry.Coordinates
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Vertex
	{
		internal int id;

		internal int label;

		internal double x;

		internal double y;

		public double this[int i] => i switch
		{
			0 => x,
			1 => y,
			_ => throw new ArgumentOutOfRangeException("Index must be 0 or 1."),
		};
	}
}
