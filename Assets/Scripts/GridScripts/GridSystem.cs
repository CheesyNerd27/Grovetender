using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static float size = 1;
    public static GridSystem g;
    static Plane gridPlane;
    [SerializeField]
    private float setSizeOfGrid = 1;
    public float radiusOfTiles;
    public GameObject gridTile;
    void Awake()
    {
        g = this;
        size = setSizeOfGrid;
        gridPlane = new Plane(transform.up, transform.position);
        MakeGrid();
    }
    public void MakeGrid()// This is mostly for testing
    {
        for (int x = -10; x < 11; x++)
        {
            for(int y = -10; y < 11; y++)
            {
                GameObject h = Instantiate(gridTile, PositionFromCoord(x, y), 
                    Quaternion.LookRotation(-Vector3.up, Vector3.right), transform);
                h.transform.localScale *= size;
            }
        }
    }
    public static Vector3 PositionFromCoord(Vector2Int coord)
    {
        Vector3 newPos = g.transform.position + 
            g.transform.right * size * coord.x + 
            g.transform.forward * size * coord.y * 3/4f;
        if (Mathf.Abs(coord.y) % 2 == 1)
            newPos -= g.transform.right * 1/ 2f * size;

        return newPos;
    }
    public static Vector3 PositionFromCoord(int x, int y)
    {
        return PositionFromCoord(new Vector2Int(x, y));
    }

    public static Vector2Int CoordFromPosition(Vector3 pos)
    {
        Vector3 savedPos = pos;
        pos = g.transform.InverseTransformPoint(pos);
        
        int yCoord = Mathf.RoundToInt(pos.z / (size * 3/4f));

        if (Mathf.Abs(yCoord) % 2 == 1)
            pos += Vector3.right * 1 / 2f * size;

        int xCoord = Mathf.RoundToInt(pos.x / size);

        return new Vector2Int(xCoord, yCoord);
    }

    public static Vector3 AlignPositionOnGrid(Vector3 pos)
    {
        Vector3 savedPos = pos;
        //pos = g.transform.InverseTransformPoint(pos);

        int yCoord = Mathf.RoundToInt(pos.z / (3 / 4f));

        if (Mathf.Abs(yCoord) % 2 == 1)
            pos += Vector3.right * 1 / 2f;

        int xCoord = Mathf.RoundToInt(pos.x);

        Vector3 newPos = Vector3.right * xCoord + Vector3.forward * yCoord * 3 / 4f;
        if (Mathf.Abs(yCoord) % 2 == 1)
            newPos -= Vector3.right * 1 / 2f;

        return newPos;

        //return PositionFromCoord(xCoord, yCoord);
    }

    
    public static Vector2Int CoordFromScreenPoint(Camera cam)
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        float enterPoint = -10;
        gridPlane.Raycast(camRay, out enterPoint);
        if (enterPoint < 0)
            return Vector2Int.zero;
        return CoordFromPosition(camRay.GetPoint(enterPoint));
    }
    public static Vector2Int CoordFromScreenPoint(Camera cam, Vector3 offset)
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        float enterPoint = -10;
        gridPlane.Raycast(camRay, out enterPoint);
        if (enterPoint < 0)
            return Vector2Int.zero;
        return CoordFromPosition(camRay.GetPoint(enterPoint) + offset * size);
    }
}