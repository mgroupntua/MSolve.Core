using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Meshes.Output.VTK;
using MGroup.MSolve.Discretization.Meshes.Structured;
using Xunit;

namespace MGroup.MSolve.Meshes.Tests.Structured
{
    public static class UniformSimplicialMesh3DTests
    {
        //[Fact]
        public static void PlotMesh()
        {
            var writer = new VtkMeshWriter();

            string path = Path.Join("PFETIDP", "meshes", "tetra_mesh3D.vtk");
            double[] minCoords = { 0, 0, 0 };
            double[] maxCoords = { 60, 60, 60 };
            int[] numNodes = { 3, 4, 5 };
            var mesh = new UniformSimplicialMesh3D.Builder(minCoords, maxCoords, numNodes).SetMajorMinorAxis(2, 0).BuildMesh();
            //var mesh = new UniformSimplicialMesh3D.Builder(minCoords, maxCoords, numNodes).BuildMesh();
            writer.WriteMesh(path, mesh, 3);
        }

        [Fact]
        public static void TestEnumerateNodes()
        {
            var mockMesh = new MockMesh2x3x4();
            var mesh = new UniformSimplicialMesh3D.Builder(mockMesh.MinCoordinates, mockMesh.MaxCoordinates, mockMesh.NumNodes)
                .BuildMesh();

            // Check that nodes are returned in ascending order
            int[] nodeIDs = mesh.EnumerateNodes().Select(pair => pair.nodeID).ToArray();
            Assert.Equal(0, nodeIDs[0]);
            for (int i = 0; i < nodeIDs.Length - 1; ++i)
            {
                Assert.Equal(nodeIDs[i] + 1, nodeIDs[i + 1]);
            }

            // Check each returned node
            foreach ((int nodeID, double[] coords) in mesh.EnumerateNodes())
            {
                double[] coordsExpected = mockMesh.GetNodeCoordinates(mockMesh.GetNodeIdx(nodeID));
                for (int d = 0; d < 3; ++d)
                {
                    Assert.Equal(coordsExpected[d], coords[d]);
                }
            }
        }

        [Fact]
        public static void TestGetNodeID()
        {
            var mockMesh = new MockMesh2x3x4();
            var mesh = new UniformSimplicialMesh3D.Builder(mockMesh.MinCoordinates, mockMesh.MaxCoordinates, mockMesh.NumNodes)
                .BuildMesh();

            for (int i = 0; i < mesh.NumNodes[0]; ++i)
            {
                for (int j = 0; j < mesh.NumNodes[1]; ++j)
                {
                    for (int k = 0; k < mesh.NumNodes[2]; ++k)
                    {
                        var idx = new int[] { i, j, k };
                        int expected = mockMesh.GetNodeID(idx);
                        int computed = mesh.GetNodeID(idx);
                        Assert.Equal(expected, computed);
                    }
                }
            }
        }

        [Fact]
        public static void TestGetNodeIdx()
        {
            var mockMesh = new MockMesh2x3x4();
            var mesh = new UniformSimplicialMesh3D.Builder(mockMesh.MinCoordinates, mockMesh.MaxCoordinates, mockMesh.NumNodes)
                .BuildMesh();

            for (int id = 0; id < mesh.NumNodes[0] * mesh.NumNodes[1] * mesh.NumNodes[2]; ++id)
            {
                int[] expected = mockMesh.GetNodeIdx(id);
                int[] computed = mesh.GetNodeIdx(id);
                for (int d = 0; d < 3; ++d)
                {
                    Assert.Equal(expected[d], computed[d]);
                }
            }
        }

        [Fact]
        public static void TestGetNodeCoordinates()
        {
            var mockMesh = new MockMesh2x3x4();
            var mesh = new UniformSimplicialMesh3D.Builder(mockMesh.MinCoordinates, mockMesh.MaxCoordinates, mockMesh.NumNodes)
                .BuildMesh();

            for (int i = 0; i < mesh.NumNodes[0]; ++i)
            {
                for (int j = 0; j < mesh.NumNodes[1]; ++j)
                {
                    for (int k = 0; k < mesh.NumNodes[2]; ++k)
                    {
                        var idx = new int[] { i, j, k };
                        double[] expected = mockMesh.GetNodeCoordinates(idx);
                        double[] computed = mesh.GetNodeCoordinates(idx);
                        for (int d = 0; d < 3; ++d)
                        {
                            Assert.Equal(expected[d], computed[d]);
                        }
                    }
                }
            }
        }

        

