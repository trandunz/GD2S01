using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_Player_R : MonoBehaviour
{
    public int m_iHealth;

    private Script_CameraRefrence_W m_Camera;
    private RaycastHit InteractRay;
    public float fInteractRange = 3;

    public List<GameObject> storedItems;
    [SerializeField]
    private int activeItemIndex = 0;

    private void Start()
    {
        m_Camera = GetComponent<Script_CameraRefrence_W>();

        foreach (GameObject go in storedItems)
        {
            go.SetActive(false); //set every item to be inactive
        }
        storedItems[activeItemIndex].SetActive(true); //set the currently held item to be active
    }

    void Update()
    {
        Debug.DrawRay(m_Camera.m_Camera.transform.localPosition, m_Camera.m_Camera.transform.forward, Color.red);
        Interact();
        WeaponWheel();
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, fInteractRange, LayerMask.GetMask("Doors")))
            {
                if (!InteractRay.transform.GetComponentInParent<Script_Door_W>().m_bOpen)
                {
                    
                    Debug.Log("Open Door");
                    InteractRay.transform.GetComponentInParent<Script_Door_W>().OpenDoor(InteractRay);
                    /*InteractRay.transform.GetComponentInParent<Animator>().SetBool("Open", true);*/
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetActiveWeapon().Use(fInteractRange);
        }

    }

    void WeaponWheel()
    {
        float scrl = Input.mouseScrollDelta.y; //get scroll wheel input
        if (scrl != 0)
        {
            storedItems[activeItemIndex].SetActive(false);
            activeItemIndex += (int)scrl;
            if (activeItemIndex < 0) //too low
                activeItemIndex = storedItems.Count - 1;
            if (activeItemIndex > storedItems.Count - 1) //too high
                activeItemIndex = 0;

            storedItems[activeItemIndex].SetActive(true);
        }
    }

    Script_Weapon_R GetActiveWeapon()
    {
        return storedItems[activeItemIndex].GetComponent<Script_Weapon_R>();
    }

}
