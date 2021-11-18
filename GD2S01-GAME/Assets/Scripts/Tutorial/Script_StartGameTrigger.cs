/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_StartGameTrigger.cs
Description : opens and closes the door at the start of the game
Author : William Inman
Mail : william.inman@mds.ac.nz
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_StartGameTrigger : MonoBehaviour
{
    [SerializeField] Script_Door_W m_StartDoor;

    private void Start()
    {
        m_StartDoor.GetComponentInChildren<Animator>().SetBool("Open90", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Player" && m_StartDoor.m_bOpen)
        {
            m_StartDoor.GetComponentInChildren<Animator>().SetBool("Close90", true);
            m_StartDoor.m_isLocked = true;
        }
    }
}
