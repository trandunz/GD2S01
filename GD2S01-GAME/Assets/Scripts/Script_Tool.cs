using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tool : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Camera;
    private int m_iLayerMaskIgnoreRay;
    private Animator m_brushAnim;

    public ScriptableObject_Tool_W ToolData;
    public enum TOOLTYPE
    {
        COBWEBBRUSH,
        DUSTER,
        DEFAULT
    }

    public TOOLTYPE m_ToolType;
    

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GetComponentInParent<Script_CameraRefrence_W>().m_Camera.gameObject;
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Player");
        m_brushAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch(m_ToolType)
            {
                case TOOLTYPE.COBWEBBRUSH:
                    {
                        m_brushAnim.Play("UseWeapon");
                        RaycastHit hit;
                        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, ToolData.fInteractRange, ~m_iLayerMaskIgnoreRay))
                        {
                            if (hit.transform.tag == "Cobweb")
                            {
                                Destroy(Instantiate(ToolData.m_ParticleSystem, hit.point, hit.transform.rotation), 2);
                                Destroy(hit.transform.gameObject);
                            }
                        }
                        break;
                    }
                case TOOLTYPE.DUSTER:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }
    }
}
