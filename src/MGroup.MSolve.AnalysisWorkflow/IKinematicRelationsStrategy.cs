using MGroup.MSolve.Discretization;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IKinematicRelationsStrategy
	{
		double[,] GetNodalKinematicRelationsMatrix(INode boundaryNode);
	}
}