        private class MockMesh2x3x4 : IStructuredMesh
        {
            public int Dimension => 3;

            public CellType CellType => CellType.Tet4;

            public double[] MinCoordinates => new double[] { 0.0, 0.0, 0.0 };

            public double[] MaxCoordinates => new double[] { 2.0, 3.0, 4.0 };

            //public int[] NumElements => new int[] { 2, 3, 4 };

            public int[] NumNodes => new int[] { 3, 4, 5 };

            public int NumElementsTotal => 24;

            public int NumNodesTotal => 60;

            public int NumNodesPerElement => 8;

            public IEnumerable<(int elementID, int[] nodeIDs)> EnumerateElements()
            {
                throw new NotImplementedException();
            }

            public IEnumerable<(int nodeID, double[] coordinates)> EnumerateNodes()
            {
                throw new NotImplementedException();
            }

            public int[] GetElementConnectivity(int[] elementIdx)
            {
                throw new NotImplementedException();
            }

            public int[] GetElementConnectivity(int elementID) => GetElementConnectivity(GetElementIdx(elementID));

            public int GetElementID(int[] elementIdx)
            {
                throw new NotImplementedException();
            }

            public int[] GetElementIdx(int elementID)
            {
                throw new NotImplementedException();
            }

            public double[] GetNodeCoordinates(int[] nodeIdx)
            {
                var nodeCoords = new double[3, 4, 5][];
                nodeCoords[0, 0, 0] = new double[] { 0, 0, 0 };
                nodeCoords[1, 0, 0] = new double[] { 1, 0, 0 };
                nodeCoords[2, 0, 0] = new double[] { 2, 0, 0 };
                nodeCoords[0, 1, 0] = new double[] { 0, 1, 0 };
                nodeCoords[1, 1, 0] = new double[] { 1, 1, 0 };
                nodeCoords[2, 1, 0] = new double[] { 2, 1, 0 };
                nodeCoords[0, 2, 0] = new double[] { 0, 2, 0 };
                nodeCoords[1, 2, 0] = new double[] { 1, 2, 0 };
                nodeCoords[2, 2, 0] = new double[] { 2, 2, 0 };
                nodeCoords[0, 3, 0] = new double[] { 0, 3, 0 };
                nodeCoords[1, 3, 0] = new double[] { 1, 3, 0 };
                nodeCoords[2, 3, 0] = new double[] { 2, 3, 0 };

                nodeCoords[0, 0, 1] = new double[] { 0, 0, 1 };
                nodeCoords[1, 0, 1] = new double[] { 1, 0, 1 };
                nodeCoords[2, 0, 1] = new double[] { 2, 0, 1 };
                nodeCoords[0, 1, 1] = new double[] { 0, 1, 1 };
                nodeCoords[1, 1, 1] = new double[] { 1, 1, 1 };
                nodeCoords[2, 1, 1] = new double[] { 2, 1, 1 };
                nodeCoords[0, 2, 1] = new double[] { 0, 2, 1 };
                nodeCoords[1, 2, 1] = new double[] { 1, 2, 1 };
                nodeCoords[2, 2, 1] = new double[] { 2, 2, 1 };
                nodeCoords[0, 3, 1] = new double[] { 0, 3, 1 };
                nodeCoords[1, 3, 1] = new double[] { 1, 3, 1 };
                nodeCoords[2, 3, 1] = new double[] { 2, 3, 1 };

                nodeCoords[0, 0, 2] = new double[] { 0, 0, 2 };
                nodeCoords[1, 0, 2] = new double[] { 1, 0, 2 };
                nodeCoords[2, 0, 2] = new double[] { 2, 0, 2 };
                nodeCoords[0, 1, 2] = new double[] { 0, 1, 2 };
                nodeCoords[1, 1, 2] = new double[] { 1, 1, 2 };
                nodeCoords[2, 1, 2] = new double[] { 2, 1, 2 };
                nodeCoords[0, 2, 2] = new double[] { 0, 2, 2 };
                nodeCoords[1, 2, 2] = new double[] { 1, 2, 2 };
                nodeCoords[2, 2, 2] = new double[] { 2, 2, 2 };
                nodeCoords[0, 3, 2] = new double[] { 0, 3, 2 };
                nodeCoords[1, 3, 2] = new double[] { 1, 3, 2 };
                nodeCoords[2, 3, 2] = new double[] { 2, 3, 2 };

                nodeCoords[0, 0, 3] = new double[] { 0, 0, 3 };
                nodeCoords[1, 0, 3] = new double[] { 1, 0, 3 };
                nodeCoords[2, 0, 3] = new double[] { 2, 0, 3 };
                nodeCoords[0, 1, 3] = new double[] { 0, 1, 3 };
                nodeCoords[1, 1, 3] = new double[] { 1, 1, 3 };
                nodeCoords[2, 1, 3] = new double[] { 2, 1, 3 };
                nodeCoords[0, 2, 3] = new double[] { 0, 2, 3 };
                nodeCoords[1, 2, 3] = new double[] { 1, 2, 3 };
                nodeCoords[2, 2, 3] = new double[] { 2, 2, 3 };
                nodeCoords[0, 3, 3] = new double[] { 0, 3, 3 };
                nodeCoords[1, 3, 3] = new double[] { 1, 3, 3 };
                nodeCoords[2, 3, 3] = new double[] { 2, 3, 3 };

                nodeCoords[0, 0, 4] = new double[] { 0, 0, 4 };
                nodeCoords[1, 0, 4] = new double[] { 1, 0, 4 };
                nodeCoords[2, 0, 4] = new double[] { 2, 0, 4 };
                nodeCoords[0, 1, 4] = new double[] { 0, 1, 4 };
                nodeCoords[1, 1, 4] = new double[] { 1, 1, 4 };
                nodeCoords[2, 1, 4] = new double[] { 2, 1, 4 };
                nodeCoords[0, 2, 4] = new double[] { 0, 2, 4 };
                nodeCoords[1, 2, 4] = new double[] { 1, 2, 4 };
                nodeCoords[2, 2, 4] = new double[] { 2, 2, 4 };
                nodeCoords[0, 3, 4] = new double[] { 0, 3, 4 };
                nodeCoords[1, 3, 4] = new double[] { 1, 3, 4 };
                nodeCoords[2, 3, 4] = new double[] { 2, 3, 4 };


                return nodeCoords[nodeIdx[0], nodeIdx[1], nodeIdx[2]];
            }

