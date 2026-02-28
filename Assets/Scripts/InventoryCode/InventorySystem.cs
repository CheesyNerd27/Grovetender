using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] Transform invPOS;
    [SerializeField] GameObject itemBox;
    //[SerializeField] GameObject pointer;
    [SerializeField] List<GameObject> inventory = new List<GameObject>();
    private List <Color> inventoryColor = new List<Color>();
    [SerializeField] int pointerNumber = 0;
    [SerializeField] int numberInArray = 0;
    [SerializeField] GameObject playercontrollertest;


    public bool pickUpitem = false;
    float TempPOSAdj;


    private void Awake()
    {
        invPOS = GetComponent<Transform>();
      
    }


    private void Update()
    {
       
    }

    public List<GameObject> GetInventory()
    {
        return inventory;
    }


    public void StoreItem(GameObject item)
    {
        pickUpitem = true;
        if (!inventory.Contains(item)) //if inventory does not already contain item
        {
            inventory.Add(item);
            Color col = item.GetComponent<Renderer>().material.color;
            col.r -= 0.3f;
            col.g -= 0.3f;
            col.b -= 0.3f;
            item.GetComponent<Renderer>().material.color = col; //when item is added, makes it dulled by default
            inventoryColor.Add(col); //creates a copy of dulled material color
            if (pickUpitem)
            {
                SpawnboxInArea(item);
            }
        }
    }


   private void SpawnboxInArea(GameObject uiSpawnPoint)
    {
       // Creates Item background (top to bottom)
            var newItem = Instantiate(itemBox, invPOS.transform); //create background itemframe
            TempPOSAdj += 1;
            
          
          //Sets item background for the postion of the inventory
            newItem.transform.position = new Vector2(newItem.transform.position.x, newItem.transform.position.y - TempPOSAdj);
            uiSpawnPoint.layer = LayerMask.NameToLayer("UI");
            uiSpawnPoint.transform.parent = newItem.transform; //sets collected object's parent to the inventory game object, so it can be viewed as a ui element
            uiSpawnPoint.transform.position = newItem.transform.position;
            uiSpawnPoint.transform.position = new Vector3(uiSpawnPoint.transform.position.x, uiSpawnPoint.transform.position.y, uiSpawnPoint.transform.position.z);
    
        pickUpitem = false;
       
    }


    public void SelectItem(int numberInList)
    {
        
        pointerNumber = numberInList;

        if (numberInList == -1) //if selection index goes to -1 (less than inventory count), then slection loops back around
        {

            playercontrollertest.GetComponent<ControllerPlayer>().itemSelect = inventory.Count - 1;
            numberInList = inventory.Count - 1;
            pointerNumber = numberInList;


        }

        else if (numberInList >= inventory.Count)  //if selection index becomes greater than inventory count, then slection loops back around
        {

            playercontrollertest.GetComponent<ControllerPlayer>().itemSelect = 0;
            pointerNumber = 0;

        }

        for (int i = 0; i <= inventory.Count; i++)
        {
           


            if (pointerNumber == i) //indicates selected box
            {

                Color col = inventoryColor[i];
                col.r += 0.3f;
                col.g += 0.3f;
                col.b += 0.3f;
                inventory[i].GetComponent<Renderer>().material.color = col; //makes selected object brigther (to their default color tone)
                

            }
            
          

           
        }

         foreach(GameObject nonSelected in inventory)
        {


            if (pointerNumber != numberInArray) //indicates non-selected box 
            {
                
                Color col = inventoryColor[numberInArray];
                nonSelected.GetComponent<Renderer>().material.color = col; //returns non-selected object to a dulled state
                numberInArray++;
            }
            else if(pointerNumber == numberInArray)
            {
                numberInArray++;
            }
        }
       numberInArray = 0;
    }


    public void CheckItem()
    {


        Debug.Log(inventory[pointerNumber].name);


    }
}
