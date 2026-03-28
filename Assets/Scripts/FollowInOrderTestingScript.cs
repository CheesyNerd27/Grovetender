using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public class FollowInOrderTestingScript : MonoBehaviour
{
    //each formation group will be xactly that, a group. since groupls can be dynamically created and modified it wouldn't be optimal to create a new scrip variation for every possibility of a 
    //formation, so instead, when spirits are connected close to eachother (or otherwise placed/connected to the nearest connectable sprite within an acceptable distance), then that sprite becomes a part
    //of the larget sprite "formation" (group). So when moving a "formation" we will simply move the group object and subsequently, move the grouping's children.

    //there needs to be multiple differnt "modes."
    // - all spirit formations mob toward the target
    // - selected spirit formations adhere to a centeralized, centerd point (so the formations move in formations) -- this just an effective change to agent targeting and formation level
    // (ie. all formations moving one way, then select a couple of other formations to stary off for a bit)
    // - every spirit formation adhere to a centeralized, centered point (so the formations move in formations)

    public Transform target;
    public NavMeshAgent agent; //parent "formation" group
    public GameObject FormationHandler;

    //public bool closestone;
    [SerializeField]
    private float stoppingdistance;

    private int overridemajororder; //1 = follows main formation : 2 = individual formation movemnt : 0 = null order

    private List<GameObject> SpiritFormations = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(target.position);
        agent.enabled = false;
        FormationHandler = GameObject.Find("FormationHandlerTesting");
        overridemajororder = 0;
        //closestone = false;
        /*
        foreach (GameObject childformation in gameObject.GetComponentsInChildren<GameObject>())
        {
            if(childformation.gameObject.tag == "FormationGroup") 
            {
                SpiritFormations.Add(childformation);
            }
        }
        if(SpiritFormations.Count > 0)
        {
            majorformationorder = 1;
        }
        else
        {
            majorformationorder = 2;
        }
        */
        if (gameObject.tag == "FormationGroupMain")
        {
            agent.enabled = true;
            //agent.SetDestination(target.position);
        }

    }

    // Update is called once per frame
    void Update()
    {

        float xdistance = Mathf.Abs(transform.position.x - target.position.x);
        float zdistance = Mathf.Abs(transform.position.z - target.position.z);
        float cdistance = Mathf.Pow(xdistance, 2) + Mathf.Pow(zdistance, 2);

        if (FormationHandler.GetComponent<SpiritFormationhandler>().GetMajorOrder() == 1)
        {
            if (gameObject.tag == "FormationGroupMain")
            {
                agent.enabled = true;
            }
            else if (gameObject.tag == "FormationGroup")
            {
                agent.enabled = false;
            }
        }
        else if (FormationHandler.GetComponent<SpiritFormationhandler>().GetMajorOrder() == 2)
        {
            if (gameObject.tag == "FormationGroupMain")
            {
                agent.enabled = false;
            }
            else if (gameObject.tag == "FormationGroup")
            {
                agent.enabled = true;
            }
        }
        if (agent.enabled)
        {
            agent.SetDestination(target.position);
            if (Mathf.Sqrt(cdistance) <= stoppingdistance)
            {
                //foreach (GameObject g in SpiritFormations)
                {
                    //g.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                }
                agent.isStopped = true;
            }
            else if (agent.isStopped && Mathf.Sqrt(cdistance) > stoppingdistance)
            {
                //foreach (GameObject g in SpiritFormations)
                {
                    //g.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                }
                agent.isStopped = false;
            }
        }
        /*
        if (Mathf.Sqrt(cdistance) <= stoppingdistance)
        {
            foreach (Transform t in SpiritFormations)
            {
                t.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                t.gameObject.GetComponent<FollowInOrderTestingScript>().closestone = false;
            }
            closestone = true;
        }
        else if (agent.isStopped && Mathf.Sqrt(cdistance) > stoppingdistance && closestone)
        {
            foreach (Transform t in SpiritFormations)
            {
                t.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                t.gameObject.GetComponent<FollowInOrderTestingScript>().closestone = false;
            }
        }
        */


    }

    public void AddFormation(GameObject _formation)
    {
        SpiritFormations.Add(_formation);
    }
    public List<GameObject> ReturnFormationList()
    {
        return (SpiritFormations);
    }

}
