using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] toCraft;
    [SerializeField]
    private GameObject[] checkPoints;

    [SerializeField]
    private float spawnDelay = 1.0f;

    [SerializeField]
    private float accelerationDelay = 30.0f;
    [SerializeField]
    private float accelerationValue = 1.0f;
    [SerializeField]
    private float minDelay = 1.0f;

    private float accelerationTimer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);

        accelerationTimer = 0.0f;
    }

    private void Update()
    {
        accelerationTimer += Time.deltaTime;
    }

    // Update is called once per frame
    private void SpawnObject()
    {
        // Make spawn
        GameObject go = Instantiate(toCraft[(int)Random.Range(0, toCraft.Length)], transform.position, transform.rotation);
        // Weak
        go.GetComponent<ConveyorMovement>().checkPoints = checkPoints;

        // Faster
        if (accelerationTimer > accelerationDelay)
        {
            accelerationTimer = 0.0f;

            spawnDelay -= accelerationValue;
            if (spawnDelay < minDelay)
                spawnDelay = minDelay;

            CancelInvoke("SpawnObject");
            InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);
        }
    }
}
