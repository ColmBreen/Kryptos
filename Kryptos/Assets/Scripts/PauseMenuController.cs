using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public Transform canvas;
    public Button resume;
    public Button exit;
    public Text CipherText;
    public InputField inputF;
    string currentScene;
    

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        resume = resume.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
    }

    //https://www.youtube.com/watch?v=PyEmRVRHWL8&t=7s
    // Update is called once per frame
    void Update ()
    {
        if(currentScene == "Level0")
        {
            if ((Input.GetKeyDown(KeyCode.Escape) && canvas.gameObject.activeInHierarchy == false))
            {
                canvas.gameObject.SetActive(true);
                PlayerPrefs.SetInt("isMenuActive", 1);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && canvas.gameObject.activeInHierarchy == true)
            {
                canvas.gameObject.SetActive(false);
                PlayerPrefs.SetInt("isMenuActive", 0);
            }
        }
        else if (currentScene != "Main Menu")
        {
            if ((Input.GetKeyDown(KeyCode.Escape) && !canvas.gameObject.activeInHierarchy) &&
                (!CipherText.gameObject.activeInHierarchy))
            {
                canvas.gameObject.SetActive(true);
                PlayerPrefs.SetInt("isMenuActive", 1);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && canvas.gameObject.activeInHierarchy &&
                (!CipherText.gameObject.activeInHierarchy))
            {
                canvas.gameObject.SetActive(false);
                PlayerPrefs.SetInt("isMenuActive", 0);
            }
        }
	}

    public void ResumeButton()
    {
        canvas.gameObject.SetActive(false);
        PlayerPrefs.SetInt("isMenuActive", 0);
    }

    public void ExitButton()
    {
        //Loads level if play is clicked
        SceneManager.LoadScene("Main Menu");
    }
}
