using System;
using System.Collections.Generic;
using System.Linq;
using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Entities;
using MGroup.MSolve.Discretization.Embedding;
using MGroup.MSolve.Discretization.BoundaryConditions;
using MGroup.MSolve.Discretization.Dofs;

//TODO: find what is going on with the dynamic loads and refactor them. That 564000000 in AssignMassAccelerationHistoryLoads()
//      cannot be correct.
//TODO: ConnectDataStructures() should not be called twice. There should be a flag that determines if it has been called. If it
//      has, the method should just return without doing anything.
//TODO: Replace all IList with IReadOnlyList. Even better, have a different class to create the model than the one used to 
//      store the entities, so that they can be accessed by solvers, analyzers & loggers. Could the latter be the same for FEM, 
//      IGA, XFEM?

namespace MGroup.MSolve.Discretization.Entities
{
	public class Model : IModel
	{
		public Dictionary<int, INode> NodesDictionary { get; } = new Dictionary<int, INode>();

		public Dictionary<int, IElementType> ElementsDictionary { get; } = new Dictionary<int, IElementType>();

		public IList<IBoundaryConditionSet<IDofType>> BoundaryConditions { get; } = new List<IBoundaryConditionSet<IDofType>>();

		public int NumSubdomains => SubdomainsDictionary.Count;

		public Dictionary<int, Subdomain> SubdomainsDictionary { get; } = new Dictionary<int, Subdomain>();

		// Warning: This is called by the analyzer, so that the user does not have to call it explicitly. However, it is must be 
		// called explicitly before the AutomaticDomainDecompositioner is used.
		public void ConnectDataStructures()
		{
			BuildInterconnectionData();
			RemoveInactiveNodalLoads();

			//TODOSerafeim: This should be called by the analyzer, which defines when the dofs are ordered and when the global vectors/matrices are built.
			//AssignLoads();
		}

		public IEnumerable<IBoundaryConditionSet<IDofType>> EnumerateBoundaryConditions(int subdomainID) => 
			BoundaryConditions.Select(x => x.CreateBoundaryConditionSetOfSubdomain(SubdomainsDictionary[subdomainID]));

		public IEnumerable<IElementType> EnumerateElements(int subdomainID) => SubdomainsDictionary[subdomainID].Elements;

		public IEnumerable<INode> EnumerateNodes() => NodesDictionary.Values;

		public IEnumerable<ISubdomain> EnumerateSubdomains() => SubdomainsDictionary.Values;

		public INode GetNode(int nodeID) => NodesDictionary[nodeID];

		public ISubdomain GetSubdomain(int subdomainID) => SubdomainsDictionary[subdomainID];

		private void BuildElementDictionaryOfEachNode()
		{
			foreach (IElementType element in ElementsDictionary.Values)
			{
				foreach (Node node in element.Nodes) node.ElementsDictionary[element.ID] = element;
			}
		}

		private void BuildInterconnectionData()//TODOMaria: maybe I have to generate the constraints dictionary for each subdomain here
		{
			BuildSubdomainOfEachElement();
			DuplicateInterSubdomainEmbeddedElements();
			BuildElementDictionaryOfEachNode();
			foreach (Node node in NodesDictionary.Values) node.FindAssociatedSubdomains();

			//BuildNonConformingNodes();

			foreach (Subdomain subdomain in SubdomainsDictionary.Values) subdomain.DefineNodesFromElements();
		}

		private void BuildSubdomainOfEachElement()
		{
			foreach (Subdomain subdomain in SubdomainsDictionary.Values)
			{
				foreach (IElementType element in subdomain.Elements)
				{
					element.SubdomainID = subdomain.ID;
				}
			}
		}

		private void DuplicateInterSubdomainEmbeddedElements()
		{
			foreach (var e in ElementsDictionary.Values.Where(x => x is IEmbeddedElement))
			{
				var subIDs = ((IEmbeddedElement)e).EmbeddedNodes.Select(x => x.EmbeddedInElement.SubdomainID).Distinct();
				foreach (var s in subIDs.Where(x => x != e.SubdomainID))
				{
					SubdomainsDictionary[s].Elements.Add(e);
				}
			}
		}

		//What is the purpose of this method? If someone wanted to clear the Model, they could just create a new one.
		public void Clear()
		{
			BoundaryConditions.Clear();
			//ClustersDictionary.Clear();
			SubdomainsDictionary.Clear();
			ElementsDictionary.Clear();
			NodesDictionary.Clear();
			//ElementMassAccelerationHistoryLoads.Clear();
			//ElementMassAccelerationLoads.Clear();
			//MassAccelerationHistoryLoads.Clear();
			//MassAccelerationLoads.Clear();
		}

