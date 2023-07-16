using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtons : MonoBehaviour
{
    private RedButton parentScript = null;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<RedButton>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            parentScript.WalkIn(player.playerSide);
        }
    }
}
