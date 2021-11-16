using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    public bool m_bMove = false;
    [SerializeField] float m_MoveSpeed = 5.0f;
    [SerializeField] float m_MoveTime = 5.0f;
    float m_MoveClock;

    CharacterController m_Body;

    Vector3 m_StartPos;

    // Start is called before the first frame update
    void Start()
    {
        m_Body = GetComponent<CharacterController>();
        m_StartPos = transform.position;
        m_MoveClock = m_MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bMove)
        {
            if (m_MoveClock > 0)
            {
                m_MoveClock -= Time.deltaTime;
                m_Body.Move(transform.rotation * Vector3.forward * m_MoveSpeed * Time.deltaTime);
            }
            else
            {
                m_bMove = false;
                m_MoveClock = m_MoveTime;
                transform.position = m_StartPos;
            }
        }
    }
}
