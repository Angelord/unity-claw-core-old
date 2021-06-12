using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI.Pathfinding {
    
    public class AStar<T> where T : class, IPathfindingNode {
        
        private class NodeMeta {

            public float HCost;
        
            public float GCost;
        
            public float FCost => HCost + GCost;

            public T Parent;

            public T Node { get; }

            public NodeMeta(T node) {
                Node = node;
            }
        }
        
        private readonly List<NodeMeta> closedList = new List<NodeMeta>();
        private readonly List<NodeMeta> openList = new List<NodeMeta>();
        private readonly Dictionary<T, NodeMeta> metaData = new Dictionary<T, NodeMeta>();
        
        private T startNode;
        private T endNode;
        private ITraverser<T> traverser;
        private NodeMeta current;

        public Path<T> GetPath(T startNode, T endNode, ITraverser<T> traverser) {
            if(startNode == endNode) {
                return new Path<T>(new List<T>() { startNode });   
            }

            this.startNode = startNode;
            this.endNode = endNode;
            this.traverser = traverser;
            
            closedList.Clear();
            openList.Clear();

            var startNodeMeta = GetNodeMeta(startNode);

            startNodeMeta.GCost = 0.0f;

            openList.Add(startNodeMeta);

            while (true) {
                
                if(openList.Count == 0) {
                    return Path<T>.Empty;  // No path exists
                }

                current = openList[openList.Count - 1];
                openList.Remove(current);

                if(current.Node == endNode) {
                    return Backtrack();    // Path discovered
                }
                
                if(!closedList.Contains(current)) {
                    closedList.Add(current);
                    AddNeighboursToOpen();
                }
            }
        }

        private Path<T> Backtrack() {
            List<T> path = new List<T>();

            while(current.Node != startNode) {
                if(traverser.AddToResult(current.Node)) { 
                    path.Add(current.Node);
                }
                current = GetNodeMeta(current.Parent);
            }

            if(traverser.AddToResult(current.Node)) {
                path.Add(startNode);
            }

            path.Reverse();

            return new Path<T>(path);
        }

        private void AddNeighboursToOpen() {
            foreach(T neighbour in current.Node.GetNeighbours()) {
                AddToOpen(neighbour);
            }

            openList.Sort((a, b) => b.FCost.CompareTo(a.FCost));
        }

        private void AddToOpen(T node) {
            NodeMeta target = GetNodeMeta(node);
            if(traverser.CanTraverse(node) || node == endNode) {
                float gCost = current.GCost + traverser.GetTraverseCost(current.Node, node);
                if (!closedList.Contains(target) && !openList.Contains(target)) {
                    target.Parent = current.Node;
                    target.HCost = Vector3.Distance(node.Position, endNode.Position);
                    target.GCost = gCost;
                    openList.Add(target);
                }
                else if(target.GCost > gCost) {
                    target.Parent = current.Node;
                    target.GCost = gCost;
                }
            }
        }

        private NodeMeta GetNodeMeta(T node) {
            NodeMeta metaData = null;
            if (!this.metaData.TryGetValue(node, out metaData)) {
                metaData = new NodeMeta(node);
                this.metaData.Add(node, metaData);
            }

            return metaData;
        }
    }
}
