using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DecryptRailFence : MonoBehaviour {

    public GameObject railFenceLetter;
    public GameObject railFenceKey;
    public Text cipherString;
    public Text plainString;
    public Canvas parent;
    private GameObject keyInput;
    private GameObject letter;
    
    public float buttonWidth, buttonHeight;
    private int i, j, k;
    private int key;
    private bool iskeyDown = true;
    private bool isLettersInActive = false;
    private char[] lettersEntered;

    private bool doneKey, doneLetters = false;

    private void Start()
    {
        lettersEntered = new char[cipherString.text.Length];
        for (int i = 0; i < cipherString.text.Length; i++)
        {
            lettersEntered[i] = '_';
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("isDecryptingRailFence") == 1 && PlayerPrefs.GetInt("isDecryptingRailFenceKey") == 1 && !doneKey)
        {
            keyInput = GameObject.Instantiate<GameObject>(railFenceKey);
            keyInput.gameObject.GetComponent<InputField>().onEndEdit.AddListener(RailFenceKey);
            keyInput.transform.SetParent(parent.transform);
            keyInput.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            keyInput.gameObject.name = "RailFenceKey";
            doneKey = true;
            Debug.Log("Instantiate Key");
        } 
        else if (PlayerPrefs.GetInt("isDecryptingRailFence") == 1 && !doneLetters && PlayerPrefs.GetInt("isDecryptingRailFenceKey") == 0)
        {
            plainString.gameObject.SetActive(true);
            j = 0;
            k = -((cipherString.text.Length - 1) / 2);
            for (i = 0; i < cipherString.text.Length; i++)
            {
                letter = GameObject.Instantiate<GameObject>(railFenceLetter);
                letter.gameObject.GetComponent<InputField>().onValueChanged.AddListener(RailFenceDecrypt);
                letter.transform.SetParent(parent.transform);
                if (cipherString.text.Length % 2 != 0)
                    letter.GetComponent<RectTransform>().anchoredPosition = new Vector2((k * buttonWidth), (buttonHeight * j));
                else
                    letter.GetComponent<RectTransform>().anchoredPosition = new Vector2((k * buttonWidth), (buttonHeight * j));
                letter.gameObject.name = "Letter " + i.ToString();

                k++;
                if (j == -(key - 1))
                {
                    iskeyDown = false;
                }
                else if (j == 0 && iskeyDown == false)
                {
                    iskeyDown = true;
                }

                if (iskeyDown)
                {
                    j--;
                }
                else
                {
                    j++;
                }
            }
            doneLetters = true;
            Debug.Log("Instantiate Letters");
        }
        else if(doneKey && doneLetters && PlayerPrefs.GetInt("isDecryptingRailFence") == 0 && !isLettersInActive)
        {
            for (int i = 0; i < cipherString.text.Length; i++)
            {
                GameObject.Find("Letter " + i).SetActive(false);
            }
            plainString.gameObject.SetActive(false);
            isLettersInActive = true;
            Debug.Log("Deactivate Letters");
        }
        else if (doneKey && doneLetters && PlayerPrefs.GetInt("isDecryptingRailFence") == 1 && isLettersInActive)
        {
            for (int i = 0; i < cipherString.text.Length; i++)
            {
                GameObject.Find("RailFence").transform.Find("Letter " + i).gameObject.SetActive(true);
            }
            plainString.gameObject.SetActive(true);
            isLettersInActive = false;
            Debug.Log("Activate Letters");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (i = 0; i < cipherString.text.Length; i++)
            {
                if (GameObject.Find("Letter " + i).GetComponent<InputField>().isFocused == true)
                {
                    //GameObject.Find("Letter " + i).GetComponent<InputField>().isFocused = false;
                }
            }
        }
    }

    public void RailFenceKey(string enteredKey)
    {
        int.TryParse(enteredKey, out key);
        PlayerPrefs.SetInt("isDecryptingRailFenceKey", 0);
        keyInput.gameObject.SetActive(false);
    }

    public void RailFenceDecrypt(string cipherText)
    {
        if(PlayerPrefs.GetInt("isDecryptingRailFence") == 1)
        {
            int letterNum = 0;
            for (i = 0; i < cipherString.text.Length; i++)
            {
                if (GameObject.Find("Letter " + i).GetComponent<InputField>().isFocused == true)
                {
                    letterNum = i;
                }
            }
            if (cipherText.Length == 0)
            {
                lettersEntered[letterNum] = '+';
            }
            else
                lettersEntered[letterNum] = cipherText[0];
            string s = new string(lettersEntered);
            plainString.text = s.ToUpper();
            if (plainString.text == RDecrypt(cipherString.text, key))
            {
                Complete();
            }
        }
    }

    private void Complete()
    {
        Debug.Log("Hurray");
    }

    private string RDecrypt(string cipherText, int shift)
    {
        char[] cText = cipherText.ToCharArray();
        char[] pText = new char[cText.Length];
        int firstLinePos = (shift - 1) * 2;
        int nextPos, nextPos2, nextShift = 0;
        bool isSwitched = true;
        int k = 0;
        for(i = 0; i < shift; i++)
        {
            nextPos2 = i * 2;
            nextPos = firstLinePos - nextPos2;
            nextShift = nextPos;
            if(i == 0 || i == shift - 1)
            {
                for (int j = i; j < cText.Length; j += firstLinePos)
                {
                    pText[j] = cText[k];
                    k++;
                }
            }
            else
            {
                for (int j = i; j < cText.Length; j += nextShift)
                {
                    pText[j] = cText[k];
                    k++;
                    if (isSwitched == false)
                    {
                        nextShift = nextPos2;
                        isSwitched = true;
                    }
                    else
                    {
                        nextShift = nextPos;
                        isSwitched = false;
                    }
                            
                }
            }
            isSwitched = true;
        }
        string s = new string(pText);
        return s.ToUpper();
    }
}
