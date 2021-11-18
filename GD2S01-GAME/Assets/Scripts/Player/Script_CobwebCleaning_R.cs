/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : Script_CobwebCleaning_R.cs
Description : Mostly unused script (was moved elsewhere)
Author : Richard Walters
Mail : richard.walters@mds.ac.nz
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CobwebCleaning_R : MonoBehaviour
{
    [SerializeField]
    private Transform m_Camera;
    [SerializeField]
    private int m_iLayerMaskIgnoreRay;
    [SerializeField]
    private GameObject m_CobwebDestroyParticle;
    [SerializeField]
    private Animator m_brushAnim;

    public float fInteractRange = 3;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = FindObjectOfType<Script_MouseLook_W>().transform;
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Player");
        m_brushAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_brushAnim.Play("BrushSweepAnim");
            RaycastHit hit;
            if (Physics.Raycast(m_Camera.position, m_Camera.forward, out hit, fInteractRange, ~m_iLayerMaskIgnoreRay))
            {
                if (hit.transform.tag == "Cobweb")
                {
                    Instantiate(m_CobwebDestroyParticle, hit.point, hit.transform.rotation);
                    Destroy(hit.transform.gameObject);
                }
            }


        }

    }
}
