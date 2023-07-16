using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("PauseButton"))
            Debug.Log("pause");

        if (Input.GetButton("PauseButton_2"))
            Debug.Log("pause 2");

        if (Input.GetButton("Interact"))
            Debug.Log("Interact");
        
        if (Input.GetButton("Interact_2"))
            Debug.Log("Interact_2");
    }
}
