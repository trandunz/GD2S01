using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Mother_W : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().SetTrigger("Run");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            GetComponent<Animator>().ResetTrigger("Idle");
            GetComponent<Animator>().ResetTrigger("Run");
            GetComponent<Animator>().SetTrigger("Suspect");
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            GetComponent<Animator>().ResetTrigger("Run");
            GetComponent<Animator>().ResetTrigger("Suspect");
            GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
