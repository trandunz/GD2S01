using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MouseLook_W : MonoBehaviour
{
    public float m_fSpin;
    public float m_fTilt;
    public bool m_bIsFree;

    public Vector2 m_TiltExtents = new Vector2(-85.0f, 85.0f);

    public float m_fSensitivity = 2.0f;

    public bool m_bCursorLocked = true;

    private void Start()
    {
        m_bIsFree = true;
        m_bCursorLocked = false;
        /*LockCursor();*/
    }

    private void LockCursor()
    {
        Cursor.visible = !m_bCursorLocked;
        Cursor.lockState = m_bCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            m_bCursorLocked = !m_bCursorLocked;
            LockCursor();
        }

        if (!m_bCursorLocked)
        {
            LockCursor();
            return;
        }

        
        
        if (m_bIsFree)
        {
            float x = Input.GetAxisRaw("Mouse X");
            float y = Input.GetAxisRaw("Mouse Y");

            m_fSpin += x * m_fSensitivity;
            m_fTilt -= y * m_fSensitivity;

            m_fTilt = Mathf.Clamp(m_fTilt, m_TiltExtents.x, m_TiltExtents.y);

            transform.localEulerAngles = new Vector3(m_fTilt, m_fSpin, 0.0f);

        }
        
    }
}
