using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : Items
{
    [SerializeField]
    private int life = 2;
    [HideInInspector]
    public int currentLife = 2;

    [SerializeField]
    private bool side = false;

    [SerializeField]
    private FinalProduct finalProduct = null;
    
    [SerializeField]
    private float craftingTime = 5.0f;

    [SerializeField]
    private GameObject cookingPlace = null;

    private float remainingTime = -1.0f;
    private bool produce = false;

    private void Start()
    {
        currentLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        if (produce)
        {
            if (remainingTime < 0.0f)
            {
                produce = false;

                FinalProduct fprod = Instantiate(finalProduct, cookingPlace.transform.position, transform.rotation);
                fprod.GetComponent<FinalProduct>().side = side;
            }
            else if(currentLife > 0)
                remainingTime -= Time.deltaTime;
        }
    }

    public override void DoSomething(GameObject slot, bool playerSide)
    {
        if (playerSide == side)
        {
            // Start cooking
            if (slot != null && !produce && currentLife > 0)
            {
                produce = true;
                remainingTime = craftingTime;
                Destroy(slot.gameObject);
            }
            else if(currentLife < life)
            {
                currentLife++;
            }
        }
        else
        {
            // Knock off
            if (slot == null)
            {
                currentLife--;
                if (currentLife <= 0)
                {
                    Debug.Log("Knocked off !");
                }
            }
        }

    }
}

