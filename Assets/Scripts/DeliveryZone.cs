using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : Items
{
    private int gold = 0;
    [SerializeField]
    private bool side = false;

    public override void DoSomething(GameObject slot, bool playerSide)
    {
        if (slot == null || side != playerSide)
            return;

        if (slot.GetComponent<ConveyorMovement>() == null)
        {
            gold += 1;
            Debug.Log("GOLD : " + gold);
            Destroy(slot.gameObject);
        }
    }
}
