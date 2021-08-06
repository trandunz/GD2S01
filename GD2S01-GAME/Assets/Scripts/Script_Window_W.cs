using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Window_W : MonoBehaviour
{
    public bool m_bOpen;
    public bool m_isLocked;

    private void Start()
    {
        m_bOpen = false;
        m_isLocked = false;
    }
    public void CloseWindow()
    {
        if (m_bOpen && !m_isLocked)
        {
            GetComponentInChildren<Animator>().SetBool("Close", true);
        }


    }

    public void OpenWindow()
    {
        if (!m_bOpen && !m_isLocked)
        {
            GetComponentInChildren<Animator>().SetBool("Open", true);
        }


    }
}
