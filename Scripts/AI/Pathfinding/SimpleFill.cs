using System.Collections.Generic;

namespace Claw.AI.Pathfinding {
    
    public class SimpleFill<T> where T : IPathfindingNode {
        
        private class NodeMeta {
            
            public float GCost;
        
            public T Node { get; }

            public NodeMeta(T node) { Node = node; }
        }
        
        private readonly Dictionary<T, NodeMeta> fillData = new Dictionary<T, NodeMeta>();
        private readonly List<NodeMeta> fill = new List<NodeMeta>();
        private readonly List<NodeMeta> frontier = new List<NodeMeta>();

        private ITraverser<T> traverser;

        public Area<T> GetFill(T center, int range, ITraverser<T> traverser) {
            this.traverser = traverser;

            fill.Clear();
            frontier.Clear();
            
            NodeMeta first = GetFillData(center);
            first.GCost = 0;
            
            frontier.Add(GetFillData(center));

            for(int step = 0; step <= range; step++) {
                for(int i = frontier.Count - 1; i >= 0; i--) {
                    if(frontier[i].GCost <= step) {
                        fill.Add(frontier[i]);
                        AddNeighbours(frontier[i]);
                        frontier.RemoveAt(i);
                    }
                }
            }

            List<T> fillResult = new List<T>();
            for(int i = 0; i < fill.Count; i++) {
                T node = fill[i].Node;
                if(traverser.CanEndOn(node) && traverser.AddToResult(node)) {
                    fillResult.Add(node);
                }
            }

            return new Area<T>(fillResult);
        }

        private void AddNeighbours(NodeMeta nodeMeta) {
            foreach(var pathfindingNode in nodeMeta.Node.GetNeighbours()) {
                var neighbour = (T) pathfindingNode;
                
                NodeMeta neighNodeMeta = GetFillData(neighbour);
                if(!frontier.Contains(neighNodeMeta) && traverser.CanTraverse(neighNodeMeta.Node)) {
                    neighNodeMeta.GCost = nodeMeta.GCost + traverser.GetTraverseCost(nodeMeta.Node, neighNodeMeta.Node);
                    frontier.Add(neighNodeMeta);
                }
            }
        }

        private NodeMeta GetFillData(T node) {
            NodeMeta nodeMeta = null;
            if (!fillData.TryGetValue(node, out nodeMeta)) {
                nodeMeta = new NodeMeta(node);
                fillData[node] = nodeMeta;
            }

            return nodeMeta;
        }
    }
}