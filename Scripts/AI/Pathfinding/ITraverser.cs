
namespace Claw.AI.Pathfinding {
    public interface ITraverser<T> where T : IPathfindingNode {
        bool AddStarting { get; }
        bool CanEndOn(T node);
        bool CanTraverse(T node);
        bool AddToResult(T node);
        float GetTraverseCost(T start, T end);
    }
}