namespace Tutorial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AStar
    {
        public GridNode[] FindPath(Grid _grid, GridNode startGridNode, GridNode endGridNode)
        {
            Node startNode, endNode;
            var grid = CreatePathFindingGrid(_grid, startGridNode, endGridNode, out startNode, out endNode);


            var availableNodes = new List<Node>();
            var visitedNodes = new List<Node>();

            availableNodes.Add(startNode);

            while (!availableNodes.Contains(endNode))
            {
                var nextStep = availableNodes.Min();
            }
        }

        private Node[,] CreatePathFindingGrid(Grid _grid, GridNode startGridNode, GridNode endGridNode,
            out Node startNode, out Node endNode)
        {
            var grid = new Node[_grid.gridSize.x, _grid.gridSize.y];
            startNode = endNode = null;
            for (int i = 0; i < _grid.gridSize.x; i++)
            {
                for (int j = 0; j < _grid.gridSize.y; j++)
                {
                    grid[i, j] = new Node(_grid.grid[i, j]);
                    if (grid[i, j].GridNode == startGridNode)
                    {
                        startNode = grid[i, j];
                    }

                    if (grid[i, j].GridNode == endGridNode)
                    {
                        endNode = grid[i, j];
                    }
                }
            }

            return grid;
        }
    }

    class Node : IComparable<Node>
    {
        public GridNode GridNode { get; set; }
        public float CostValue { get; set; }

        public float EuristicCostValue { get; set; }
        
        public float WayCost { get; set; }
        public Node PrevStep { get; set; }

        public void Recalculate(Node newPrevStepNode)
        {
            var stepFrom_NewPrevStepNode_ToThis =
                (newPrevStepNode.GridNode.WorldPos - GridNode.WorldPos).magnitude;
            var newCostValue = newPrevStepNode.CostValue + stepFrom_NewPrevStepNode_ToThis;


            if (PrevStep == null)
            {
                PrevStep = newPrevStepNode;
                CostValue = newCostValue;
                return;
            }

            if (newCostValue < CostValue)
            {
                CostValue = newCostValue;
                PrevStep = newPrevStepNode;
            }
        }

        public Node(GridNode gridNode)
        {
            GridNode = gridNode;
            PrevStep = null;
        }

        public int CompareTo(Node anotherNode)
        {
            if (CostValue > anotherNode.CostValue)
            {
                return 1;
            }

            if (CostValue < anotherNode.CostValue)
            {
                return -1;
            }

            if()
            return 0;
        }
    }
}