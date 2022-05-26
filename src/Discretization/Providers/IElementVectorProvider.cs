using System;
using System.Collections.Generic;
using System.Text;

namespace MGroup.MSolve.Discretization.Providers
{
	public interface IElementVectorProvider
	{
		double[] CalcVector(IElementType element);
	}
}
