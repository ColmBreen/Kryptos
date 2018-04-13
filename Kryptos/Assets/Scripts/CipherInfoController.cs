using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CipherInfoController : MonoBehaviour {

    public TMP_Text cipherInfo, cipherInfo2, cipherInfo3;
    public Image cipherExample;
    public Button next;
    public Button done;

    private string sceneName;
    private bool isSecond = false;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void NextClick()
    {
        cipherInfo.gameObject.SetActive(false);
        if (sceneName == "Level3")
        {
            cipherExample.gameObject.SetActive(true);
            next.gameObject.SetActive(false);
            done.gameObject.SetActive(true);
        }
        else if(sceneName == "Level1")
        {
            cipherInfo2.gameObject.SetActive(true);
            next.gameObject.SetActive(false);
            done.gameObject.SetActive(true);
        }
        else if(sceneName == "Level2" && !isSecond)
        {
            cipherInfo2.gameObject.SetActive(true);
            isSecond = true;
        }
        else if (sceneName == "Level2" && isSecond)
        {
            cipherInfo2.gameObject.SetActive(false);
            cipherInfo3.gameObject.SetActive(true);
            next.gameObject.SetActive(false);
            done.gameObject.SetActive(true);
        }
    }

    public void DoneClick()
    {
        Time.timeScale = 1f;
        CipherButton.isCipherInfo = false;
        cipherInfo.gameObject.SetActive(true);
        isSecond = false;
        if (sceneName == "Level3")
            cipherExample.gameObject.SetActive(false);
        else if (sceneName == "Level1")
            cipherInfo2.gameObject.SetActive(false);
        else if(sceneName == "Level2")
            cipherInfo3.gameObject.SetActive(false);
        next.gameObject.SetActive(true);
        done.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
