using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI.Pathfinding {
 
    public abstract class PathfindingNode {
        
        public abstract Vector3 Position { get; }

        public abstract IReadOnlyList<PathfindingNode> GetNeighbours();
    }
}