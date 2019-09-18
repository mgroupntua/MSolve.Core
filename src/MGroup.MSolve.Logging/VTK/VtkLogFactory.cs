using System;
using System.Linq;
using MGroup.MSolve.Discretization.Interfaces;
using MGroup.MSolve.Discretization.Mesh;
using MGroup.MSolve.Logging.Interfaces;

namespace MGroup.MSolve.Logging.VTK
{
    /// <summary>
    /// Creates <see cref="VtkLog2D"/> observers that log the corresponding data to VTK output files. Then the .vtk
    /// files can be visualized in paraview.
    /// Authors: Serafeim Bakalakos
    /// </summary>
    public class VtkLogFactory : ILogFactory
    {
        private readonly string directory;
        private readonly IModel model;
        private readonly VtkMesh<INode> vtkMesh;

        public VtkLogFactory(IModel model, string directory)
        {
            this.model = model;
            this.directory = directory;
            try
            {
                INode[] nodes = model.Nodes.Select(x=>x).ToArray();
                ICell<INode>[] elements = model.Elements.Select(element => (ICell<INode>)element).ToArray();
                this.vtkMesh = new VtkMesh<INode>(nodes, elements);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException("VtkLogFactory only works for models with elements that implement ICell.", ex);
            }
        }

        public bool LogDisplacements { get; set; } = true;
        public bool LogStrains { get; set; } = true;
        public bool LogStresses { get; set; } = true;
        public string Filename { get; set; } = "field_output";

        /// <summary>
        /// If nothing is assigned, there will not be any von Mises stress output.
        /// </summary>
        public IVonMisesStress2D VonMisesStressCalculator { get; set; } = null;

        public IAnalyzerLog[] CreateLogs()
        {
            return new IAnalyzerLog[]
            {
                new VtkLog2D(directory, Filename, model, vtkMesh, LogDisplacements, LogStrains, LogStresses, 
                    VonMisesStressCalculator)
            };
        }
    }
}
