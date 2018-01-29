using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Note : MonoBehaviour {

    public Text NoteText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            NoteText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NoteText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (NoteText.gameObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
            }
        }
    }
}
