/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_LimitFPS_R.cs
Description : Limits FPS to 60
Author : Richard Walters
Mail : richard.walters@mds.ac.nz
*/

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
