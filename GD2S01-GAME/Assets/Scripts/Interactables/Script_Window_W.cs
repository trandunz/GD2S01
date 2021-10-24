using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Window_W : MonoBehaviour
{
    public bool m_bOpen;
    public bool m_isLocked;

    //window cleaning things
    public bool m_isClean;
    public bool m_isWet;
    public GameObject m_DirtyWindow;
    public GameObject m_CleanWindow;
    public GameObject m_WetWindow;

    private void Start()
    {
        m_bOpen = false;
        m_isLocked = false;
        m_isClean = false;
        m_isWet = false;
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

    public void CleanWindow()
    {
        if(m_isWet)
        {
            m_WetWindow.SetActive(false);
            m_CleanWindow.SetActive(true);
            m_isClean = true;
        }
    }

    public void WetWindow()
    {
        if(!m_isClean)
        {
            m_DirtyWindow.SetActive(false);
            m_WetWindow.SetActive(true);
            m_isWet = true;
        }
    }
}
