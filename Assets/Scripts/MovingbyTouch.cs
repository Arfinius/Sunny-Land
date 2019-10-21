using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingbyTouch : MonoBehaviour {

    public RectTransform trans;

    public FixedJoystick FixJoy;

    public Image joyImage, joyHandle, joyImageJump;

    private bool alreadyTouch = false;

    void Start()
    {
        trans.GetComponent<RectTransform>();

        joyImage.enabled = false;
        joyHandle.enabled = false;
        joyImageJump.enabled = false;
        
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (alreadyTouch)
            {
                FixJoy.Clicked();
            }

            if (!alreadyTouch)
            {
                Touch touch = Input.GetTouch(0);
                if ((touch.position.x > Screen.width / 2) || (touch.position.y > (Screen.height * 3 / 5)))
                {
                    return;
                }
                FixJoy.OnClick();

                joyImage.enabled = true;
                joyHandle.enabled = true;
                joyImageJump.enabled = true;
                alreadyTouch = true;

                trans.position = touch.position;
            } 
        }
        else
        {
            if (alreadyTouch)
            {
                joyImage.enabled = false;
                joyHandle.enabled = false;
                joyImageJump.enabled = false;
                alreadyTouch = false;

                FixJoy.UnClicked();
            }
        }
    } 
}
