using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public int m_iHealth;

    private Script_CameraRefrence_W m_Camera;
    private RaycastHit InteractRay;
    private void Start()
    {
        m_Camera = GetComponent<Script_CameraRefrence_W>();
    }

    void Update()
    {
        Interact();
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(m_Camera.gameObject.transform.position, m_Camera.gameObject.transform.forward, out InteractRay, 2.0f, LayerMask.GetMask("Doors")))
            {
                if (!InteractRay.transform.GetComponentInParent<Script_Door>().m_bOpen)
                {
                    Debug.Log("Open Door");
                    InteractRay.transform.GetComponentInParent<Animator>().SetBool("Open", true);
                }
            }
        }
        
    }
}
