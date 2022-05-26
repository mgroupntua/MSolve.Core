using System;

using MGroup.MSolve.Discretization.Entities;
using MGroup.MSolve.Geometry.Coordinates;
namespace MGroup.MSolve.Discretization
{
	public static class Helper
    {
        public static double CalculateDistanceFrom(this INode n1, CartesianPoint other) //TODO: this should be implemented for IPoint
        {
            double dx = n1.X - other.X;
            double dy = n1.Y - other.Y;
            double dz = n1.Z - other.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

		public static double CalculateDistanceFrom(this INode n1, INode other) //TODO: this should be implemented for IPoint
		{
			double dx = n1.X - other.X;
			double dy = n1.Y - other.Y;
			double dz = n1.Z - other.Z;
			return Math.Sqrt(dx * dx + dy * dy + dz * dz);
		}
	}
}

