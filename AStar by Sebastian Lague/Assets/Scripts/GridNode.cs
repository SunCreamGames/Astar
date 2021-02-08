namespace Tutorial
{
    using UnityEngine;

    public class GridNode
    {
        public bool Walkable { get; set; }
        public Vector3 WorldPos { get; set; }

        public GridNode(bool walkable, Vector3 worldPos)
        {
            Walkable = walkable;
            WorldPos = worldPos;
        }
    }
}