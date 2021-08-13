using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script_Exorcist_W : MonoBehaviour
{
    private bool DoOnce;
    private NavMeshAgent m_Agent;
    private Transform m_Player;
    // Start is called before the first frame update
    void Start()
    {
        DoOnce = true;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Player = GameObject.Find("Player_W").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoOnce)
        {
            m_Agent.SetDestination(m_Player.position);
            DoOnce = false;
        }
        m_Agent.SetDestination(m_Player.position);
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().SetTrigger("Walk");
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().ResetTrigger("Walk");
            GetComponent<Animator>().SetTrigger("Suspect");
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().ResetTrigger("Walk");
            GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
