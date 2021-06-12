
namespace Claw.AI.Pathfinding {
    public interface ITraverser<T> where T : IPathfindingNode {
        bool CanEndOn(T node);
        bool CanTraverse(T node);
        bool AddToResult(T node);
        int GetTraverseCost(T start, T end);
    }
}