            public int GetNodeID(int[] nodeIdx)
            {
                var nodeIDs = new int[3, 4, 5];
                nodeIDs[0, 0, 0] = 0;
                nodeIDs[1, 0, 0] = 1;
                nodeIDs[2, 0, 0] = 2;
                nodeIDs[0, 1, 0] = 3;
                nodeIDs[1, 1, 0] = 4;
                nodeIDs[2, 1, 0] = 5;
                nodeIDs[0, 2, 0] = 6;
                nodeIDs[1, 2, 0] = 7;
                nodeIDs[2, 2, 0] = 8;
                nodeIDs[0, 3, 0] = 9;
                nodeIDs[1, 3, 0] = 10;
                nodeIDs[2, 3, 0] = 11;

                nodeIDs[0, 0, 1] = 12;
                nodeIDs[1, 0, 1] = 13;
                nodeIDs[2, 0, 1] = 14;
                nodeIDs[0, 1, 1] = 15;
                nodeIDs[1, 1, 1] = 16;
                nodeIDs[2, 1, 1] = 17;
                nodeIDs[0, 2, 1] = 18;
                nodeIDs[1, 2, 1] = 19;
                nodeIDs[2, 2, 1] = 20;
                nodeIDs[0, 3, 1] = 21;
                nodeIDs[1, 3, 1] = 22;
                nodeIDs[2, 3, 1] = 23;

                nodeIDs[0, 0, 2] = 24;
                nodeIDs[1, 0, 2] = 25;
                nodeIDs[2, 0, 2] = 26;
                nodeIDs[0, 1, 2] = 27;
                nodeIDs[1, 1, 2] = 28;
                nodeIDs[2, 1, 2] = 29;
                nodeIDs[0, 2, 2] = 30;
                nodeIDs[1, 2, 2] = 31;
                nodeIDs[2, 2, 2] = 32;
                nodeIDs[0, 3, 2] = 33;
                nodeIDs[1, 3, 2] = 34;
                nodeIDs[2, 3, 2] = 35;

                nodeIDs[0, 0, 3] = 36;
                nodeIDs[1, 0, 3] = 37;
                nodeIDs[2, 0, 3] = 38;
                nodeIDs[0, 1, 3] = 39;
                nodeIDs[1, 1, 3] = 40;
                nodeIDs[2, 1, 3] = 41;
                nodeIDs[0, 2, 3] = 42;
                nodeIDs[1, 2, 3] = 43;
                nodeIDs[2, 2, 3] = 44;
                nodeIDs[0, 3, 3] = 45;
                nodeIDs[1, 3, 3] = 46;
                nodeIDs[2, 3, 3] = 47;

                nodeIDs[0, 0, 4] = 48;
                nodeIDs[1, 0, 4] = 49;
                nodeIDs[2, 0, 4] = 50;
                nodeIDs[0, 1, 4] = 51;
                nodeIDs[1, 1, 4] = 52;
                nodeIDs[2, 1, 4] = 53;
                nodeIDs[0, 2, 4] = 54;
                nodeIDs[1, 2, 4] = 55;
                nodeIDs[2, 2, 4] = 56;
                nodeIDs[0, 3, 4] = 57;
                nodeIDs[1, 3, 4] = 58;
                nodeIDs[2, 3, 4] = 59;


                return nodeIDs[nodeIdx[0], nodeIdx[1], nodeIdx[2]];
            }

