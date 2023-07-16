using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb = null;

    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private string verticalAxis = "Vertical";

    [SerializeField]
    private string horizontalAxis = "Horizontal";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mH = Input.GetAxis(horizontalAxis);
        float mV = Input.GetAxis(verticalAxis);
        rb.velocity = new Vector3(mH * moveSpeed, rb.velocity.y, mV * moveSpeed);

        //Debug.Log("Axis :"+ mH.ToString());
    }
}