		private void RemoveInactiveNodalLoads()
		{
			// GOAT: Needs to be refactored with all boundary conditions
			//// Static loads
			//var activeLoadsStatic = new List<INodalBoundaryCondition>(Loads.Count);
			//foreach (INodalBoundaryCondition load in Loads)
			//{
			//	bool isConstrained = false;
			//	foreach (Constraint constraint in load.Node.Constraints)
			//	{
			//		if (load.DOF == constraint.DOF)
			//		{
			//			isConstrained = true;
			//			break;
			//		}
			//	}
			//	if (!isConstrained) activeLoadsStatic.Add(load);
			//}
			//Loads = activeLoadsStatic;

			// GOAT: Needs to be refactored with all boundary conditions
			//// Dynamic loads
			//var activeLoadsDynamic = new List<TransientNodalLoad>(TransientNodalLoads.Count);
			//foreach (TransientNodalLoad load in TransientNodalLoads)
			//{
			//	bool isConstrained = false;
			//	foreach (Constraint constraint in load.Node.Constraints)
			//	{
			//		if (load.DOF == constraint.DOF)
			//		{
			//			isConstrained = true;
			//			break;
			//		}
			//	}
			//	if (!isConstrained) activeLoadsDynamic.Add(load);
			//}
			//TransientNodalLoads = activeLoadsDynamic;
		}

		//public IEnumerable<SerafeimsAwesomeElementAccelerationLoad> EnumerateMassAccelerationLoads(int subdomainID)
		//{
		//	var subdomainLoads = new List<SerafeimsAwesomeElementAccelerationLoad>();
		//	if (MassAccelerationLoads.Count > 0)
		//	{
		//		Subdomain subdomain = SubdomainsDictionary[subdomainID];
		//		foreach (IElementType element in subdomain.Elements)
		//		{
		//			var load = new SerafeimsAwesomeElementAccelerationLoad()
		//			{
		//				Element = element,
		//				GlobalLoads = MassAccelerationLoads
		//			};
		//		}
		//	}
		//	return subdomainLoads;
		//}

		//public IEnumerable<SerafeimsAwesomeElementAccelerationLoad> EnumerateElementMassLoads(int subdomainID)
		//{
		//	var subdomainLoads = new List<SerafeimsAwesomeElementAccelerationLoad>();
		//	foreach (ElementMassAccelerationLoad load in ElementMassAccelerationLoads)
		//	{
		//		if (load.Element.SubdomainID != subdomainID)
		//		{
		//			continue;
		//		}

		//		var newLoad = new SerafeimsAwesomeElementAccelerationLoad()
		//		{
		//			Element = load.Element,
		//			GlobalLoads = this.MassAccelerationLoads
		//		};
		//		subdomainLoads.Add(newLoad);
		//	}
		//	return subdomainLoads;
		//}

		//public IEnumerable<SerafeimsAwesomeElementAccelerationLoad> EnumerateMassAccelerationHistoryLoads(int subdomainID)
		//{
		//	var subdomainLoads = new List<SerafeimsAwesomeElementAccelerationLoad>();

		//	if (MassAccelerationHistoryLoads.Count > 0)
		//	{
		//		var m = new List<MassAccelerationLoad>(MassAccelerationHistoryLoads.Count);
		//		foreach (IMassAccelerationHistoryLoad l in MassAccelerationHistoryLoads)
		//		{
		//			m.Add(new MassAccelerationLoad() { Amount = l[TimeStep], DOF = l.DOF });
		//		}

		//		Subdomain subdomain = SubdomainsDictionary[subdomainID];
		//		foreach (IElementType element in subdomain.Elements)
		//		{
		//			var load = new SerafeimsAwesomeElementAccelerationLoad()
		//			{
		//				Element = element,
		//				GlobalLoads = m
		//			};
		//			subdomainLoads.Add(load);
		//		}
		//	}

		//	foreach (ElementMassAccelerationHistoryLoad load in ElementMassAccelerationHistoryLoads)
		//	{
		//		if (load.Element.SubdomainID != subdomainID)
		//		{
		//			continue;
		//		}

		//		MassAccelerationLoad hl = new MassAccelerationLoad()
		//		{
		//			Amount = load.HistoryLoad[TimeStep] * 564000000,
		//			DOF = load.HistoryLoad.DOF
		//		};

		//		var newLoad = new SerafeimsAwesomeElementAccelerationLoad()
		//		{
		//			Element = load.Element,
		//			GlobalLoads = new MassAccelerationLoad[] { hl }
		//		};
		//		subdomainLoads.Add(newLoad);
		//	}

		//	return subdomainLoads;
		//}

		//public IEnumerable<INodalBoundaryCondition> EnumerateNodalLoads(int subdomainID)
		//{
		//	//TODO: This partitioning should be done in ConnectDataStructures and then just return the correct collection.
		//	var subdomainLoads = new List<INodalBoundaryCondition>();
		//	foreach (INodalBoundaryCondition load in Loads)
		//	{
		//		if (load.Node.Subdomains.Contains(subdomainID))
		//		{
		//			subdomainLoads.Add(load);
		//		}
		//	}
		//	return subdomainLoads;
		//}

		// GOAT: Refactoring - needs to be merged with all boundary conditions
		//public IEnumerable<TransientNodalLoad> EnumerateTransientNodalLoads(int subdomainID)
		//{
		//	//TODO: This partitioning should be done in ConnectDataStructures and then just return the correct collection.
		//	var subdomainLoads = new List<TransientNodalLoad>();
		//	foreach (TransientNodalLoad load in TransientNodalLoads)
		//	{
		//		if (load.Node.Subdomains.Contains(subdomainID))
		//		{
		//			subdomainLoads.Add(load);
		//		}
		//	}
		//	return subdomainLoads;
		//}

	}
}
