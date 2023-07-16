using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    [SerializeField]
    private float minTime = 30.0f;
    [SerializeField]
    private float maxTime = 60.0f;

    [SerializeField]
    private float initialMin = 30.0f;
    [SerializeField]
    private float initialMax = 60.0f;

    private BoxCollider[] boxColliders;
    private MeshRenderer[] meshRenderers = null;

    [SerializeField]
    private Engine[] enginesP1;

    [SerializeField]
    private Engine[] enginesP2;

    // Start is called before the first frame update
    void Start()
    {
        boxColliders = GetComponentsInChildren<BoxCollider>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (BoxCollider collider in boxColliders)
            collider.enabled = false;

        foreach (MeshRenderer meshRenderer in meshRenderers)
            meshRenderer.enabled = false;

        InvokeRepeating("Warning", Random.Range(initialMin, initialMax), Random.Range(minTime, maxTime));
    }

    private void Warning()
    {
        foreach (BoxCollider collider in boxColliders)
            collider.enabled = true;

        foreach (MeshRenderer meshRenderer in meshRenderers)
            meshRenderer.enabled = true;

        // Do red button fxs and play music
    }

    public void WalkIn(bool playerSide)
    {
        foreach (BoxCollider collider in boxColliders)
            collider.enabled = false;

        foreach (MeshRenderer meshRenderer in meshRenderers)
            meshRenderer.enabled = false;

        // stop red button music and fxs

        if (playerSide)
        {
            Engine engine = enginesP2[Random.Range(0, enginesP2.Length)];
            Debug.Log(engine + "Knocked off !");

            engine.currentLife = 0;
        }
        else
        {
            Engine engine = enginesP1[Random.Range(0, enginesP1.Length)];
            Debug.Log(engine + "Knocked off !");

            engine.currentLife = 0;
        }
    }
}