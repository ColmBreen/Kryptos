using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Text doorText;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && doorText.gameObject.activeInHierarchy && this.name == "Door")
        {
            SceneManager.LoadScene("Caesar");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorText.gameObject.SetActive(false);
        }
    }

}
