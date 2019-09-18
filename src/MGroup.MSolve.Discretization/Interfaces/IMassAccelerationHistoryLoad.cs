using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGroup.MSolve.Discretization.FreedomDegrees;
using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.FEM.Interfaces
{
    public interface IMassAccelerationHistoryLoad
    {
        IDofType DOF { get; }
        double this[int currentTimeStep] { get; }
    }
}
