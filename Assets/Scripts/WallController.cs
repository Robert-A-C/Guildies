using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public Camera cam;

    public enum Direction { North, East, South, West }
    public Direction direction;

    public Transform target;
    public float offset1;
    public float offset2;

    public Animator Walls;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            direction++;
            if ((int)direction > 3)
            {
                direction = Direction.North;
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            direction--;
            if ((int)direction < 0)
            {
                direction = Direction.West;
            }

            ;
        }

        cam.transform.LookAt(target);

        switch (direction)
        {
            case Direction.North:
                cam.transform.localPosition = Vector3.Lerp(cam.transform.position, new Vector3(target.localPosition.x, target.localPosition.y + offset1, target.localPosition.z - offset1), Time.deltaTime );
                Walls.SetBool("North", true);
                Walls.SetBool("East", false);
                Walls.SetBool("South", false);
                Walls.SetBool("West", false);
                break;
            case Direction.East:
                cam.transform.localPosition = Vector3.Lerp(cam.transform.position, new Vector3(target.localPosition.x + offset1, target.localPosition.y + offset1, target.localPosition.z), Time.deltaTime );
                Walls.SetBool("North", false);
                Walls.SetBool("East", true);
                Walls.SetBool("South", false);
                Walls.SetBool("West", false);
                break;
            case Direction.South:
                cam.transform.localPosition = Vector3.Lerp(cam.transform.position, new Vector3(target.localPosition.x, target.localPosition.y + offset1, target.localPosition.z + offset1), Time.deltaTime);
                Walls.SetBool("North", false);
                Walls.SetBool("East", false);
                Walls.SetBool("South", true);
                Walls.SetBool("West", false);
                break;
            case Direction.West:
                cam.transform.localPosition = Vector3.Lerp(cam.transform.position, new Vector3(target.localPosition.x - offset1, target.localPosition.y + offset1, target.localPosition.z), Time.deltaTime );
                Walls.SetBool("North", false);
                Walls.SetBool("East", false);
                Walls.SetBool("South", false);
                Walls.SetBool("West", true);
                break;
        }
    }
}