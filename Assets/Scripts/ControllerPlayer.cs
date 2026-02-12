using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ControllerPlayer : Controller
{
    public Pawn pawnobject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public override void IstantiateControlConnection()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (pawnobject == null) //doing this just so I don't have to deal with error messages for now
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pawnobject.Move(transform.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            pawnobject.Move(-transform.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            pawnobject.Move(-transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            pawnobject.Move(transform.right);
        }
    }
}
