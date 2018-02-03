using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public Transform canvas;
    public Button resume;
    public Button exit;
    public Text caesarText;
    public Text VigenereText;

    private void Start()
    {
        resume = resume.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
    }

    //https://www.youtube.com/watch?v=PyEmRVRHWL8&t=7s
    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && caesarText.gameObject.activeInHierarchy)
        {
            caesarText.gameObject.SetActive(false);
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && canvas.gameObject.activeInHierarchy == false) && 
            (!caesarText.gameObject.activeInHierarchy) && (VigenereText.gameObject.activeInHierarchy == false))       
        {
            Cursor.visible = true;
            Debug.Log("Pause");
            canvas.gameObject.SetActive(true);
            GameObject.Find("Player").GetComponent<FirstPersonController>().isMenuActive = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && canvas.gameObject.activeInHierarchy == true &&
            !GameObject.Find("CaesarButton").GetComponent<CipherButton>().caesarText.gameObject.activeInHierarchy)
        {
            Cursor.visible = false;
            canvas.gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<FirstPersonController>().isMenuActive = false;
        }	
	}

    public void ResumeButton()
    {
        Cursor.visible = false;
        canvas.gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<FirstPersonController>().isMenuActive = false;
    }

    public void ExitButton()
    {
        //Loads level if play is clicked
        SceneManager.LoadScene("Main Menu");
    }
}
