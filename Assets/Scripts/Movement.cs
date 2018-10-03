using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public WallController wc;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * speed;
        float zMovement = Input.GetAxisRaw("Vertical") * speed;

        switch (wc.direction)
        {
            case WallController.Direction.North:
                rb.MovePosition(new Vector3(transform.position.x + xMovement, transform.position.y, transform.position.z + zMovement));
                break;
            case WallController.Direction.East:
                rb.MovePosition(new Vector3(transform.position.x - zMovement, transform.position.y, transform.position.z + xMovement));
                break;
            case WallController.Direction.South:
                rb.MovePosition(new Vector3(transform.position.x - xMovement, transform.position.y, transform.position.z - zMovement));
                break;
            case WallController.Direction.West:
                rb.MovePosition(new Vector3(transform.position.x + zMovement, transform.position.y, transform.position.z - xMovement));
                break;
        }
    }
}