namespace MGroup.MSolve.Discretization.Interfaces
{
    public interface IWeightedPoint:INode
    {
        double WeightFactor { get; set; }
    }
}