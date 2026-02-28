using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StructureManager : MonoBehaviour
{
    public static UnityEvent<Vector2Int> IsSpotTaken = new UnityEvent<Vector2Int>();
    static bool spotIsTaken = false;
    public static bool CheckIfSpotIsTaken(Vector2Int coord)
    {
        IsSpotTaken.Invoke(coord);
        bool spotTakenCurrent = spotIsTaken;
        spotIsTaken = false;

        return spotTakenCurrent;
    }
    public static void TakeSpot()
    {
        spotIsTaken = true;
    }

    public static GameObject PlaceStructure(GameObject structure, Vector2Int coord)
    {
        structure = Instantiate(structure, GridSystem.PositionFromCoord(coord), structure.transform.rotation);
        structure.transform.localScale *= GridSystem.size;

        StructureScript ss = structure.GetComponent<StructureScript>();
        if (!ss)
        {
            print("The object you are checking with is NOT a structure!");
            Destroy(structure);
            return null;
        }
        if (ss.StructIsColliding())
        {
            print("The structure collided with existing collisions");
            Destroy(structure);
            return null;
        }
        return structure;
    }
    public static bool CanPlaceStructure(GameObject structure, Vector2Int coord)
    {
        // Places the structure and then if it spawns without collision, it deletes the places structure and returns true
        GameObject givenStructure = PlaceStructure(structure, coord);
        if (!givenStructure) return false;
        Destroy(givenStructure);
        return true;
    }
}