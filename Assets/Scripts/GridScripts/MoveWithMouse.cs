using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    // This is for testing placing objects. It lacks an inventory for structures

    public Camera cam;
    [Tooltip("This is for structures that have an origin point slightly off the grid. eg. structures that take up multiple spaces")]
    public Vector3 spawnOffset;
    [Tooltip("Left Click to spawn")]
    public GameObject spawn;
    [Tooltip("Right Click to spawn")]
    public GameObject spawn2;
    void Update()
    {
        Vector2Int coord = GridSystem.CoordFromScreenPoint(cam, spawnOffset);
        transform.position = GridSystem.PositionFromCoord(coord);
        if (Input.GetMouseButtonDown(0))
        {
            StructureManager.PlaceStructure(spawn, coord);
        }
        if (Input.GetMouseButtonDown(1))
        {
            StructureManager.PlaceStructure(spawn2, coord);
        }
    }
}