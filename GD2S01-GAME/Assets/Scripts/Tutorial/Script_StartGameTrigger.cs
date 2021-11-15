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
