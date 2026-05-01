using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class EntityCollisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collision2222!");
        if (gameObject.tag == "Collectable")
        {
            if (GameObject.Find("TestController").GetComponent<ControllerPlayer>().hasenabledgrouptesting)
            {
                if (other.gameObject != null && other.gameObject.tag == "FormationGroup")
                {
                    print("collision!");
                    gameObject.transform.SetParent(other.gameObject.transform, true); //Makes the object a child of parent while keeping its world position
                    GameObject.Find("TestController").GetComponent<ControllerPlayer>().hasenabledgrouptesting = false;
                    GameObject.Find("TestController").GetComponent<ControllerPlayer>().objreference = null;
                    other.gameObject.GetComponent<FollowInOrderTestingScript>().refigurebounds();
                }
            }
        }
    }
}
