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
    // Start is called before the first frame update
    void Start()
    {
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
        Startb.gameObject.SetActive(!Startb.gameObject.active);
        Continue.gameObject.SetActive(!Continue.gameObject.active);
        Options.gameObject.SetActive(!Options.gameObject.active);
        Exit.gameObject.SetActive(!Exit.gameObject.active);
        Title.gameObject.SetActive(!Title.gameObject.active);
    }

    public void SetInteractable(bool _truth)
    {
        apply.interactable = _truth;
    }

    public void SetAudio()
    {
        AudioListener.volume = m_Audio.value;
    }

    public void SetSens(Script_MouseLook_W _mouselook)
    {
        _mouselook.m_fSensitivity = MouseSens.value;
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
            Screen.SetResolution(1920, 1080, true);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
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
            Screen.SetResolution(1920, 1080, false);
        }
        else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
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
                Screen.SetResolution(1920, 1080, true);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
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
                Screen.SetResolution(1920, 1080, false);
            }
            else if (GetComponentInChildren<TMPro.TMP_Dropdown>().value == 2)
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
