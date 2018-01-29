using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CeasarButton : MonoBehaviour {

    public Text caesarButtonText;
    public Text caesarText;
    public Text VigenereButtonText;
    public Text VigenereText;

    private void Update()
    {
        if (caesarButtonText.gameObject.activeInHierarchy || caesarText.gameObject.activeInHierarchy ||
            VigenereButtonText.gameObject.activeInHierarchy || VigenereText.gameObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0) && (caesarButtonText.gameObject.activeInHierarchy || caesarText.gameObject.activeInHierarchy))
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = true;
                caesarText.gameObject.SetActive(true);
                caesarButtonText.gameObject.SetActive(false);
            }
            else if (Input.GetMouseButtonDown(0) && (VigenereButtonText.gameObject.activeInHierarchy || VigenereText.gameObject.activeInHierarchy))
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = true;
                VigenereText.gameObject.SetActive(true);
                VigenereButtonText.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && caesarText.gameObject.activeInHierarchy)
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = false;
                caesarText.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && VigenereText.gameObject.activeInHierarchy)
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = false;
                VigenereText.gameObject.SetActive(false);
            }
        }

        if (caesarText.gameObject.activeInHierarchy)
        {
            caesarButtonText.gameObject.SetActive(false);
        }
        if (VigenereText.gameObject.activeInHierarchy)
        {
            VigenereButtonText.gameObject.SetActive(false);
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
