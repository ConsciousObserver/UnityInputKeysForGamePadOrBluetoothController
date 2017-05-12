using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePadKeyDisplay : MonoBehaviour {

    private Text countText;
    private Text keysText;
    private Text joyStickText;

    private int count;
    private int countAnyKey;

	void Start () {
        countText = transform.Find("CountText").GetComponent<Text>();
        keysText = transform.Find("KeysText").GetComponent<Text>();
        joyStickText = transform.Find("JoyStickText").GetComponent<Text>();
    }

	void Update () {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) )
        {
            countText.text = "Count: " + ++count;
        }

        //if(Input.anyKeyDown)
        //{
        //    anyKeyText.text = "AnyKey: " + ++countAnyKey;
        //}

        Array values = Enum.GetValues(typeof(KeyCode));

        string keys = "";
        foreach (KeyCode code in values)
        {
            if (Input.GetKey(code))
            {
                keys += Enum.GetName(typeof(KeyCode), code) + ", ";
            }
        }
        if (keys != "")
        {
            Debug.Log("keys : " + keys);
            keysText.text = "keys: " + keys;
        }

        float vertical = 0f; ;
        float horizontal = 0f;

        string joystickDirection = "";

        if( (vertical = Input.GetAxis("Vertical")) != 0 || (horizontal = Input.GetAxis("Horizontal")) != 0 )
        {
            joystickDirection = "V=" + vertical + ", H=" + horizontal;
        }

        if (keys != "" || joystickDirection != "")
        {
            Debug.Log("joystickDirection : " + joystickDirection);
            joyStickText.text = "JoyStick: " + joystickDirection;
        }
    }
}
