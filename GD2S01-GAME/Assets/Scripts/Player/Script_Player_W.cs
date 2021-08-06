using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_Player_W : MonoBehaviour
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
        Debug.DrawRay(m_Camera.m_Camera.transform.localPosition, m_Camera.m_Camera.transform.forward, Color.red);
        Interact();
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, 2.0f, LayerMask.GetMask("Doors")))
            {
                if (!InteractRay.transform.GetComponentInParent<Script_Door_W>().m_bOpen)
                {
                    
                    Debug.Log("Open Door");
                    InteractRay.transform.GetComponentInParent<Script_Door_W>().OpenDoor(InteractRay);
                    /*InteractRay.transform.GetComponentInParent<Animator>().SetBool("Open", true);*/
                }
            }
            else if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, 2.0f, LayerMask.GetMask("Windows")))
            {
                if (!InteractRay.transform.GetComponentInParent<Script_Window_W>().m_bOpen)
                {

                    Debug.Log("Open Door");
                    InteractRay.transform.GetComponentInParent<Script_Window_W>().OpenWindow();
                    /*InteractRay.transform.GetComponentInParent<Animator>().SetBool("Open", true);*/
                }
                else if (InteractRay.transform.GetComponentInParent<Script_Window_W>().m_bOpen)
                {
                    InteractRay.transform.GetComponentInParent<Script_Window_W>().CloseWindow();
                }
            }
        }
        
    }
}
