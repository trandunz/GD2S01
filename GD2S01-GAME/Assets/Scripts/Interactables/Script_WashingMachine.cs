/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_WashingMachine.cs
Description : Adds to score when player interacts with clothes in their inventory
Author : Richard Walters
Mail : richard.walters@mds.ac.nz
*/

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
