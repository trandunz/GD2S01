using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tool : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Camera;
    private int m_iLayerMaskIgnoreRay;
    private Animator m_brushAnim;
    private Script_ObjectiveManager_W m_ObjectiveManager;

    public ScriptableObject_Tool_W ToolData;
    public ParticleSystem m_NonInstantiatedParticle;
    public enum TOOLTYPE
    {
        COBWEBBRUSH,
        DUSTER,
        VACUUM,
        DEFAULT
    }

    public TOOLTYPE m_ToolType;
    

    // Start is called before the first frame update
    void Start()
    {
        m_ObjectiveManager = GameObject.Find("ObjectiveManager").GetComponent<Script_ObjectiveManager_W>();
        m_Camera = GetComponentInParent<Script_CameraRefrence_W>().m_Camera.gameObject;
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Player") + LayerMask.GetMask("Default") + LayerMask.GetMask("Windows") + LayerMask.GetMask("Doors") + LayerMask.GetMask("UI");
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
                                m_ObjectiveManager.m_CWNumber--;
                                if (m_ObjectiveManager.m_CWNumber <= 0)
                                {
                                    m_ObjectiveManager.removeTask("- Clean Up Cobwebs");
                                }

                            }
                        }
                        break;
                    }
                case TOOLTYPE.DUSTER:
                    {
                        break;
                    }

                case TOOLTYPE.VACUUM:
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, ToolData.fInteractRange, ~m_iLayerMaskIgnoreRay))
                        {
                            if (hit.transform.tag == "Cobweb")
                            {
                                Destroy(Instantiate(ToolData.m_ParticleSystem, hit.point, hit.transform.rotation), 2);
                                Destroy(hit.transform.gameObject);
                                m_ObjectiveManager.m_CWNumber--;
                                if (m_ObjectiveManager.m_CWNumber <= 0)
                                {
                                    m_ObjectiveManager.removeTask("- Clean Up Cobwebs");
                                }

                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }

        /*if (Input.GetMouseButton(0))
        {
            switch (m_ToolType)
            {
                case TOOLTYPE.COBWEBBRUSH:
                    {
                        break;
                    }
                case TOOLTYPE.DUSTER:
                    {
                        break;
                    }

                case TOOLTYPE.VACUUM:
                    {
                        m_NonInstantiatedParticle.Play();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
        else
        {
            if (m_ToolType == TOOLTYPE.VACUUM)
            {
                m_NonInstantiatedParticle.Pause();
            }
            
        }*/
    }

    /*public void OnCollisionEnter(Collision collisionInfo)
    {
        // We check if the object we collided with has a tag called "Obstacle".
        if (collisionInfo.collider.tag == "VacuumPart")
        {
            Destroy(collisionInfo.gameObject);

        }
    }*/
}
