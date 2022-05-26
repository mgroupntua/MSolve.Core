using System;
using System.Collections.Generic;

namespace MGroup.MSolve.Discretization.Entities
{
    public interface INode : IDiscretePoint, IComparable<INode>
    {
		double X { get; }
		double Y { get; }
		double Z { get; }

		Dictionary<int, IElementType> ElementsDictionary { get; }

		HashSet<int> Subdomains { get; }
    }
}
