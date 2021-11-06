using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_WashingMachine : MonoBehaviour
{
    Script_ObjectiveManager_W m_ObjectiveManager;

    void Start()
    {
        m_ObjectiveManager = GameObject.Find("ObjectiveManager").GetComponent<Script_ObjectiveManager_W>();
    }
    public void AddClothes()
    {
        m_ObjectiveManager.m_clothesNumber--;
    }
}
