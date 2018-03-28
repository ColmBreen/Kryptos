using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShift : MonoBehaviour {
    
    private Rigidbody rb;
    private Vector3 vec = new Vector3(0.5f, 0.0f, 0.0f);
    public  bool isRight = true;
    public bool isStart = false;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if (PlayerPrefs.GetInt("isDecryptingCaesar") == 1)
        {
            if (Input.GetKeyDown("right"))
            {
                rb.MovePosition(transform.position - vec);
                isRight = true;
                isStart = true;
            }
            else if (Input.GetKeyDown("left"))
            {
                rb.MovePosition(transform.position + vec);
                isRight = false;
                isStart = true;
            }
        }
    }
}
