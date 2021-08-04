using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CobwebCleaning_R : MonoBehaviour
{
    [SerializeField]
    public Transform m_Camera;
    [SerializeField]
    private int m_iLayerMaskIgnoreRay;
    [SerializeField]
    private GameObject m_CobwebDestroyParticle;

    public float fInteractRange = 3;

    // Start is called before the first frame update
    void Start()
    {
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
