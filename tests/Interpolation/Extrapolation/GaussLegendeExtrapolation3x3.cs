using System;
using MGroup.MSolve.Numerics.Interpolation.GaussPointExtrapolation;
using MGroup.MSolve.Numerics.Integration.Quadratures;
using MGroup.Tests.Commons;
using Xunit;

namespace MGroup.MSolve.Numerics.Tests.Interpolation.Extrapolation
{
	/// <summary>
	/// Unit testing for <see cref="ExtrapolationGaussLegendre3x3"/>.
	/// Authors: Serafeim Bakalakos
	/// </summary>
	public class GaussLegendeExtrapolation3x3
	{
		[Fact]
		private static void ExtrapolateToGaussPoints()
		{
			Assert.True(false);
			//double tolerance = 1e-10;
			//var extrapolation = ExtrapolationGaussLegendre3x3.UniqueInstance;
			//var gaussPoints = GaussLegendre2D.GetQuadratureWithOrder(3, 3).IntegrationPoints;

			//for (int i = 0; i < gaussPoints.Count; ++i)
			//{
			//	var scalarsAtGPs = new double[9];
			//	scalarsAtGPs[i] = 1.0;
			//	for (int j = 0; j < gaussPoints.Count; ++j)
			//	{
			//		double extrapolatedScalar = extrapolation.ExtrapolateScalarFromGaussPoints(scalarsAtGPs, gaussPoints[j]);
			//		if (j == i) Assert.True(Utilities.AreValuesEqual(1.0, extrapolatedScalar, tolerance));
			//		else Assert.True(Utilities.AreValuesEqual(0.0, extrapolatedScalar, tolerance));
			//	}
			//}
		}

		private static void ExtrapolateToNodes()
		{
			throw new NotImplementedException("I need to calclate these myself first.");
		}
	}
}
