using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    [SerializeField]
    private GameObject Wagon = null;

    //[SerializeField]
    //private bool player1 = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Wagon)
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }
}
