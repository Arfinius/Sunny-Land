using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicationSet : MonoBehaviour {

    MovingByKeyboard keyboardMove;
    PlayerMovement playerMovement;

    private void Start()
    {
        keyboardMove = FindObjectOfType<MovingByKeyboard>().GetComponent<MovingByKeyboard>();
        playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }


    private void Awake()
    {
        // General Settings
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
        Screen.orientation = ScreenOrientation.Landscape;
        if (Application.platform == RuntimePlatform.Android)
        {
            playerMovement.enabled = true;
            keyboardMove.enabled = false;
        }
        else
        {
            playerMovement.enabled = false;
            keyboardMove.enabled = true;
        }
    }
}
