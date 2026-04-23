using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{
    //checks for if the player is near the NPC
    bool playerDetection = false;
    
    //The changing parts of the dialog box
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public Image portrait;

    //reference to the NPC we're talking to-> to decide what dialog ID we want
    GameObject NPCObject;

    //matches up to the specific dialog id we want in the json
    private int dialogID;

    //reference to our Dialog Keeper
    public SampleDialogStuff DialogKeeper;


    private void Start()
    {
        //make sure dialog box defaults to hidden
        dialogBox.SetActive(false);

        //grab parent object-> refers to the NPC being talked to
        NPCObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if player is in the npc's space and hits dialog trigger (left click)
        if(playerDetection && Input.GetMouseButtonDown(0))
        {
            CreateDialogBox(NPCObject.name);
        }

    }

    //change detection bool to true if player is in the npc's space
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerDetection = true;
        }
    }

    //change detection bool to false once player leaves the npc's space
    private void OnTriggerExit(Collider other)
    {
        playerDetection = false;
    }

    private void CreateDialogBox(string NPC)
    {
        if (NPC == "SampleNPC")
        {
            dialogID = 0;
        }

        else if (NPC == "SampleNPC2")
        {
            dialogID = 1;
        }

        //get new dialog for NPC
        string[] newEntry = DialogKeeper.GrabDialog(dialogID);


        //change dialog box parts
        dialogText.text = newEntry[0];
        print(newEntry[1]); //portrait result standin

        // activate/show the box
        dialogBox.SetActive(true);
    }

    public void CloseDialogBox()
    {
        // deactivate/ hide box
        dialogBox.SetActive(false);
    }
}
