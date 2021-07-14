using System.Collections;
using System.Collections.Generic;

namespace Claw.AI.Pathfinding {
    
    public class Path<T> : IReadOnlyList<T> where T : IPathfindingNode {

        private readonly List<T> nodes;

        public T Start => nodes[0];
        
        public T End => nodes[nodes.Count - 1];
        
        public int Length => nodes == null ? 0 : nodes.Count;
        
        public bool Exists => nodes != null;
        
        public int Count => nodes.Count;
        
        public T this[int index] => nodes[index];
        
        public static Path<T> Empty => new Path<T>();

        public Path(List<T> nodes) { this.nodes = nodes; }

        public Path(T[] pathNodes) { this.nodes = new List<T>(pathNodes); }
        
        private Path() { }
        
        public IEnumerator<T> GetEnumerator() { return nodes.GetEnumerator(); }
        
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}