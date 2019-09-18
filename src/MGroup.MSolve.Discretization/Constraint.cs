using MGroup.MSolve.Discretization.FreedomDegrees;

namespace MGroup.MSolve.Discretization
{
    public class Constraint
    {
        //public Node Node { get; set; }
        public IDofType DOF { get; set; }
        public double Amount { get; set; }
    }
}

