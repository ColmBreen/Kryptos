using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DecryptRailFence : MonoBehaviour {
    /*
    class Program
    {
        static void Main(string[] args)
        {
            bool isEncrypt;
            Console.WriteLine("Encrypt (E) or Decrypt (D)?");
            string answer = Console.ReadLine();
            if (answer == "E" || answer == "e")
            {
                isEncrypt = true;
                Console.WriteLine("Enter Plaintext: ");
                string plainText = Console.ReadLine();
                Console.WriteLine("Enter Shift: ");
                int shift = Convert.ToInt16(Console.ReadLine());
                string cipher = REncrypt(plainText.ToUpper(), shift);
            }
            else if (answer == "D" || answer == "d")
            {
                isEncrypt = false;
                Console.WriteLine("Enter Ciphertext: ");
                string cipherText = Console.ReadLine();
                Console.WriteLine("Enter Shift: ");
                int shift = Convert.ToInt16(Console.ReadLine());
                string decipher = RDecrypt(cipherText.ToUpper(), shift);
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }
        }

        static string REncrypt(string plainText, int shift)
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
            Console.WriteLine(temp2);
            Console.ReadLine();
            return "nope";
        }

        static string RDecrypt(string cipherText, int shift)
        {
            char[] cText = cipherText.ToCharArray();
            char[] pText = new char[cText.Length];
            int firstLinePos = (shift - 1) * 2;
            int nextPos, nextPos2, nextShift = 0;
            bool isSwitched = true;
            //pText[0] = cText[0];
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
            Console.WriteLine(pText);
            Console.ReadLine();
            return pText.ToString();
        }
    }*/
}
