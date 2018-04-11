using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CipherButton : MonoBehaviour {

    private string sceneName;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        PlayerPrefs.SetInt("isDoneDecryptingRailFence", 0);
        PlayerPrefs.SetInt("isDecryptingRailFenceKey", 0);
    }
    public int i = 0;
    public Text ButtonText;
    public Text cipherText;
    public Text otherText;
    public InputField inputF;
    public Canvas pause;

    private void Update()
    {
        if (sceneName == "Level1")
        {
            if (ButtonText.gameObject.activeInHierarchy || cipherText.gameObject.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0) && (!pause.gameObject.activeInHierarchy))
                {
                    PlayerPrefs.SetInt("isDecryptingCaesar", 1);
                    cipherText.gameObject.SetActive(true);
                    ButtonText.gameObject.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && (!pause.gameObject.activeInHierarchy))
                {
                    PlayerPrefs.SetInt("isDecryptingCaesar", 0);
                    ButtonText.gameObject.SetActive(true);
                    cipherText.gameObject.SetActive(false);
                }
            }
        }
        else if (sceneName == "Level2")
        {
            if (ButtonText.gameObject.activeInHierarchy || cipherText.gameObject.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0) && (!pause.gameObject.activeInHierarchy))
                {
                    Debug.Log("yo " + i);
                    i++;
                    PlayerPrefs.SetInt("isDecryptingVigenere", 1);
                    cipherText.gameObject.SetActive(true);
                    inputF.gameObject.SetActive(true);
                    ButtonText.gameObject.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && cipherText.gameObject.activeInHierarchy && (!pause.gameObject.activeInHierarchy))
                {
                    PlayerPrefs.SetInt("isDecryptingVigenere", 0);
                    ButtonText.gameObject.SetActive(true);
                    cipherText.gameObject.SetActive(false);
                    inputF.gameObject.SetActive(false);
                }
            }
        }
        else if (sceneName == "Level3")
        {
            if (Input.GetMouseButtonDown(0) && (!pause.gameObject.activeInHierarchy) && ButtonText.gameObject.activeInHierarchy)
            {
                //PlayerPrefs.SetInt("isDecryptingRailFence", 1);
                PlayerPrefs.SetInt("isDecryptingRailFenceKey", 1);
                cipherText.gameObject.SetActive(true);
                otherText.gameObject.SetActive(true);
                ButtonText.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && cipherText.gameObject.activeInHierarchy && (!pause.gameObject.activeInHierarchy))
            {
                PlayerPrefs.SetInt("isDecryptingRailFence", 0);
                otherText.gameObject.SetActive(false);
                ButtonText.gameObject.SetActive(true);
                Invoke("deactivateCipherText", 0.05f);
            }
        }
    }

    private void deactivateCipherText()
    {
        cipherText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ButtonText.gameObject.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ButtonText.gameObject.SetActive(false);
            cipherText.gameObject.SetActive(false);
            if(sceneName == "Level2")
                inputF.gameObject.SetActive(false);
        }
    }
}
