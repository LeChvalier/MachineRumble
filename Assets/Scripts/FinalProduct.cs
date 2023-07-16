using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProduct : Grabable
{
    [SerializeField]
    public bool side = false;

    public override void DoSomething(GameObject playerSlot, bool playerSide)
    {
        if (playerSlot == null && side == playerSide)
        {
            grabed = true;

            // Disable collider
            GetComponent<Collider>().enabled = false;
        }
    }
}
