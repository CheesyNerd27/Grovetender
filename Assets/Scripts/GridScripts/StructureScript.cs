using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureScript : MonoBehaviour
{
    [HideInInspector]
    public List<BlockSpot> blockedSpots = new List<BlockSpot>();

    public void AttachColliders()
    {
        blockedSpots.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            BlockSpot blockSpot = transform.GetChild(i).GetComponent<BlockSpot>();
            if (!blockSpot) continue;
            blockSpot.GiveToStructure(this);
        }
    }
    public bool StructIsColliding()
    {
        foreach (BlockSpot block in blockedSpots)
        {
            if (block.IsColliding())
                return true;
        }
        return false;
    }
}