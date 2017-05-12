using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {
    public float speed = 1;
    public bool moveWithJoystick;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float movementX;
        float movementY;
        if (moveWithJoystick)
        {
            movementX = Input.GetAxis("Horizontal");
            movementY = Input.GetAxis("Vertical");
        } else
        {
            movementX = Input.GetAxis("Mouse X");
            movementY = Input.GetAxis("Mouse Y");
        }

        if (movementX != 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * movementX);
        }

        if (movementY != 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * movementY);
        }
    }
}
