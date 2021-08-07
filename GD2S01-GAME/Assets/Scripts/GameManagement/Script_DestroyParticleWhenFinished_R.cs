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
