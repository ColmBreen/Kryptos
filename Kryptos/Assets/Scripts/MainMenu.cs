using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    //public Canvas pauseMenu;
    public Button yes;
    public Button no;

    // Use this for initialization
    void Start ()
    {
        yes = yes.GetComponent<Button>();
        no = no.GetComponent<Button>();
    }

    public void PlayButton()
    {
        //Loads level if play is clicked
        SceneManager.LoadScene("Caesar");
    }

    public void ExitButton()
    {
        //quits the game if exit is clicked
        Application.Quit();
    }
}
