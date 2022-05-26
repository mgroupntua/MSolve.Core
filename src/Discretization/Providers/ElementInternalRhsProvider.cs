using System;
using System.Collections.Generic;
using System.Text;

namespace MGroup.MSolve.Discretization.Providers
{
	public class ElementInternalRhsProvider : IElementVectorProvider
	{
		public double[] CalcVector(IElementType element) => element.CalculateResponseIntegral();
	}
}
