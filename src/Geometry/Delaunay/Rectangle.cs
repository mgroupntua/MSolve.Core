namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	internal class Rectangle
	{
		private double xmax;
		private double xmin;
		private double ymax;
		private double ymin;

		public Rectangle()
		{
			xmin = (ymin = double.MaxValue);
			xmax = (ymax = double.MinValue);
		}

		public void Expand(Point p)
		{
			xmin = Math.Min(xmin, p.x);
			ymin = Math.Min(ymin, p.y);
			xmax = Math.Max(xmax, p.x);
			ymax = Math.Max(ymax, p.y);
		}
	}
}
