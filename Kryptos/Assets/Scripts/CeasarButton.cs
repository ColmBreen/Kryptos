using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CeasarButton : MonoBehaviour {

    public Text caesarButtonText;

    private void Update()
    {
        if (caesarButtonText.gameObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {

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
        }
    }
}
