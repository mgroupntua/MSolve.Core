using System;
using System.Collections.Generic;
using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Geometry.Coordinates;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Numerics.Interpolation
{
	/// <summary>
	/// Authors: Serafeim Bakalakos, Dimitris Tsapetis
	/// </summary>
	public static class InterpolationUtilities
	{
		public static CartesianPoint TransformPointNaturalToGlobalCartesian(IReadOnlyList<INode> nodes,
			Vector shapeFunctionsAtNaturalPoint)
		{
			int numFuncs = shapeFunctionsAtNaturalPoint.Length;
			if (nodes.Count != numFuncs) throw new ArgumentException(
				$"There are {numFuncs} evaluated shape functions stored, but {nodes.Count} were passed in.");
			double x = 0, y = 0;
			for (int i = 0; i < numFuncs; ++i)
			{
				INode node = nodes[i];
				double val = shapeFunctionsAtNaturalPoint[i];
				x += val * node.X;
				y += val * node.Y;
			}
			return new CartesianPoint(x, y);
		}

		public static CartesianPoint TransformPointToGlobalCartesian(IReadOnlyList<INode> nodes,
			Vector shapeFunctionsAtNaturalPoint)
		{
			int numFuncs = shapeFunctionsAtNaturalPoint.Length;
			if (nodes.Count != numFuncs) throw new ArgumentException(
				$"There are {numFuncs} evaluated shape functions stored, but {nodes.Count} were passed in.");
			double x = 0, y = 0, z = 0;
			for (int i = 0; i < numFuncs; ++i)
			{
				INode node = nodes[i];
				double val = shapeFunctionsAtNaturalPoint[i];
				x += val * node.X;
				y += val * node.Y;
				z += val * node.Z;
			}

			return new CartesianPoint(x, y, z);
		}
	}
}
