using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI.Pathfinding {
 
    public interface IPathfindingNode {
        
        Vector3 Position { get; }

        IEnumerable<IPathfindingNode> GetNeighbours();
    }
}