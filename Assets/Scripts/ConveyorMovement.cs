using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMovement : Grabable
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    public GameObject[] checkPoints;
    private int indexPoint = 0;

    // Update is called once per frame
    void Update()
    {
        if (!grabed && indexPoint < checkPoints.Length)
        {
            // Move
            transform.position += (checkPoints[indexPoint].transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;

            // Set forward
            if ((checkPoints[indexPoint].transform.position - transform.position).normalized != Vector3.zero)
            {
                gameObject.transform.forward = (checkPoints[indexPoint].transform.position - transform.position).normalized;
            }

            // Reach a checkpoint
            if ((transform.position - checkPoints[indexPoint].transform.position).magnitude < 0.1f)
            {
                indexPoint++;
            }
        }
    }
}