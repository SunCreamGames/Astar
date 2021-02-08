namespace Tutorial
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class PathFinding : MonoBehaviour
    {
        private Grid grid;

        private void Awake()
        {
            grid = GetComponent<Grid>();
        }

        void FindPath(Vector3 startPos, Vector3 targetPos)
        {
            var startNode = grid.GetNodeFromWorldPos(startPos);
            var targetNode = grid.GetNodeFromWorldPos(targetPos);

            var path = AStar(startNode, targetNode);
        }

        private List<GridNode> AStar(GridNode startNode, GridNode targetNode)
        {
            var path = new List<(GridNode, float)>();
            var possibleMoves = new List<(GridNode, float)>();
            path.Add((startNode, 0f));
            while (path.FirstOrDefault(c => c.Item1 == targetNode).Item1 == null)
            {
                var nextStep = GetTheCheapestNode(path);
            }


            return null;
        }

        private GridNode GetTheCheapestNode(List<(GridNode, float)> path)
        {
            var cheapestNodeTuple = path[0];
            foreach (var tuple in path)
            {
                if (tuple.Item2 < cheapestNodeTuple.Item2)
                {
                    cheapestNodeTuple = tuple;
                }
            }

            return cheapestNodeTuple.Item1;
        }
    }
}