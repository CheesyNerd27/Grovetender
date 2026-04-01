using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ControllerPlayer : Controller
{
    public Pawn pawnobject;





    ////////////////////////////////////////// testing for demo - dexter
    [SerializeField]
    private GameObject uiForInv;
    public int itemSelect;




    //////////////////////////////////////////












    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemSelect = 0;
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


        ///////////////////////////////////////////////////////////////////////////////// testing for demo - dexter
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (uiForInv.activeInHierarchy == false)
            {
                uiForInv.SetActive(true);
                if (uiForInv.GetComponent<InventorySystem>().GetInventory() != null && uiForInv.GetComponent<InventorySystem>().GetInventory().Count > 0)
                {
                    uiForInv.GetComponent<InventorySystem>().SelectItem(itemSelect);
                }
            }
            else
            {
                uiForInv.SetActive(false);

            }
        }

        if (uiForInv.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                itemSelect--;
                uiForInv.GetComponent<InventorySystem>().SelectItem(itemSelect);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                itemSelect++;
                uiForInv.GetComponent<InventorySystem>().SelectItem(itemSelect);
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                uiForInv.GetComponent<InventorySystem>().CheckItem();
            }

            if (Input.GetMouseButtonDown(0))
            {
                // Create a ray from the camera through the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit; // Variable to store information about what the ray hit

                // Perform the raycast
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Collectable")
                    {
                        uiForInv.GetComponent<InventorySystem>().StoreItem(hit.transform.gameObject);
                    }
                }
            }

        }
       



        /////////////////////////////////////////////////////////////////////////////////
    }
}
