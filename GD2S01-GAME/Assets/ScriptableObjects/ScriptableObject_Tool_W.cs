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
