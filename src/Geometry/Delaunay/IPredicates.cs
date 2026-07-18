namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public interface IPredicates
	{
		double CounterClockwise(Point a, Point b, Point c);

		double InCircle(Point a, Point b, Point c, Point p);
	}
}
