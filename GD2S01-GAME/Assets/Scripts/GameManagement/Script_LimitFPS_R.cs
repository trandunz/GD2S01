using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LimitFPS_R : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int m_iTargetFramerate = 60;
    void Awake()
    {
        Application.targetFrameRate = m_iTargetFramerate;
    }
}
