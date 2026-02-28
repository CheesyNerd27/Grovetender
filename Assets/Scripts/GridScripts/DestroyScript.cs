using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float delay;
    [Tooltip("Leave this EMPTY to delete the gameobject")]
    public MonoBehaviour destroy;
    void Awake()
    {
        if (destroy)
            Destroy(destroy, delay);
        else
            Destroy(gameObject, delay);
    }
}