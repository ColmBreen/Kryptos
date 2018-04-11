using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Text doorText;
    private bool level1, level2, level3;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (level1)
            {
                SceneManager.LoadScene("Level1");
            }
            else if (level2)
            {
                SceneManager.LoadScene("Level2");
            }
            else if (level3)
            {
                SceneManager.LoadScene("Level3");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.name == "Caesar")
        {
            level1 = true;
            doorText.gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Player") && gameObject.name == "Vigenere")
        {
            level2 = true;
            doorText.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && gameObject.name == "RailFence")
        {
            level3 = true;
            doorText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.name == "Caesar")
        {
            level1 = false;
            doorText.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && gameObject.name == "Vigenere")
        {
            level2 = false;
            doorText.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && gameObject.name == "RailFence")
        {
            level3 = false;
            doorText.gameObject.SetActive(false);
        }
    }

}
