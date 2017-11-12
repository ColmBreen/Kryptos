using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CeasarButton : MonoBehaviour {

    public Text caesarButtonText;
    public Text caesarText;

    private void Update()
    {
        if (caesarButtonText.gameObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecrytping = true;
                caesarText.gameObject.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && caesarButtonText.gameObject.activeInHierarchy)
            {
                caesarButtonText.gameObject.SetActive(false);
                GameObject.Find("Player").GetComponent<FirstPersonController>().isDecrytping = false;
                caesarText.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            caesarButtonText.gameObject.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            caesarButtonText.gameObject.SetActive(false);
            caesarText.gameObject.SetActive(false);
        }
    }
}
