using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Script_Door_W : MonoBehaviour
{
    public bool m_IsStairWell;
    public GameObject m_Hinge;
    public AnimationCurve DoorCurve= AnimationCurve.EaseInOut(0.0f,0.0f,1.0f,1.0f);
    public float m_RotationY;

    public float TimeToOpen;
    public bool m_bOpen;
    public bool m_isLocked;
    private Vector3 ClosedPosition;

    
    public float m_OpenValue;

    private float m_PrevCastNormZ;

    void Start()
    {
        m_bOpen = false;
    }

    private void Update()
    {
       
        
    }



    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Left");
        if ((other.gameObject.tag is "Player"))
        {
            if (m_bOpen)
            {
                if (m_IsStairWell)
                {
                    m_isLocked = true;
                    CloseDoor();
                    /*StartCoroutine(TurnPlayerToDoor(other));*/
                }
                else
                {
                    CloseDoor();
                    /*StartCoroutine(TurnPlayerToDoor(other));*/
                }
                
            }
            
        }
    }

    IEnumerator TurnPlayerToDoor(Collider _player)
    {
        _player.GetComponentInParent<Script_CameraRefrence_W>().m_Camera.m_bIsFree = false;
        _player.GetComponentInParent<Script_CharacterMotor_W>().m_bCanMove = false;
        bool LookAtDoor = true;
        if (LookAtDoor)
        {
            _player.GetComponentInParent<Script_CameraRefrence_W>().m_Camera.transform.LookAt(FindTransformInChild(this.gameObject).position);
            /*Quaternion lookOnLook = Quaternion.LookRotation(FindTransformInChild(this.gameObject).position - _player.GetComponentInParent<Script_CameraRefrence_W>().m_Camera.transform.position);
            _player.GetComponentInParent<Script_CameraRefrence_W>().m_Camera.transform.rotation = Quaternion.Slerp(_player.GetComponentInParent<Script_CameraRefrence_W>().m_Camera.transform.rotation, lookOnLook, Time.deltaTime);*/
        }
        
        yield return new WaitForSeconds(1.2f);
        LookAtDoor = false;
        _player.GetComponentInParent<Script_CameraRefrence_W>().m_Camera.m_bIsFree = true;
        _player.GetComponentInParent<Script_CharacterMotor_W>().m_bCanMove = true;
    }

    public void CloseDoor()
    {
        if (m_bOpen)
        {
            if (m_PrevCastNormZ > 0.0f)
            {
                m_PrevCastNormZ = 0.0f;
                GetComponentInChildren<Animator>().SetBool("Close90", true);
                /*Vector3 rotationVector = new Vector3(0, 90.0f, 0);
                m_Hinge.transform.rotation = Quaternion.Euler(rotationVector);*/

            }
            else if (m_PrevCastNormZ < 0.0f)
            {
                m_PrevCastNormZ = 0.0f;
                GetComponentInChildren<Animator>().SetBool("Close", true);
                /*Vector3 rotationVector = new Vector3(0, -90.0f, 0);
                m_Hinge.transform.rotation = Quaternion.Euler(rotationVector);*/

            }
            m_PrevCastNormZ = 0.0f;
        }
            
        
    }

    public void OpenDoor(RaycastHit RayCast)
    {
        if (!m_bOpen && !m_isLocked)
        {
            m_PrevCastNormZ = RayCast.normal.z;
            if (RayCast.normal.z > 0.0f)
            {
                GetComponentInChildren<Animator>().SetBool("Open90", true);
                /*Vector3 rotationVector = new Vector3(0, 90.0f, 0);
                m_Hinge.transform.rotation = Quaternion.Euler(rotationVector);*/

            }
            else if (RayCast.normal.z < 0.0f)
            {
                GetComponentInChildren<Animator>().SetBool("Open", true);
                /*Vector3 rotationVector = new Vector3(0, -90.0f, 0);
                m_Hinge.transform.rotation = Quaternion.Euler(rotationVector);*/

            }
        }
        
        
    }

    public Transform FindTransformInChild(GameObject parent)            // Credit Is Due https://answers.unity.com/questions/893966/how-to-find-child-with-tag.html
    {
        Transform[] list = parent.GetComponentsInChildren<Transform>();
        foreach (Transform t in list)
        {
            if (t.tag is "LookPosition")
            {
                return t;
            }
        }
        return null;
    }
}
