/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_TriggerSpooky_B.cs
Description : causes spooky to happen
Author : Benjamin Bartlett
Mail : benjamin.bartlett@mds.ac.nz
*/
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
