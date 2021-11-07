using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_WashingMachine : MonoBehaviour
{
    Script_ObjectiveManager_W m_ObjectiveManager;

    bool m_Active = false;

    void Start()
    {
        m_ObjectiveManager = GameObject.Find("ObjectiveManager").GetComponent<Script_ObjectiveManager_W>();
    }

    public void AddClothes()
    {
        if (m_Active == false)
        {
            GetComponent<AudioSource>().Play();
            m_Active = true;
        }

       
        m_ObjectiveManager.m_clothesNumber--;
    }
}
