using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowClean_B : MonoBehaviour
{
    //window cleaning things
    public bool m_isClean;
    public bool m_isWet;

    public GameObject m_Window;

    public Material m_DirtyMaterial;
    public Material m_WetMaterial;
    public Material m_CleanMaterial;

    private void Start()
    {
        m_isClean = false;
        m_isWet = false;
    }
    public bool CleanWindow()
    {
        if (m_isWet && !m_isClean)
        {
            m_Window.GetComponent<MeshRenderer>().material = m_CleanMaterial;
            m_isClean = true;

            return true;
        }
        return false;
    }

    public void WetWindow()
    {
        if (!m_isClean)
        {
            m_Window.GetComponent<MeshRenderer>().material = m_WetMaterial;
            m_isWet = true;

        }
    }
}
