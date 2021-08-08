using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_MenuAnimation_W : MonoBehaviour
{
    public Button Startb;
    public Button Continue;
    public Button Options;
    public Button Exit;
    public TMPro.TextMeshProUGUI Title;

    public GameObject m_OptionsMenu;
    public GameObject m_InteractionText;

    public GameObject m_Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
        m_OptionsMenu.gameObject.SetActive(true);
        m_OptionsMenu.GetComponentInParent<Script_UIScripts>().m_bIsInGame = false;
        m_OptionsMenu.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayExitAnim()
    {
        GetComponent<Animator>().SetTrigger("ExitGame");
        Startb.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
        Options.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
    }

    public void PlayStartAnim()
    {
        GetComponent<Animator>().SetTrigger("CameraIn");
        Startb.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
        Options.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }

    public void LoadNextScene()
    {
        m_OptionsMenu.gameObject.SetActive(true);
        m_OptionsMenu.GetComponentInParent<Script_UIScripts>().m_bIsInGame = true;
        m_OptionsMenu.gameObject.SetActive(false);
        DontDestroyOnLoad(m_Canvas);
        m_InteractionText.SetActive(true);
        SceneManager.LoadScene("Scene_W");
    }
}
