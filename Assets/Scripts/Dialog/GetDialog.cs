using NUnit.Framework;
using UnityEngine;

public class GetDialog : MonoBehaviour
{
    //whats being packed to pass back to dialogbox
    string newDialog;
    string newPortrait;

    //json file
    public TextAsset DialogFile;

    //is the specific dialog item we picked via the dialog id
    private Dialog dialogItem;

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

    public object[] GrabDialog(int dialogID)
    {
        //grabs all the data out of the dialog json file (Future note: no this line can't be in the start function- it errors out despite how much it would make sense)
        myDialogList = JsonUtility.FromJson<DialogList>(DialogFile.text);

        //grabs the target dialog object from ID
        dialogItem = myDialogList.dialog[dialogID];

        //pulls data to be displayed
        newDialog = dialogItem.text;
        newPortrait = dialogItem.portrait; //this is just the file path to the sprite image file

        //finds the portrait sprite using the file path given
        Sprite portraitSprite = Resources.Load<Sprite>(newPortrait);

        //consolidate data to be displayed
        object[] newEntry = new object[] { newDialog, portraitSprite };

        return newEntry;
    }
}
