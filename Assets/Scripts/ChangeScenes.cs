using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour {

	public void ChangeScene (string nazwa)
    {
        // Changing scenes
        SceneManager.LoadScene(nazwa);
    }

    public void ApplicationQuit()
    {
        // Quit from application
        Application.Quit();
    }
}
