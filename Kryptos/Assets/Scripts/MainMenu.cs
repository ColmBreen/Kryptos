using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void PlayButton()
    {
        //Loads level if play is clicked
        PauseMenuController.isMenuActive = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level0");
    }

    public void ExitButton()
    {
        //quits the game if exit is clicked
        Application.Quit();
    }
}
