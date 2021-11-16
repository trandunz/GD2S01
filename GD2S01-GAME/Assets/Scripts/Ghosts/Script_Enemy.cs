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
    [SerializeField] Script_Door_W m_Door;

    [SerializeField] AudioClip m_BossMusic;

    Vector3 m_StartPos;

    // Start is called before the first frame update
    void Start()
    {       
        m_Body = GetComponent<CharacterController>();
        m_Body.enabled = false;
        m_StartPos = transform.localPosition;
        m_MoveClock = m_MoveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bMove)
        {
            if (transform.localPosition == m_StartPos)
            {
                m_MoveClock = m_MoveTime;
            }
            if (m_MoveClock > 0)
            {
                m_Body.enabled = true;
                m_MoveClock -= Time.deltaTime;
                m_Body.Move(transform.rotation * Vector3.forward * m_MoveSpeed * Time.deltaTime);
                GameObject.FindGameObjectWithTag("spookyboy").GetComponent<AudioSource>().Stop();
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().PlayOneShot(m_BossMusic);
                }
            }
            else
            {
                m_Body.enabled = false;
                m_bMove = false;
                m_MoveClock = m_MoveTime;
                transform.localPosition = m_StartPos;
                m_Door.CloseDoor();
                m_Door.m_isLocked = true;
                GameObject.FindGameObjectWithTag("spookyboy").GetComponent<Script_SpookyManager_B>().SwapBack();
                GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<Script_AudioManager_B>().CanPlay();
            }
        }
    }
}

// collider


