using UnityEngine;
using System.Collections.Generic;

public class SpiritFormationhandler : MonoBehaviour
{
    private int majorformationorder; //1 = follow main formation : 2 = individual formation movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        majorformationorder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            majorformationorder = (majorformationorder == 1 ? 2 : 1); //if majororder = 1 -> 2, and vice versa
            print(majorformationorder);
        }
    }

    public int GetMajorOrder()
    {
        return majorformationorder;
    }
}
