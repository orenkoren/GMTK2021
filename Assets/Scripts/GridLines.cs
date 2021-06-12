using UnityEngine;

public class GridLines : MonoBehaviour
{
    void Update()
    {
        var gridLogic = GetComponent<GridLogic>();
        //for (int x = (int)gridLogic.startPos.position.x; x < gridLogic.startPos.position.x +
        //            gridLogic.gridArray.GetLength(0); x += gridLogic.cellSize)
        //{
        //    for (int z = (int)gridLogic.startPos.position.z; z < (int)gridLogic.startPos.position.z
        //            + gridLogic.gridArray.GetLength(1); z += gridLogic.cellSize)
        //    {
        //        Debug.DrawLine(new Vector3(x, 2, z),
        //            new Vector3(x + gridLogic.cellSize, 2, z + gridLogic.cellSize));
        //        Debug.DrawLine(new Vector3(x, 2, z),
        //            new Vector3(x, 2, z + gridLogic.cellSize));
        //        Debug.DrawLine(new Vector3(x + gridLogic.cellSize, 2, z),
        //            new Vector3(x + gridLogic.cellSize, 2, z + gridLogic.cellSize));
        //        Debug.DrawLine(new Vector3(x, 2, z + gridLogic.cellSize),
        //            new Vector3(x + gridLogic.cellSize, 2, z + gridLogic.cellSize));
        //    }
        //}
        var positions = gridLogic.GetGridPositions();
        for (int x = 0; x < positions.GetLength(0) - 1; x++)
        {
            for (int z = 0; z < positions.GetLength(1) - 1; z++)
            {
                Debug.DrawLine(positions[x, z], positions[x + 1, z]);
                Debug.DrawLine(positions[x, z], positions[x, z + 1]);
                Debug.DrawLine(positions[x + 1, z], positions[x + 1, z + 1]);
                Debug.DrawLine(positions[x, z + 1], positions[x + 1, z + 1]);

            }
        }
    }
}
