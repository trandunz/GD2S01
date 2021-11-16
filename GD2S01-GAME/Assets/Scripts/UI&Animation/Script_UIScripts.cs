using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Script_UIScripts : MonoBehaviour
{
    public Slider m_Audio;
    public Button apply;
    public Slider MouseSens;
    public bool m_bMute;
    public bool m_bIsInGame;

    public Button Startb;
    public Button Continue;
    public Button Options;
    public Button Exit;
    public TMPro.TextMeshProUGUI Title;

    public GameObject m_OptionsMenu;
    public GameObject m_Inventory;
    public GameObject m_TaskCompletedUI;
    public GameObject m_InteractText;

    // Start is called before the first frame update
    void Start()
    {
        SetGameInactive();
        m_Audio.value = AudioListener.volume;
        m_Audio.value = AudioListener.volume;
        apply.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetAllActive()
    {
        Startb.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
        m_Inventory.gameObject.SetActive(true);
        m_OptionsMenu.gameObject.SetActive(false);
        m_InteractText.SetActive(true);
        m_bIsInGame = true;
    }

    public void ToggleInGameUID()
    {
        Startb.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
        Options.gameObject.SetActive(!m_Inventory.gameObject.activeSelf);
        Exit.gameObject.SetActive(!m_Inventory.gameObject.activeSelf);
        Title.gameObject.SetActive(!m_Inventory.gameObject.activeSelf);
        m_Inventory.gameObject.SetActive(!m_Inventory.gameObject.activeSelf);
        m_OptionsMenu.gameObject.SetActive(false);
    }

    public void SetGameInactive()
    {
        Startb.gameObject.SetActive(true);
        Continue.gameObject.SetActive(true);
        Options.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
        m_Inventory.gameObject.SetActive(false);
        m_OptionsMenu.gameObject.SetActive(false);
        m_InteractText.SetActive(false);
        m_bIsInGame = false;
    }

    public void SetAllInactiveInventory()
    {
        Startb.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
        Options.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        m_Inventory.gameObject.SetActive(false);
        m_OptionsMenu.gameObject.SetActive(false);
        m_InteractText.SetActive(false);
    }

    public void SetInteractable(bool _truth)
    {
        apply.interactable = _truth;
    }

    public void SetAudio()
    {
        AudioListener.volume = m_Audio.value;
    }

    public void SetSens()
    {
        if (GameObject.FindObjectOfType<Script_MouseLook_W>())
        {
            GameObject.FindObjectOfType<Script_MouseLook_W>().m_fSensitivity = MouseSens.value;
        }
    }


    public void Fullscreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 0)
        {
            Screen.SetResolution(1280, 720, true);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 1)
        {
            Screen.SetResolution(1366, 768, true);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 3)
        {
            Screen.SetResolution(2560, 1440, true);
        }
    }

    public void Windowed()
    {
        
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
        if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 0)
        {
            Screen.SetResolution(1280, 720, false);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 1)
        {
            Screen.SetResolution(1366, 768, false);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 3)
        {
            Screen.SetResolution(2560, 1440, false);
        }
    }

    public void ApplyChanges()
    {
        if (Screen.fullScreen == true)
        {
            if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 0)
            {
                Screen.SetResolution(1280, 720, true);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 1)
            {
                Screen.SetResolution(1366, 768, true);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 3)
            {
                Screen.SetResolution(2560, 1440, true);
            }
        }
        else
        {
            if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 0)
            {
                Screen.SetResolution(1280, 720, false);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 1)
            {
                Screen.SetResolution(1366, 768, false);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
            {
                Screen.SetResolution(1920, 1080, false);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 3)
            {
                Screen.SetResolution(2560, 1440, false);
            }
        }

        SetInteractable(false);
    }

    public void Mute()
    {
        AudioListener.volume = 0.0f;
    }

    public void UnMute()
    {
        AudioListener.volume = 1.0f;
    }
}
