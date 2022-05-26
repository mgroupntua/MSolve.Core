using System.Collections.Generic;

using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Discretization.Embedding
{
	public interface IEmbeddedElement
	{
		IList<EmbeddedNode> EmbeddedNodes { get; }
		Dictionary<IDofType, int> GetInternalNodalDOFs(IElementType element, INode node);
		double[] GetLocalDOFValues(IElementType hostElement, double[] hostDOFValues);
	}
}
