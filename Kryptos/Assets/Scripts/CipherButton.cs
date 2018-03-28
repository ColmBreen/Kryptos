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
    }
    public int i = 0;
    public Text ButtonText;
    public Text cipherText;
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
                    GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = true;
                    cipherText.gameObject.SetActive(true);
                    ButtonText.gameObject.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && (!pause.gameObject.activeInHierarchy))
                {
                    GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = false;
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
                    GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = true;
                    cipherText.gameObject.SetActive(true);
                    inputF.gameObject.SetActive(true);
                    ButtonText.gameObject.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && cipherText.gameObject.activeInHierarchy && (!pause.gameObject.activeInHierarchy))
                {
                    GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = false;
                    ButtonText.gameObject.SetActive(true);
                    cipherText.gameObject.SetActive(false);
                    inputF.gameObject.SetActive(false);
                }
            }
        }
        else if (sceneName == "Level3")
        {
            if (ButtonText.gameObject.activeInHierarchy || cipherText.gameObject.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0) && (!pause.gameObject.activeInHierarchy))
                {
                    GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingRailFence = true;
                    cipherText.gameObject.SetActive(true);
                    ButtonText.gameObject.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && cipherText.gameObject.activeInHierarchy && (!pause.gameObject.activeInHierarchy))
                {
                    GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingRailFence = false;
                    ButtonText.gameObject.SetActive(true);
                    cipherText.gameObject.SetActive(false);
                }
            }
        }
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
