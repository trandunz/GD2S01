using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Door : MonoBehaviour
{
    public AnimationCurve DoorCurve;
    float TimeToOpen;
    public bool m_bOpen;
    public bool m_isLocked;
    private Vector3 ClosedPosition;

    void Start()
    {
        ClosedPosition = transform.position;
        m_bOpen = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag is "Player" && !m_isLocked)
        {
            if (m_bOpen)
            {
                Debug.Log("Close Door!)");
                GetComponentInChildren<Animator>().SetBool("Open", false);
                GetComponentInChildren<Animator>().SetBool("Close", true);
            }
            
        }

    }
}
