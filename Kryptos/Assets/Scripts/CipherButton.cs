using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CipherButton : MonoBehaviour {

    public Text caesarButtonText;
    public Text caesarText;
    public Text VigenereButtonText;
    public Text VigenereText;
    public Canvas pause;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (caesarButtonText.gameObject.activeInHierarchy) && (!pause.gameObject.activeInHierarchy))
        {
            GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = true;
            caesarText.gameObject.SetActive(true);
            Debug.Log("Active");
            caesarButtonText.gameObject.SetActive(false);
        }
        else if (Input.GetMouseButtonDown(0) && (VigenereButtonText.gameObject.activeInHierarchy || VigenereText.gameObject.activeInHierarchy) && (!pause.gameObject.activeInHierarchy))
        {
            GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = true;
            VigenereText.gameObject.SetActive(true);
            VigenereButtonText.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && caesarText.gameObject.activeInHierarchy && (!pause.gameObject.activeInHierarchy))
        {
            GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = false;
            caesarButtonText.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && VigenereText.gameObject.activeInHierarchy && (!pause.gameObject.activeInHierarchy))
        {
            GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = false;
            VigenereText.gameObject.SetActive(false);
            VigenereButtonText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && this.name == "CaesarButton")
        {
            caesarButtonText.gameObject.SetActive(true); 
        }
        else if(other.gameObject.CompareTag("Player") && this.name == "VigenereButton")
        {
            VigenereButtonText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            caesarButtonText.gameObject.SetActive(false);
            caesarText.gameObject.SetActive(false);
            VigenereButtonText.gameObject.SetActive(false);
            VigenereText.gameObject.SetActive(false);
        }
    }
}
