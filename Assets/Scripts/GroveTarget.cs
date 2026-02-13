using UnityEngine;

public class GroveTarget : MonoBehaviour
{
    [SerializeField] private Transform playerTf;
    [SerializeField] private float returnSpeed = 5f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the left mouse button is being held
        if (Input.GetMouseButton(0))
        {
			// Get mouse position in world coordinates
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Move GroveTarget to mouse position
            transform.position = mousePosition;
        }
		else    // If the left mouse button is not being held
		{
			// Move GroveTarget to player position with smoothing
			transform.position = Vector3.Lerp(transform.position, playerTf.position, Time.deltaTime * returnSpeed);
        }
    }
}
