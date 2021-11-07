﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Script_Player_W : MonoBehaviour
{
    public int m_iHealth;
    public List<GameObject> storedItems;
    public TMPro.TextMeshProUGUI m_InteractionText;

    [SerializeField]
    private int activeItemIndex = 0;
    private Script_CameraRefrence_W m_Camera;
    private RaycastHit InteractRay;
    private int m_iLayerMaskIgnoreRay;

    private bool m_bOnStart;

    private Script_ObjectiveManager_W m_ObjectiveManager;

    private bool m_bInCloset = false;

    Transform m_ClosetEntryPos;
    Transform m_ClosetExitPos;

    int m_CurrentlyHeldDishes = 0;
    int m_CurrentlyHeldClothes = 0;


    [SerializeField] AudioClip m_TaskCompleted;
    [SerializeField] AudioClip m_PickedUpItem;
    private void Start()
    {
        m_ObjectiveManager = GameObject.Find("ObjectiveManager").GetComponent<Script_ObjectiveManager_W>();
        m_Camera = GetComponent<Script_CameraRefrence_W>();
        m_iLayerMaskIgnoreRay = LayerMask.GetMask("Player");
        foreach (GameObject go in storedItems)
        {
            go.SetActive(false); //set every item to be inactive
        }
        storedItems[activeItemIndex].SetActive(true); //set the currently held item to be active
        m_bOnStart = true;
    }

    private void Awake()
    {
        
    }
    void Update()
    {
        if (m_bOnStart)
        {
            m_InteractionText = GameObject.Find("InteractionText").GetComponent<TMPro.TextMeshProUGUI>();
            m_bOnStart = false;
        }
        
        Debug.DrawRay(m_Camera.m_Camera.transform.localPosition, m_Camera.m_Camera.transform.forward, Color.red);
        Interact();
        InteractText();
        WeaponWheel();
        CheckIfInCloset();
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
            else if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, 3.0f, LayerMask.GetMask("Windows")))
            {
                /*if (!InteractRay.transform.GetComponentInParent<Script_Window_W>().m_bOpen)
                {

                    Debug.Log("Open Window");
                    InteractRay.transform.GetComponentInParent<Script_Window_W>().OpenWindow();
                }*/
                if (InteractRay.transform.GetComponentInParent<Script_Window_W>().m_bOpen)
                {
                    InteractRay.transform.GetComponentInParent<Script_Window_W>().CloseWindow();
                    m_ObjectiveManager.m_WNumber--;
                    if (m_ObjectiveManager.m_WNumber <= 0)
                    {
                        m_ObjectiveManager.removeTask("- Close The Windows");
                        
                    }
                }
            }
            else if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, 2.0f, LayerMask.GetMask("Tools")))
            {
                GameObject foundTool = InteractRay.transform.parent.parent.gameObject; //find the object we are looking at
                if (foundTool.GetComponent<Script_Tool>().ToolData.inPlayerPossession == false) //are we not holding it?
                {
                    foundTool.GetComponent<Script_Tool>().ToolData.inPlayerPossession = true; //we are now holding it
                    foundTool.transform.SetParent(m_Camera.m_Camera.transform); //it will follow our rotation and position
                    foundTool.GetComponent<Script_Tool>().SetFindCorrectHandPosition(); //it is now in the correct place
                    AddStoredTool(foundTool); //we can use the scroll wheel

                }

            }
            else if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, 2.0f, LayerMask.GetMask("Interactables")))
            {
                if (InteractRay.transform.gameObject.tag is "DishWasher")
                {
                    HandleDishWasher();
                }
                if (InteractRay.transform.gameObject.tag is "Dish")
                {
                    m_CurrentlyHeldDishes++;
                    Destroy(InteractRay.transform.gameObject);
                    GetComponent<AudioSource>().PlayOneShot(m_PickedUpItem);
                }
                if (InteractRay.transform.gameObject.tag is "WashingMachine")
                {
                    HandleWashingMachine();
                }
                if (InteractRay.transform.gameObject.tag is "Clothes")
                {
                    m_CurrentlyHeldClothes++;
                    Destroy(InteractRay.transform.gameObject);
                    GetComponent<AudioSource>().PlayOneShot(m_PickedUpItem);
                }
                if (InteractRay.transform.gameObject.tag is "FuseBox")
                {
                    m_ObjectiveManager.removeTask("- Turn On Power");
                    GameObject.FindGameObjectWithTag("LightManager").GetComponent<Script_LightManager>().ToggleLights();
                }
            }
            else if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, 2.0f, LayerMask.GetMask("Closet")))
            {
                m_ClosetEntryPos = InteractRay.transform.GetComponent<Script_Closet_W>().m_EntryPosition;
                m_ClosetExitPos = InteractRay.transform.GetComponent<Script_Closet_W>().m_ExitPosition;

                if (!m_bInCloset)
                {
                    m_bInCloset = !m_bInCloset;
                    transform.position = m_ClosetEntryPos.position;
                }
            }
            else if (m_bInCloset)
            {
                m_bInCloset = !m_bInCloset;
                transform.position = m_ClosetExitPos.position;
            }
        }
        
    }

   
    void InteractText()
    {
        if (Physics.Raycast(m_Camera.m_Camera.transform.position, m_Camera.m_Camera.transform.forward, out InteractRay, 2.0f, ~m_iLayerMaskIgnoreRay))
        {
            if (InteractRay.collider.tag is "Door")
            {
                /*Debug.Log("Looking At Door");*/

                if (!InteractRay.transform.GetComponentInParent<Script_Door_W>().m_bOpen)
                {
                    m_InteractionText.text = "Press [" + "E" + "] To Open";
                    var InteractBackGroundColour = m_InteractionText.transform.parent.GetComponent<Image>().color;
                    InteractBackGroundColour.a = 1.0f;
                    m_InteractionText.transform.parent.GetComponent<Image>().color = InteractBackGroundColour;
                }
                
            }
            else if (InteractRay.collider.tag is "Window")
            {
                /*Debug.Log("Looking At Window");*/

                /*if (!InteractRay.transform.GetComponentInParent<Script_Window_W>().m_bOpen)
                {
                    m_InteractionText.text = "Press [" + "E" + "] To Open";
                    var InteractBackGroundColour = m_InteractionText.transform.parent.GetComponent<Image>().color;
                    InteractBackGroundColour.a = 1.0f;
                    m_InteractionText.transform.parent.GetComponent<Image>().color = InteractBackGroundColour;
                }*/
                if(InteractRay.transform.GetComponentInParent<Script_Window_W>().m_bOpen)
                {
                    m_InteractionText.text = "Press [" + "E" + "] To Close";
                    var InteractBackGroundColour = m_InteractionText.transform.parent.GetComponent<Image>().color;
                    InteractBackGroundColour.a = 1.0f;
                    m_InteractionText.transform.parent.GetComponent<Image>().color = InteractBackGroundColour;
                }

            }

        }

        else
        {
            m_InteractionText.text = null;
            var InteractBackGroundColour = m_InteractionText.transform.parent.GetComponent<Image>().color;
            InteractBackGroundColour.a = 0.0f;
            m_InteractionText.transform.parent.GetComponent<Image>().color = InteractBackGroundColour;
        }
    }

    void AddStoredTool(GameObject theTool)
    {
        storedItems.Add(theTool);
        theTool.SetActive(false);
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

    void CheckIfInCloset()
    {
        if (m_bInCloset)
        {
            GetComponent<CharacterController>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (GetComponent<CharacterController>().enabled == false)
        {
            GetComponent<CharacterController>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void HandleDishWasher()
    {
        while (m_CurrentlyHeldDishes > 0)
        {
            InteractRay.transform.GetComponent<Script_Dishwasher>().AddDish();
            m_CurrentlyHeldDishes--;
            Debug.Log("Player Put Dish In Dishwasher!");
            if (m_ObjectiveManager.m_DishNumber <= 0)
            {
                m_ObjectiveManager.removeTask("- Clean Up Dishes");
            }
        }
    }

    void HandleWashingMachine()
    {
        while (m_CurrentlyHeldClothes > 0)
        {
            InteractRay.transform.GetComponent<Script_WashingMachine>().AddClothes();
            m_CurrentlyHeldClothes--;
            Debug.Log("Clothes are in the washing machine now");
            if (m_ObjectiveManager.m_clothesNumber <= 0)
            {
                m_ObjectiveManager.removeTask("- Wash Clothes");
            }
        }
    }
}
