using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gun;

    public Joystick movementJoyStick;
    public Joystick aimJoyStick;

    public float ms;
    public float storedAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(gun, Vector3.right, Quaternion.identity, this.transform);
    }

    
    void Update()
    {
        // Movement
        float movementX = movementJoyStick.Horizontal * Time.deltaTime * ms;
        float movementY = movementJoyStick.Vertical * Time.deltaTime * ms;
        transform.position = new Vector3(this.transform.position.x + movementX,
                                        this.transform.position.y + movementY,
                                        0);

        // Rotation 
        if (aimJoyStick.Horizontal == 0f && aimJoyStick.Vertical == 0f)
        {
            transform.localEulerAngles = new Vector3(0, 0, storedAngle);
        }
        else
        {
            float angle = Mathf.Atan2(aimJoyStick.Direction.y, aimJoyStick.Direction.x) * 180f / Mathf.PI;
            storedAngle = angle;
            transform.localEulerAngles = new Vector3(0, 0, storedAngle);
        }
    }
}
