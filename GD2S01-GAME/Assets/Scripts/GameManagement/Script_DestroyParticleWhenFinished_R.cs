
/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_DestroyParticleWhenFinished_R.cs
Description : Destroys particles when they are finished (as long as they dont loop)
Author : Richard Walters
Mail : richard.walters@mds.ac.nz
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DestroyParticleWhenFinished_R : MonoBehaviour
{
    private ParticleSystem m_partSys;
    // Start is called before the first frame update
    void Start()
    {
        m_partSys = gameObject.GetComponent<ParticleSystem>(); //find the particle component
    }

    // Update is called once per frame
    void Update()
    {
        if (m_partSys) //Do we actually have a particle?
        {
            if (!m_partSys.IsAlive()) //Is it finished playing?
            {
                Destroy(gameObject); //destroy it
            }
        }
    }
}
