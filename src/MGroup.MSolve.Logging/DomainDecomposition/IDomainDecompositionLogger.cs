using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Logging.DomainDecomposition
{
    public interface IDomainDecompositionLogger
    {
        void PlotSubdomains(IModel model);
    }
}
