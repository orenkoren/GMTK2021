using UnityEngine;
using UnityEngine.AI;

public class GridLogic : MonoBehaviour
{
    public int cellSize;
    public Transform startPos;
    //public GameObject placeholder;
    [SerializeField] private float spacing;
    public SpriteRenderer spanUpon;
    public int[,] gridArray;
    private static bool[,] availableSpots;
    private Vector3[,] gridPositions;

    private void Awake()
    {
        gridArray = new int[(int)spanUpon.bounds.size.x, (int)spanUpon.bounds.size.z];
        availableSpots = new bool[(int)spanUpon.bounds.size.x, (int)spanUpon.bounds.size.z];
        for (int x = (int)startPos.position.x;
            x < startPos.position.x + gridArray.GetLength(0); x++)
        {
            for (int z = (int)startPos.position.z;
                z < (int)startPos.position.z + gridArray.GetLength(1); z++)
            {
                //availableSpots[x, z] = true;
            }
        }

        gridPositions = new Vector3[(int)spanUpon.bounds.size.x / cellSize + 1,
                    (int)spanUpon.bounds.size.z / cellSize + 1];
        for (int x = 0; x < gridPositions.GetLength(0); x++)
        {
            for (int z = 0; z < gridPositions.GetLength(1); z++)
            {
                gridPositions[x, z] = new Vector3((int)startPos.position.x + x * cellSize, 2,
                    (int)startPos.position.z + z * cellSize);
            }
        }
        //Instantiate(placeholder, GetClosestPositionOnGrid(new Vector3(612, 1, 202)),
        //    placeholder.transform.rotation);
    }

    public Vector3 GetClosestPositionOnGrid(Vector3 pos)
    {
        Vector3 closestDistanceToNav = Vector3.zero;
        float lowestMagnitude = 500;
        for (int x = 0; x < gridPositions.GetLength(0); x++)
        {
            for (int z = 0; z < gridPositions.GetLength(1); z++)
            {
                var magnitude = (gridPositions[x, z] - pos).magnitude;
                if (magnitude < lowestMagnitude && (gridPositions[x, z] - pos).magnitude > spacing &&
                    NavMesh.SamplePosition(pos, out NavMeshHit hit, 0.01f, NavMesh.AllAreas) == false)
                {
                    closestDistanceToNav = gridPositions[x, z];
                    lowestMagnitude = magnitude;
                }
            }
        }
        return closestDistanceToNav;
    }

    public static void PlaceOnGrid(int x, int z)
    {
        availableSpots[x, z] = false;
    }

    public static bool IsGridSpotOpen(int x, int z)
    {
        return availableSpots[x, z];
    }

    public Vector3[,] GetGridPositions()
    {
        return gridPositions;
    }
}
