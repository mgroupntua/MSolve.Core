using System.Collections.Generic;
using MGroup.MSolve.AnalysisWorkflow.Transient;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.BoundaryConditions;

namespace MGroup.MSolve.Discretization.Entities
{
    public interface IModel
    {
		int NumSubdomains { get; }

        void ConnectDataStructures();
		IEnumerable<IInitialConditionSet<IDofType>> EnumerateInitialConditions(int subdomainID);
		IEnumerable<IBoundaryConditionSet<IDofType>> EnumerateBoundaryConditions(int subdomainID);
		IEnumerable<INode> EnumerateNodes();

		//TODO: I could take all elements and filter them with an IPartitioner object. 
		//		Same goes for all entities that are based on INode or IElement. We can have INodalVectorContributor: INodeBasedEntity
		//		and IElementVectorContributor: IElementBasedEntity and always access them inside IEnumerable<>. 
		//		This will completely decouple model from subdomains, at least when all entities live in the same machine.
		IEnumerable<IElementType> EnumerateElements(int subdomainID);
		IEnumerable<ISubdomain> EnumerateSubdomains();
		INode GetNode(int nodeID);
		ISubdomain GetSubdomain(int subdomainID);

	}
}
