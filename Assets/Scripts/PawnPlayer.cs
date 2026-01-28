using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PawnPlayer : Pawn
{
    private CollisionFlags collisionFlags;          // last collision flag returned from control move
    CharacterController characterController;        // instance of character controller
    private ControllerPlayer pawnparent;

    public float movespeed;
    private Vector3 lookdirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();     // get handle to characterController
        gameObject.tag = "Player";
        lookdirection = gameObject.transform.right;
        //healthcomponent = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(Vector3 movevector)
    {
        Vector3 movement = movevector * movespeed;
        movement *= Time.deltaTime;    // set movement to delta time for consistent speed

        collisionFlags = characterController.Move(movement); // move the player.
    }

    public void RotateSpite(Vector3 movevector)
    {
        lookdirection = movevector;
        if (lookdirection == gameObject.transform.up)
        {
            //spite up model
        }
        else if(lookdirection == -gameObject.transform.up)
        {
            //spride down model
        }
        else if (lookdirection == -gameObject.transform.right)
        {
            //flip sprite left model
        }
        else if (lookdirection == gameObject.transform.right)
        {
            //flip sprite right model
        }
    }
}
