using MGroup.MSolve.Discretization;

namespace MGroup.MSolve.Logging.DomainDecomposition
{
    public interface IDomainDecompositionLogger
    {
        void PlotSubdomains(IModel model);
    }
}
