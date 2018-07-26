using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	static public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    static public void QuitGame()
    {
        Application.Quit();
    }

    static public void OpenOptions()
    {
        Debug.Log("SOON!");
    }
}
