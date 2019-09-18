using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Logging.DomainDecomposition
{
    public class DomainDecompositionLogger : IDomainDecompositionLogger
    {
        private readonly string plotDirectoryPath;
        private readonly bool shuffleSubdomainColors;
        private int analysisStep;

        //TODO: make sure the path does not end in "\"
        public DomainDecompositionLogger(string plotDirectoryPath, bool shuffleSubdomainColors = false) 
        {
            this.plotDirectoryPath = plotDirectoryPath;
            this.shuffleSubdomainColors = shuffleSubdomainColors;
            analysisStep = 0;
        }

        public void PlotSubdomains(IModel model)
        {
            var writer = new MeshPartitionWriter(shuffleSubdomainColors);
            writer.WriteSubdomainElements($"{plotDirectoryPath}\\subdomains_{analysisStep}.vtk", model);
            writer.WriteBoundaryNodes($"{plotDirectoryPath}\\boundary_nodes_{analysisStep}.vtk", model);
            ++analysisStep;
        }
    }
}
