using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{
    bool playerDetection = false;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public Image portrait;
    public string newDialog;

    private void Start()
    {
        //make sure dialog box defaults to hidden
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if player is in the npc's space and hits dialog trigger (Space)
        if(playerDetection && Input.GetKeyDown(KeyCode.Space))
        {
            print("Dialog started");
            CreateDialogBox();
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

    private void CreateDialogBox()
    {
        dialogText.text = newDialog;
        dialogBox.SetActive(true);
    }

    public void CloseDialogBox()
    {
        dialogBox.SetActive(false);
        print("Dialog Stopped");
    }
}
