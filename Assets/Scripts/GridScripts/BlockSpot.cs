using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpot : MonoBehaviour
{
    protected Vector2Int coord;
    void Start()
    {
        DestroyVisuals();
    }
    public bool IsColliding()
    {
        coord = GridSystem.CoordFromPosition(transform.position);
        if (StructureManager.CheckIfSpotIsTaken(coord))
        {
            print(coord);
            return true;
        }

        StructureManager.IsSpotTaken.AddListener(IsOnSpot);
        return false;
    }
    public void IsOnSpot(Vector2Int checkCoord)
    {
        if (checkCoord == coord) StructureManager.TakeSpot();
    }
    void OnDestroy()
    {
        StructureManager.IsSpotTaken.RemoveListener(IsOnSpot);
    }
    public void GiveToStructure(StructureScript s)
    {
        if (s.blockedSpots.Contains(this)) return;

        s.blockedSpots.Add(this);
    }
    void DestroyVisuals()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();
        if (mr) Destroy(mr);
        if (mf) Destroy(mf);
    }
}
