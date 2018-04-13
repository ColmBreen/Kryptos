using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DecryptRail : MonoBehaviour {

    public GameObject closedCell;
    public GameObject openCell;
    public GameObject railFenceLetter;
    public GameObject railFenceKey;

    public Text cipherString;
    public Text plainString;

    public Canvas parent;

    private GameObject keyInput;
    private GameObject letter;

    public float buttonWidth, buttonHeight;

    private int i, j, k;
    private int correctKey;
    private int key;

    private bool iskeyDown = true;
    private bool doneKey, doneLetters = false;

    private char[] lettersEntered;

    private string textBeingEntered, textSubmitted;

    // Use this for initialization
    void Start () {
        correctKey = 3;
        lettersEntered = new char[cipherString.text.Length];
        for(i = 0; i < cipherString.text.Length; i++)
        {
            lettersEntered[i] = '_';
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(PlayerPrefs.GetInt("isDecryptingRailFenceKey") == 1 && !doneKey)
        {
            keyInput = GameObject.Instantiate<GameObject>(railFenceKey);
            keyInput.gameObject.GetComponent<TMP_InputField>().onEndEdit.AddListener(RailFenceKey);
            keyInput.transform.SetParent(parent.transform);
            keyInput.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            keyInput.gameObject.name = "RailFenceKey";
            doneKey = true;
            Debug.Log("Instantiate Key");
        }
        else if(PlayerPrefs.GetInt("isDecryptingRailFence") == 1 && !doneLetters)
        {
            Debug.Log("Instantiate Letters");
            j = 0;
            k = -((cipherString.text.Length - 1) / 2);
            for (i = 0; i < cipherString.text.Length; i++)
            {
                letter = GameObject.Instantiate<GameObject>(railFenceLetter);
                letter.gameObject.GetComponent<TMP_InputField>().onValueChanged.AddListener(RailFenceDecrypt);
                letter.gameObject.GetComponent<TMP_InputField>().onEndEdit.AddListener(Complete);
                letter.transform.SetParent(parent.transform);
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
        }
        else if(PlayerPrefs.GetInt("isDecryptingRailFence") == 0 && doneLetters)
        {
            for (i = 0; i < cipherString.text.Length; i++)
            {
                Destroy(GameObject.Find("RailFence").transform.Find("Letter " + i).gameObject);
                lettersEntered[i] = '_';
            }
            string s = new string(lettersEntered);
            plainString.text = s.ToUpper();
            doneLetters = false;
        }
	}

    public void RailFenceKey(string enteredKey)
    {
        int.TryParse(enteredKey, out key);
        PlayerPrefs.SetInt("isDecryptingRailFenceKey", 0);
        PlayerPrefs.SetInt("isDecryptingRailFence", 1);
        doneKey = false;
        Destroy(keyInput);
    }

    public void RailFenceDecrypt(string enteredLetter)
    {
        int letterNum = 0;
        for (i = 0; i < cipherString.text.Length; i++)
        {
            if (GameObject.Find("Letter " + i).GetComponent<TMP_InputField>().isFocused == true)
            {
                letterNum = i;
            }
        }
        if (string.IsNullOrEmpty(enteredLetter))
        {
            lettersEntered[letterNum] = '_';
        }
        else
        {
            lettersEntered[letterNum] = enteredLetter[0];
        }
        string s = new string(lettersEntered);
        plainString.text = s.ToUpper();
        
    }

    public void Complete(string s)
    {
        if (plainString.text == RDecrypt(cipherString.text, correctKey))
        {
            Debug.Log("Huzzah!");
            closedCell.gameObject.SetActive(false);
            openCell.gameObject.SetActive(true);
        }
    }

    private string RDecrypt(string cipherText, int shift)
    {
        char[] cText = cipherText.ToCharArray();
        char[] pText = new char[cText.Length];
        int firstLinePos = (shift - 1) * 2;
        int nextPos, nextPos2, nextShift = 0;
        bool isSwitched = true;
        int k = 0;
        for (i = 0; i < shift; i++)
        {
            nextPos2 = i * 2;
            nextPos = firstLinePos - nextPos2;
            nextShift = nextPos;
            if (i == 0 || i == shift - 1)
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