            public int[] GetNodeIdx(int nodeID)
            {
                var nodeIndices = new int[,]
                {
                    { 0, 0, 0 },
                    { 1, 0, 0 },
                    { 2, 0, 0 },
                    { 0, 1, 0 },
                    { 1, 1, 0 },
                    { 2, 1, 0 },
                    { 0, 2, 0 },
                    { 1, 2, 0 },
                    { 2, 2, 0 },
                    { 0, 3, 0 },
                    { 1, 3, 0 },
                    { 2, 3, 0 },

                    { 0, 0, 1 },
                    { 1, 0, 1 },
                    { 2, 0, 1 },
                    { 0, 1, 1 },
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 0, 2, 1 },
                    { 1, 2, 1 },
                    { 2, 2, 1 },
                    { 0, 3, 1 },
                    { 1, 3, 1 },
                    { 2, 3, 1 },

                    { 0, 0, 2 },
                    { 1, 0, 2 },
                    { 2, 0, 2 },
                    { 0, 1, 2 },
                    { 1, 1, 2 },
                    { 2, 1, 2 },
                    { 0, 2, 2 },
                    { 1, 2, 2 },
                    { 2, 2, 2 },
                    { 0, 3, 2 },
                    { 1, 3, 2 },
                    { 2, 3, 2 },

                    { 0, 0, 3 },
                    { 1, 0, 3 },
                    { 2, 0, 3 },
                    { 0, 1, 3 },
                    { 1, 1, 3 },
                    { 2, 1, 3 },
                    { 0, 2, 3 },
                    { 1, 2, 3 },
                    { 2, 2, 3 },
                    { 0, 3, 3 },
                    { 1, 3, 3 },
                    { 2, 3, 3 },

                    { 0, 0, 4 },
                    { 1, 0, 4 },
                    { 2, 0, 4 },
                    { 0, 1, 4 },
                    { 1, 1, 4 },
                    { 2, 1, 4 },
                    { 0, 2, 4 },
                    { 1, 2, 4 },
                    { 2, 2, 4 },
                    { 0, 3, 4 },
                    { 1, 3, 4 },
                    { 2, 3, 4 }
                };

                return new int[] { nodeIndices[nodeID, 0], nodeIndices[nodeID, 1], nodeIndices[nodeID, 2] };
            }
        }
    }
}
