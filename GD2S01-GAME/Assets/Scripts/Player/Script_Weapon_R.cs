/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_Weapon_R.cs
Description : Unused script/mechanic
Author : Richard Walters
Mail : richard.walters@mds.ac.nz
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_R : MonoBehaviour
{
    public bool cleansCobwebs, shearsShrubs;

    [SerializeField]
    private Transform m_Camera;
    private int m_iLayerMaskIgnoreRay;

    [SerializeField]
    private Animator m_weaponAnim;

    [SerializeField]
    private GameObject m_CobwebDestroyParticle;

    [SerializeField]
    private GameObject m_ShrubTrimParticle;



    // Start is called before the first frame update
    void Start()
    {
        m_Camera = FindObjectOfType<Script_MouseLook_W>().transform;
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Player");
        m_weaponAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(float interactRange)
    {
        if (m_weaponAnim) //if we have animation
            m_weaponAnim.Play("UseWeapon");

        RaycastHit hit;
        if (Physics.Raycast(m_Camera.position, m_Camera.forward, out hit, interactRange, ~m_iLayerMaskIgnoreRay))
        {
            if (cleansCobwebs)
            {
                if (hit.transform.tag == "Cobweb")
                {
                    if (m_CobwebDestroyParticle)
                        Instantiate(m_CobwebDestroyParticle, hit.point, hit.transform.rotation);
                    Destroy(hit.transform.gameObject);
                }
            }

            if (shearsShrubs)
            {
                if (hit.transform.tag == "Shrub")
                {
                    if (m_ShrubTrimParticle)
                        Instantiate(m_ShrubTrimParticle, hit.point, hit.transform.rotation);
                    hit.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }

            
        }
    }
}
