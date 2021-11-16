using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Script_BUIExitB_W : MonoBehaviour
{
    public void QuitToMainMenu()
    {
        if (GetComponentInParent<Script_UIScripts>().m_bIsInGame)
        {
            GetComponentInParent<Script_UIScripts>().SetGameInactive();
            SceneManager.LoadScene("MainMenu_W");
        }
    }

    public void QuitGame()
    {
        if (!GetComponentInParent<Script_UIScripts>().m_bIsInGame)
        {
            GameObject.FindObjectOfType<Script_MenuAnimation_W>().PlayExitAnim();
            GetComponentInParent<Script_UIScripts>().SetAllInactiveInventory();
        }
    }
}
