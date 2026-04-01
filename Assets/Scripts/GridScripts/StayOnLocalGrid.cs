using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StayOnLocalGrid : MonoBehaviour
{
    void LateUpdate()
    {
        // (used for blocking spots)
        transform.localPosition = GridSystem.AlignPositionOnGrid(transform.localPosition);
    }
}