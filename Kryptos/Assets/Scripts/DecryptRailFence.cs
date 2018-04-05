using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DecryptRailFence : MonoBehaviour {

    public string test;
    public float buttonWidth = 50;
    public float buttonHeight = 50;
    private int i, j, k;
    private bool keyDown = true;
    public int key = 3;
    public GUIStyle myStyle;
    string textEnter = "";


    private void OnGUI()
    {
        if(PlayerPrefs.GetInt("isDecryptingRailFence") == 1)
        {
            if (test.Length % 2 != 0)
            {
                char[] textEntered = test.ToCharArray();
                
                j = 0;
                k = -((test.Length - 1) / 2);
                for (int i = 0; i < test.Length; i++)
                {
                    textEnter = GUI.TextField(new Rect((Screen.width / 2) + (k * buttonWidth), (Screen.height / 2) + (buttonHeight * j), buttonWidth, buttonHeight), textEnter, 1);
                    if(!textEnter.Equals(""))
                    {
                        textEntered[i] = textEnter[0];
                    }
                    
                    k++;
                    if (j == (key - 1))
                    {
                        keyDown = false;
                    }
                    else if (j == 0 && keyDown == false)
                    {
                        keyDown = true;
                    }

                    if (keyDown)
                    {
                        j++;
                    }
                    else
                    {
                        j--;
                    }
                }
                Debug.Log(textEntered.ToString());
            }
            else
            {

            }
        }
    }

    static void REncrypt(string plainText, int shift)
    {
        char[] pTextR = plainText.ToCharArray();
        char[,] railFence = new char[shift, pTextR.Length];
        int j = 0;
        string temp, temp2 = "";
        bool isDown = true;
        for(int i = 0; i < pTextR.Length; i++)
        {
            railFence[j, i] = pTextR[i];
            if (isDown)
            {
                j++;
            }
            else
            {
                j--;
            }
            if((j + 1) == shift)
            {
                isDown = false;
            }
            if(j == 0 && isDown == false)
            {
                isDown = true;
            }
        }
        for(int i = 0; i < shift; i++)
        {
            for(int k = 0; k < pTextR.Length; k++)
            {
                temp = "poop" + railFence[i, k];
                if(temp != "poop")
                {
                    temp2 = temp2 + railFence[i, k];
                }
                    
            }
        }
    }

    static void RDecrypt(string cipherText, int shift)
    {
        char[] cText = cipherText.ToCharArray();
        char[] pText = new char[cText.Length];
        int firstLinePos = (shift - 1) * 2;
        int nextPos, nextPos2, nextShift = 0;
        bool isSwitched = true;
        int k = 0;
        for(int i = 0; i < shift; i++)
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
    }
}
