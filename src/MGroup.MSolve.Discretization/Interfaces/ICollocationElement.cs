using MGroup.MSolve.Geometry.Coordinates;
using System;
using System.Collections.Generic;
using System.Text;
using DotNumerics.Optimization.TN;
using MGroup.MSolve.Discretization.FreedomDegrees;

namespace MGroup.MSolve.Discretization.Interfaces
{
    public interface ICollocationElement:IElement
    {
        INode CollocationPoint { get; set; }

        IList<IDofType> GetDOFTypesForDOFEnumeration(IElement element);

        IAsymmetricSubdomain Patch { get; set; }

        IAsymmetricModel Model { get; set; }
    }
}
