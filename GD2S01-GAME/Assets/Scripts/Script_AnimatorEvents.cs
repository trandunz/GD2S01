using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AnimatorEvents : MonoBehaviour
{
    public AudioClip[] DoorClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnLanding()
    {
        GetComponent<Animator>().SetBool("IsJumping", false);
    }

    public void Open()
    {
        GetComponentInChildren<Animator>().SetBool("Open", false);
        GetComponentInParent<Script_Door_W>().m_bOpen = true;
        GetComponent<AudioSource>().clip = (DoorClips[0]);
        GetComponent<AudioSource>().
        GetComponent<AudioSource>().Play();
    }

    public void Close()
    {
        GetComponentInChildren<Animator>().SetBool("Close", false);
        GetComponentInParent<Script_Door_W>().m_bOpen = false;
        GetComponent<AudioSource>().clip = (DoorClips[1]);
        GetComponent<AudioSource>().Play();
    }

    public void Close90()
    {
        GetComponentInChildren<Animator>().SetBool("Close90", false);
        GetComponentInParent<Script_Door_W>().m_bOpen = false;
        GetComponent<AudioSource>().clip = (DoorClips[1]);
        GetComponent<AudioSource>().Play();
    }

    public void Open90()
    {
        GetComponentInChildren<Animator>().SetBool("Open90", false);
        GetComponentInParent<Script_Door_W>().m_bOpen = true;
        GetComponent<AudioSource>().clip = (DoorClips[0]);
        GetComponent<AudioSource>().Play();
    }
}
