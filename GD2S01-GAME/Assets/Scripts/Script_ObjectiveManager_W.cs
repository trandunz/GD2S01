using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ObjectiveManager_W : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_TaskList;
    public TMPro.TextMeshProUGUI m_CompletedList;

    private GameObject[] m_CobwebObjectList;
    public int m_CWNumber;

    private bool m_GrabText;
    private void Start()
    {
        m_GrabText = true;
        m_CobwebObjectList = GameObject.FindGameObjectsWithTag("Cobweb");
        m_CWNumber = m_CobwebObjectList.Length;
    }

    private void Update()
    {
        if (m_GrabText)
        {
            m_TaskList = GameObject.FindGameObjectWithTag("TaskList").GetComponent<TMPro.TextMeshProUGUI>();
            m_TaskList.text = "Clean Up Gobwebs";
            m_CompletedList = GameObject.FindGameObjectWithTag("TaskFinished").GetComponent<TMPro.TextMeshProUGUI>();
            m_CompletedList.text = "";
            m_GrabText = false;
        }
        if (m_CWNumber <= 0)
        {
            m_TaskList.text = "";
            m_CompletedList.text = "Clean Up Cobwebs";
        }
        else
        {
            m_TaskList.text = "Clean Up Cobwebs (" + m_CWNumber + " Left)";
        }
        
    }
}
