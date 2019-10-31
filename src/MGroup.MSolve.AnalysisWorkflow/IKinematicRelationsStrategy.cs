namespace MGroup.MSolve.AnalysisWorkflow
{
	using MGroup.MSolve.Discretization;

	public interface IKinematicRelationsStrategy
	{
		double[,] GetNodalKinematicRelationsMatrix(INode boundaryNode);
	}
}
