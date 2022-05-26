namespace MGroup.MSolve.Discretization.Embedding
{
	using MGroup.MSolve.Discretization.Entities;

	public interface IEmbeddedHostElement
	{
		EmbeddedNode BuildHostElementEmbeddedNode(IElementType element, INode node, IEmbeddedDOFInHostTransformationVector transformationVector);
		double[] GetShapeFunctionsForNode(IElementType element, EmbeddedNode node);
	}
}
