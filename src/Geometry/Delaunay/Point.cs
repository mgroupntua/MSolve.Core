namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Point
	{
		internal int id;

		internal int label;

		internal double x;

		internal double y;

		internal Point(double x, double y)
		: this(x, y, 0)
		{
		}

		internal Point(double x, double y, int label)
		{
			this.x = x;
			this.y = y;
			this.label = label;
		}
	}
}
