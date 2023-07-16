using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : Items
{
    [SerializeField]
    protected bool grabed = false;

    public override void DoSomething(GameObject playerSlot, bool playerSide)
    {
        if(playerSlot == null)
        {
            grabed = true;

            // Disable collider
            GetComponent<Collider>().enabled = false;
        }
    }
}
