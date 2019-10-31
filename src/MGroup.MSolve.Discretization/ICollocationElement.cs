using System.Collections.Generic;

namespace MGroup.MSolve.Discretization
{
    public interface ICollocationElement : IElement
    {
        INode CollocationPoint { get; set; }

        IList<IDofType> GetDOFTypesForDOFEnumeration(IElement element);

        IAsymmetricSubdomain Patch { get; set; }

        IAsymmetricModel Model { get; set; }
    }
}
