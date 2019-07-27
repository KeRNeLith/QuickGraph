﻿using NUnit.Framework;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Serialization;
using QuikGraph.Tests;

namespace QuikGraph.Algorithms.RandomWalks
{
    [TestFixture]
    internal class EdgeChainTests : QuikGraphUnitTests
    {
        [Test]
        public void GenerateAll()
        {
            foreach (var g in TestGraphFactory.GetAdjacencyGraphs())
                this.Generate(g);
        }

        public void Generate<TVertex, TEdge>(IVertexListGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {

            foreach (var v in g.Vertices)
            {
                var walker = new RandomWalkAlgorithm<TVertex, TEdge>(g);
                var vis = new EdgeRecorderObserver<TVertex, TEdge>();
                using(vis.Attach(walker))
                    walker.Generate(v);
            }
        }
    }
}