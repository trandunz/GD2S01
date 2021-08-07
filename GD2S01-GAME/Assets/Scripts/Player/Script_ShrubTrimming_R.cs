using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ShrubTrimming_R : MonoBehaviour
{
    [SerializeField]
    private Transform m_Camera;
    [SerializeField]
    private int m_iLayerMaskIgnoreRay;
    [SerializeField]
    private GameObject m_ShrubTrimParticle;
    [SerializeField]
    private Animator m_ShearsAnim;

    public float fInteractRange = 3;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = FindObjectOfType<Script_MouseLook_W>().transform;
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Player");
        //m_ShearsAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Wahhh1");
            //m_ShearsAnim.Play("BrushSweepAnim");
            RaycastHit hit;
            if (Physics.Raycast(m_Camera.position, m_Camera.forward, out hit, fInteractRange, ~m_iLayerMaskIgnoreRay))
            {
                if (hit.transform.tag == "Shrub")
                {
                    //Instantiate(m_ShrubTrimParticle, hit.point, hit.transform.rotation);
                    Debug.Log("Wahhh2");
                    hit.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
        }
    }
}
