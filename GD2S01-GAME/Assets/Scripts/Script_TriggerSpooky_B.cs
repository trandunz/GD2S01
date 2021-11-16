using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TriggerSpooky_B : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.tag is "Player")
        {
            Debug.Log("if statement entered");
            StartCoroutine(GameObject.FindGameObjectWithTag("spookyboy").GetComponent<Script_SpookyManager_B>().StartGameSpooky());
        }
    }
}
