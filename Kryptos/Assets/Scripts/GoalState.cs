using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoalState : MonoBehaviour {

    public Text levelCompleteText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            levelCompleteText.gameObject.SetActive(true);
            Invoke("Complete", 3);
        }
    }

    private void Complete()
    {
        SceneManager.LoadScene("Level0");
    }
}
