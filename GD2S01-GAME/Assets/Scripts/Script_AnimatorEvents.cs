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

    void Open()
    {
        GetComponentInParent<Script_Door>().m_bOpen = true;
        GetComponent<AudioSource>().clip = (DoorClips[0]);
        GetComponent<AudioSource>().
        GetComponent<AudioSource>().Play();
    }

    void Close()
    {
        GetComponentInParent<Script_Door>().m_bOpen = false;
        GetComponent<AudioSource>().clip = (DoorClips[1]);
        GetComponent<AudioSource>().Play();
    }

    void RotateDoor()
    {
        GetComponentInParent<Script_Door>().gameObject.transform.rotation = new Quaternion(GetComponentInParent<Script_Door>().gameObject.transform.rotation.x, GetComponentInParent<Script_Door>().gameObject.transform.rotation.y + 180, GetComponentInParent<Script_Door>().gameObject.transform.rotation.z, 1.0f);
             
    }
}
