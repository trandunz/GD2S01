using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Exorcist_W : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().SetTrigger("Walk");
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().ResetTrigger("Walk");
            GetComponent<Animator>().SetTrigger("Suspect");
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().ResetTrigger("Walk");
            GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
