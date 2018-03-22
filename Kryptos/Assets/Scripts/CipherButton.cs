using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CipherButton : MonoBehaviour {

    public Text caesarButtonText;
    public Text caesarText;
    public Text VigenereButtonText;
    public Text VigenereText;
    public InputField inputF;
    public Canvas pause;

    private void Update()
    {
        if (caesarButtonText.gameObject.activeInHierarchy || caesarText.gameObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0) && (!pause.gameObject.activeInHierarchy))
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = true;
                caesarText.gameObject.SetActive(true);
                caesarButtonText.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && (!pause.gameObject.activeInHierarchy))
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar = false;
                caesarButtonText.gameObject.SetActive(true);
                caesarText.gameObject.SetActive(false);
            }
        }
        else if(VigenereButtonText.gameObject.activeInHierarchy || VigenereText.gameObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0)  && (!pause.gameObject.activeInHierarchy))
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = true;
                Debug.Log("yo");
                Cursor.visible = true;
                VigenereText.gameObject.SetActive(true);
                inputF.gameObject.SetActive(true);
                VigenereButtonText.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && VigenereText.gameObject.activeInHierarchy && (!pause.gameObject.activeInHierarchy))
            {
                Debug.Log("yo2");
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere = false;
                VigenereButtonText.gameObject.SetActive(true);
                VigenereText.gameObject.SetActive(false);
                inputF.gameObject.SetActive(false);
            }
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
            inputF.gameObject.SetActive(false);
        }
    }
}
