using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

    private Rigidbody rb;
    private bool isMoved = false;
    private Vector3 vec = new Vector3(0.0f, 5.0f, 0.0f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (GameObject.Find("Shift").GetComponent<DecryptCaesar>().isDeciphered && isMoved == false)
        {
            rb.MovePosition(transform.position + vec);
            isMoved = true;
        }
        else if (!GameObject.Find("Shift").GetComponent<DecryptCaesar>().isDeciphered && isMoved == true)
        {
            rb.MovePosition(transform.position - vec);
            isMoved = false;
        }
	}
}
