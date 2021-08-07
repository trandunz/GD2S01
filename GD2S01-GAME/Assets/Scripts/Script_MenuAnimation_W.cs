using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_MenuAnimation_W : MonoBehaviour
{
    public Button Startb;
    public Button Continue;
    public Button Options;
    public Button Exit;
    public TMPro.TextMeshProUGUI Title;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
