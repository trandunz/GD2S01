/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_Window_W.cs
Description : opens and closes windows with functions
Author : Benjamin Bartlett
Mail : benjamin.bartlett@mds.ac.nz
*/
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
