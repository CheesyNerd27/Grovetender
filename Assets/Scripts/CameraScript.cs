using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; //target for camera to look at
    public float distance; //distance between target and camera
    //private float rotationX;
    //private float rotationY;
    public float camerarotaionX; //official camera angle
    public Vector3 Offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rotationX = 0f;
        //rotationY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //doing this just so I don't have to deal with error messages for now
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            distance += 1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            distance -= 1;
        }

        //rotationX = target.transform.localEulerAngles.y;
        //rotationY = target.transform.localEulerAngles.x;
        Quaternion rotation = Quaternion.Euler(0, 0, 0); //set rotation value to equal the rotation of the camera and time

        Vector3 position = target.position - (rotation * new Vector3(0, 0, distance) - Offset); //set camera position and angle based on rotation, wanted distance and target offset amount
        //*tecnhincally the abpce position line of code doesn't not need to facot in rotation and you could just make one offset ie target.position + offset; however, I'm keeping this line
        //of code as is as a template just incase we will need to update cameraview based on an object's rotation (I doubt it, but just incase for now).
        transform.position = position;
        transform.localEulerAngles = new Vector3(camerarotaionX, 0, 0);
    }
}
