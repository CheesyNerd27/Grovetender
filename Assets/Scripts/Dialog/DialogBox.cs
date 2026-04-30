using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    //checks for if the player is near the NPC
    bool playerDetection = false;
    
    //The changing parts of the dialog box
    public GameObject dialogBox;//the box itself (the parent object)
    private TextMeshProUGUI dialogText; // the text element
    private Image portrait;//the image element for the sprites
    
    //reference to our Dialog Keeper (the object holding the dialog getter script grabbing the data from the json)
    private GetDialog DialogKeeper;

    //reference to the NPC we're talking to-> to decide what dialog ID we want
    GameObject NPCObject;

    //matches up to the specific dialog id we want in the json
    private int dialogID;

    private void Awake()
    {
        //make sure dialog box starts as hidden
        dialogBox.SetActive(false);

        //grab the relevant children objects of dialog box
        dialogText = dialogBox.transform.Find("DialogText").GetComponent<TextMeshProUGUI>();
        portrait = dialogBox.transform.Find("PortraitContainer/Portrait").GetComponent<Image>();
        DialogKeeper = dialogBox.transform.Find("DialogKeeper").GetComponent<GetDialog>();

        //grab parent object-> refers to the NPC being talked to-> used to decide which dialog is shown
        NPCObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if player is in the npc's space and hits dialog trigger (left click)
        if(playerDetection && Input.GetMouseButtonDown(0))
        {
            //runs the dialog box creation function
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
        //decide which dialog (via dialog id) will be shown
        if (NPC == "SampleNPC")
        {
            dialogID = 0;
        }

        else if (NPC == "SampleNPC2")
        {
            dialogID = 1;
        }


        //get new dialog for NPC using the dialog id
        object[] newEntry = DialogKeeper.GrabDialog(dialogID);

        //change dialog box parts
        dialogText.text = (string)newEntry[0]; //text
        portrait.sprite = (Sprite)newEntry[1]; //portrait image

        // activate/show the box
        dialogBox.SetActive(true);
    }

    public void CloseDialogBox()
    {
        // deactivate/ hide box
        dialogBox.SetActive(false);
    }
}
