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

    [Header("Window Cleaning")]
    public ParticleSystem m_SprayBottleParticles;
    public Transform m_SprayOrigin;
    public Transform m_RagTransform;
    public Transform m_InvisibleHandPos;
    public float m_RagMoveAmount;
    public AudioSource m_Spray;
    public AudioSource m_Wipe;

    public enum TOOLTYPE
    {
        COBWEBBRUSH,
        DUSTER,
        VACUUM,
        WINDOWCLEAN,
        DEFAULT
    }

    public TOOLTYPE m_ToolType;
    

    // Start is called before the first frame update
    void Start()
    {
        Setup();
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
                        GetComponent<AudioSource>().Play();
                        CleanCobweb();
                        break;
                    }
                case TOOLTYPE.DUSTER:
                    {
                        break;
                    }

                case TOOLTYPE.VACUUM:
                    {
                        CleanCobweb();
                        break;
                    }
                case TOOLTYPE.WINDOWCLEAN:
                    {
                        m_SprayBottleParticles.Play();
                        m_Spray.Play();
                        WetWindow();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }

        if (Input.GetMouseButton(1))
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
                        break;
                    }
                case TOOLTYPE.WINDOWCLEAN:
                    {
                        if (!GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Rag_Animation"))
                        {
                            GetComponentInChildren<Animator>().SetTrigger("RagWipe");
                        }
                        if (!m_Wipe.isPlaying)
                        {
                            CleanTheWindow();
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
        if (Input.GetMouseButtonUp(1))
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
                        break;
                    }
                case TOOLTYPE.WINDOWCLEAN:
                    {
                        GetComponentInChildren<Animator>().ResetTrigger("RagWipe");
                        GetComponentInChildren<Animator>().SetTrigger("ReturnToIdle");
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

    private void Setup()
    {
        m_ObjectiveManager = GameObject.Find("ObjectiveManager").GetComponent<Script_ObjectiveManager_W>();
        m_Camera = GetComponentInParent<Script_CameraRefrence_W>().m_Camera.gameObject;
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Player") + LayerMask.GetMask("Default") + LayerMask.GetMask("Windows") + LayerMask.GetMask("Doors") + LayerMask.GetMask("UI");
        m_brushAnim = GetComponentInChildren<Animator>();
        if (ToolData.UseSound != null && GetComponent<AudioSource>() != null) //if tool doesnt have sound, it wont break
            GetComponent<AudioSource>().clip = ToolData.UseSound;
    }

    public void SetFindCorrectHandPosition()
    {
        switch (m_ToolType)
        {
            case TOOLTYPE.COBWEBBRUSH:
                {
                    Transform posRot = GameObject.Find("CobwebBrushPosition").transform; //find the desired position/rotation
                    transform.localPosition = posRot.localPosition; //set LOCAL position and rotation
                    transform.localRotation = posRot.localRotation;
                    break;
                }
            case TOOLTYPE.DUSTER:
                {
                    break;
                }

            case TOOLTYPE.VACUUM:
                {
                    break;
                }
            case TOOLTYPE.WINDOWCLEAN:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }

        Setup(); //make sure everything is connected and found
    }

    private void CleanCobweb()
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
    }

    private void CleanTheWindow()
    {
        RaycastHit hit;
        if(Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, ToolData.fInteractRange, LayerMask.GetMask("Windows")))
        {
            if(hit.transform.GetComponentInParent<Script_Window_W>().CleanWindow())
            {
                 m_Wipe.Play();
            }

            //m_ObjectiveManager.m_CWNumber--;
            //if (m_ObjectiveManager.m_CWNumber <= 0)
            //{
            //    m_ObjectiveManager.removeTask("- Windows");
            //}
        }
    }

    private void WetWindow()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, ToolData.fInteractRange, LayerMask.GetMask("Windows")))
        {
            hit.transform.GetComponentInParent<Script_Window_W>().WetWindow();
        }
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
