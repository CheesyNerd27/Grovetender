using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    bool playerDetection = false;

    // Update is called once per frame
    void Update()
    {
        //if player is in the npc's space and hits dialog trigger (F)
        if(playerDetection && Input.GetKeyDown(KeyCode.F))
        {
            print("Dialog started!");
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
}
