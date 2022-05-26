using System.Collections.Generic;
using MGroup.MSolve.DataStructures;

namespace MGroup.MSolve.Discretization.Entities
{
    public interface ISubdomain
    {
        int ID { get; }

        bool LinearSystemModified { get; set; }

		IEnumerable<IElementType> EnumerateElements();

		IEnumerable<INode> EnumerateNodes();

		int GetMultiplicityOfNode(int nodeID);

  //      void ResetConstitutiveLawModified();

		//void SaveConstitutiveLawState();
    }
}
