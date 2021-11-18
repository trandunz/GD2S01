/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : ScriptableObject_Tool_W.cs
Description : contains info needed for tools
Author : William Inman
Mail : william.inman@mds.ac.nz
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolData", menuName = "ScriptableObjects/Tool")]
public class ScriptableObject_Tool_W : ScriptableObject
{
    public string ToolName;

    public GameObject m_ParticleSystem;
    public float fInteractRange = 2;

    public AudioClip UseSound;

    public bool inPlayerPossession = false;
}
