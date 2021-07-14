using System.Collections;
using System.Collections.Generic;

namespace Claw.AI.Pathfinding {
    
    public class Area<T> : IReadOnlyList<T> where T : IPathfindingNode {

        private readonly List<T> area = null;
        
        public int Count => area.Count;

        public T this[int index] => area[index];
        
        public bool Contains(T pos) { return area.Contains(pos); }

        public IEnumerator<T> GetEnumerator() { return area.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return area.GetEnumerator(); }

        public Area(List<T> area) {
            this.area = area;
        }
    }
}
