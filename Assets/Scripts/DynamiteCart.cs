using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteCart : Items
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    public int factor = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed * factor * Time.deltaTime, 0.0f, 0.0f);
    }

    public override void DoSomething(GameObject slot, bool playerSide)
    {
        if (slot != null)
            return;

        if (playerSide)
            factor = 1;
        else
            factor = -1;

    }
}
