using NUnit.Framework;
using UnityEngine;
using static SampleDialogStuff;

public class SampleDialogStuff : MonoBehaviour
{
    string newDialog;
    string newPortrait;
    private Dialog dialogItem;

    //json file
    public TextAsset DialogText;

    //creates individual dialog item objects
    [System.Serializable]
    public class Dialog
    {
        public int id;
        public string npc;
        public string text;
        public string portrait;
    }

    //creates a list of dialog class objects
    [System.Serializable]
    public class DialogList
    {
        public Dialog[] dialog;
    }

    //the overall list of dialog items from the json
    public DialogList myDialogList = new DialogList();

    public string[] GrabDialog(int dialogID)
    {
        //grabs all the data out of the dialog json file (Future note: no this line can't be in the start function- it errors out despite how much it would make sense)
        myDialogList = JsonUtility.FromJson<DialogList>(DialogText.text);

        //grabs the target dialog object from ID
        dialogItem = myDialogList.dialog[dialogID];

        //pulls data to be displayed
        newDialog = dialogItem.text;
        newPortrait = dialogItem.portrait;

        //consolidate data to be displayed
        string[] newEntry = new string[] { newDialog, newPortrait };

        return newEntry;
    }
}
