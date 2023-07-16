using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [SerializeField]
    private float slowValue = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.currentSpeed -= slowValue;

            if (player.currentSpeed < player.minMoveSpeed)
                player.currentSpeed = player.minMoveSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.currentSpeed += slowValue;

            if (player.currentSpeed > player.moveSpeed)
                player.currentSpeed = player.moveSpeed;
        }
    }
}
