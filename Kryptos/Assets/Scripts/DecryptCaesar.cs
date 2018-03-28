using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DecryptCaesar : MonoBehaviour {

    public Text cText;
    public bool isDeciphered = false;
    public GameObject closedCell, openCell;

    private int shift;

    void OnTriggerEnter(Collider other)
    {
        if(!GameObject.Find("Shift").GetComponent<MoveShift>().isRight && GameObject.Find("Shift").GetComponent<MoveShift>().isStart && other.gameObject.name != "Letter (25)")
        {
            shift =  1;
            cText.text = CDecrypt(cText.text, shift);
            if(cText.text == "HELLO WORLD")
            {
                closedCell.SetActive(false);
                openCell.SetActive(true);
            }
            else
            {
                closedCell.SetActive(true);
                openCell.SetActive(false);
            }
        }
        else if (GameObject.Find("Shift").GetComponent<MoveShift>().isRight && GameObject.Find("Shift").GetComponent<MoveShift>().isStart && other.gameObject.name != "Letter")
        {
            shift = 1;
            cText.text = CEncrypt(cText.text, shift);
            if (cText.text == "HELLO WORLD")
            {
                closedCell.SetActive(false);
                openCell.SetActive(true);
            }
            else
            {
                closedCell.SetActive(true);
                openCell.SetActive(false);
            }
        }
    }

    string CEncrypt(string pText, int shiftP)
    {
        char[] pTextC = pText.ToCharArray();
        int a = 'A';
        int z = 'Z';
        int offset = ('Z' - a) + 1;
        char currentChar, shiftChar;
        int currentCharMinusA, shiftedChar;
        pTextC = pText.ToCharArray();
        for (int i = 0; i < pTextC.Length; i++)
        {

            currentChar = pTextC[i];
            if (Convert.ToInt32(currentChar) > 64 && Convert.ToInt32(currentChar) < 91)
            {
                currentCharMinusA = currentChar - a;
                shiftedChar = (currentCharMinusA + shiftP) % offset;
                if (shiftedChar < 0)
                {
                    shiftChar = (char)((z + 1) + shiftedChar);
                }
                else
                    shiftChar = (char)(a + shiftedChar);
                pTextC[i] = shiftChar;
                shiftedChar = 0;
            }
        }

        return new string(pTextC);
    }

    string CDecrypt(string cText, int shiftP)
    {
        return CEncrypt(cText, -shiftP);
    }
}
