namespace MGroup.MSolve.Discretization
{
    public interface IWeightedPoint : INode
    {
        double WeightFactor { get; set; }
    }
}
