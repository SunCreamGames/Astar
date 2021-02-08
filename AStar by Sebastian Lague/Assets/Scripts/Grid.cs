namespace Tutorial
{
    using UnityEngine;

    public class Grid : MonoBehaviour
    {
        [SerializeField]
        private Transform player;

        [SerializeField]
        private LayerMask unWalkableMask;

        [SerializeField]
        private Vector2 gridWorldSize;

        [SerializeField]
        private float nodeRadius;

        private float nodeDiameter;

        public GridNode[,] grid;

        public Vector2Int gridSize;
        Vector3 worldBottomLeft;

        private void Start()
        {
            nodeDiameter = nodeRadius * 2;
            gridSize.x = Mathf.FloorToInt(gridWorldSize.x / nodeDiameter) + 1;
            gridSize.y = Mathf.FloorToInt(gridWorldSize.y / nodeDiameter) + 1;
            CreateGrid();
        }

        private void CreateGrid()
        {
            grid = new GridNode[gridSize.x, gridSize.y];
            worldBottomLeft = transform.position - new Vector3(gridWorldSize.x / 2f, 0, gridWorldSize.y / 2f);

            Vector3 posForCurrentNode;
            bool isCurrentNodeWalkable;


            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    posForCurrentNode = worldBottomLeft +
                                        new Vector3(i * nodeDiameter + nodeRadius, 0f, j * nodeDiameter + nodeRadius);

                    isCurrentNodeWalkable = !Physics.CheckSphere(posForCurrentNode, nodeRadius, unWalkableMask);
                    grid[i, j] = new GridNode(isCurrentNodeWalkable, posForCurrentNode);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1f, gridWorldSize.y));
            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    Gizmos.color = (grid[i, j].Walkable) ? Color.white : Color.red;
                    Gizmos.DrawCube(grid[i, j].WorldPos,
                        new Vector3(nodeRadius * 1.5f, nodeRadius * 1.5f, nodeRadius * 1.5f));
                }
            }
        }

        public GridNode GetNodeFromWorldPos(Vector3 worldPos)
        {
            var percentage =
                (new Vector2((worldPos - worldBottomLeft).x, (worldPos - worldBottomLeft).z) -
                 Vector2.one * nodeRadius) /
                gridWorldSize;
            Vector2Int coordinatesInGrid = new Vector2Int(
                Mathf.RoundToInt(percentage.x * gridSize.x),
                Mathf.RoundToInt(percentage.y * gridSize.y)
            );

            return grid[coordinatesInGrid.x, coordinatesInGrid.y];
        }
    }
}