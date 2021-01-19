namespace Claw.AI.Pathfinding {

    public class Pathfinder<T> where T : PathfindingNode {

        private readonly AStar<T> aStar;
        private readonly SimpleFill<T> simpleFill;

        public Pathfinder() {
            aStar = new AStar<T>();
            simpleFill = new SimpleFill<T>();
        }

        public Path<T> GetPath(T start, T end, ITraverser<T> traverser) {
            return aStar.GetPath(start, end, traverser);
        }

        public Area<T> GetArea(T center, int range, ITraverser<T> traverser) {
            return simpleFill.GetFill(center, range, traverser);
        }
    }
}
