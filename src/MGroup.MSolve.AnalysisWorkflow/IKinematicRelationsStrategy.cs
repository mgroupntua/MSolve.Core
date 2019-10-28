namespace MGroup.MSolve.AnalysisWorkflow
{
	using MGroup.MSolve.Discretization.Interfaces;

	public interface IKinematicRelationsStrategy
	{
		double[,] GetNodalKinematicRelationsMatrix(INode boundaryNode);
	}
}
