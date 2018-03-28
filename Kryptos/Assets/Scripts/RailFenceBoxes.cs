using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailFenceBoxes : MonoBehaviour
{

    public string temp = "poops";
    public float boxWidth = 100;
    public float boxHeight = 100;
    /*
    private void OnGUI()
    {
        if(temp.Length % 2 != 0)
        {
            int j = -Mathf.FloorToInt(temp.Length/2);
            for (int i = 0; i < temp.Length; i++)
            {
                Debug.Log("yo");
                GUI.TextField(new Rect((Screen.width / 2) + (j * 100), (Screen.height / 2)/* + (j * 100), boxWidth, boxHeight), "poop");
                j++;
            }
        }
        else
        {
            int j = -Mathf.FloorToInt(temp.Length / 2);
            for (int i = 0; i < temp.Length; i++)
            {
                Debug.Log(temp);
                if (j != 0)
                {
                    GUI.TextField(new Rect((Screen.width / 2) + (j * 100) + 50, (Screen.height / 2)/* + (j * 100) + 50, boxWidth, boxHeight), "poop");
                }
                j++;
            }
        }

    }
    */
}
