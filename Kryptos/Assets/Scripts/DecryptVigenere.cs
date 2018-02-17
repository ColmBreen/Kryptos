using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DecryptVigenere : MonoBehaviour {

    public bool isEncrypt;
    public Text cipherText;

    public void VCipher(string key)
    {
        isEncrypt = false;
        cipherText.text = "VTPYC LSEZS";
        string cipherT = cipherText.text.ToUpper();
        Debug.Log(cipherT);
        cipherText.text = VDecrypt(cipherT, key);
    }

    string VEncrypt(string pText, string shift)
    {
        char[] pTextC = pText.ToCharArray();
        char[] shiftC = shift.ToCharArray();
        int a = 'A';
        int z = 'Z';
        int offset = ('Z' - a) + 1;
        char currentChar, currentShiftChar, shiftChar;
        int currentCharMinusA, shiftedChar, currentShiftCharMinusA;
        int j = 0;

        for (int i = 0; i < pTextC.Length; i++)
        {
            currentChar = pTextC[i];
            
            if (Convert.ToInt32(currentChar) > 64 && Convert.ToInt32(currentChar) < 91)
            {
                j = j % shiftC.Length;
                currentShiftChar = shiftC[j];
                currentCharMinusA = currentChar - a;
                currentShiftCharMinusA = currentShiftChar - a;
                if (isEncrypt)
                {
                    shiftedChar = (currentCharMinusA + currentShiftCharMinusA) % offset;
                }
                else
                {
                    shiftedChar = (currentCharMinusA - currentShiftCharMinusA) % offset;
                }

                if (shiftedChar < 0)
                {
                    shiftChar = (char)((z + 1) + shiftedChar);
                }
                else
                {
                    shiftChar = (char)(a + shiftedChar);
                }
                pTextC[i] = shiftChar;
                shiftedChar = 0;
                j++;
            }
        }
        return new string(pTextC);
    }

    string VDecrypt(string cText, string shift)
    {
        if(shift == "")
        {
            return "VTPYC LSEZS";
        }
        else
        {
            //isEncrypt = false;
            return VEncrypt(cText, shift.ToUpper());
        }
           
    }
}
