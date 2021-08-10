using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script_Mother_W : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().SetTrigger("Run");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().ResetTrigger("Run");
            GetComponent<Animator>().SetTrigger("Suspect");
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            GetComponent<Animator>().ResetTrigger("Run");
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
