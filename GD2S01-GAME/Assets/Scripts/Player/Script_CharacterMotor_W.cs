using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CharacterMotor_W : Script_Player_W
{
    public CharacterController m_Controller;
    public Script_MouseLook_W m_Look;
    public GameObject m_Body;
    public Animator m_Animator;
    private GameObject m_OptionsCanvas;

    public float m_fSprintSpeed = 25.0f;
    public float m_fCreepSpeed = 5.0f;
    public float m_fMaxMoveSpeed;
    public bool m_bWalking;
    public bool m_bCanMove = true;
    private float m_MoveSpeed = 6.0f;
    public float m_Gravity = 40.0f;
    public float m_JumpSpeed = 12.0f;
    public float m_GroundedLenience = 0.25f;
    public float m_Acceleration = 8.0f;
    public AnimationCurve m_FrictionCurve;
    public float m_AirMomentumMultiplier = 0.0f;

    [SerializeField] private Vector3 m_Velocity = Vector3.zero;
    [SerializeField] private Vector3 m_TrueVelocity = Vector3.zero;
    [SerializeField] private bool m_bGrounded = false;
    public float m_GroundedTimer = 0.0f;
    [SerializeField] private float m_fDistanceTravelled = 0.0f;

    public Transform m_FeetPosition;
    public GameObject[] m_FootstepSounds;
    public float m_FootstepLength = 0.5f;

    public float m_JumpFootstepTimer = 0.0f;
    public float m_JumpFootstepCooldown = 0.5f;

    private bool m_bRightFoot = true;

    void Start()
    {
        m_OptionsCanvas = GameObject.FindGameObjectWithTag("Canvas");
        m_MoveSpeed = m_fMaxMoveSpeed;
        m_Look.m_bIsFree = false;
        m_bCanMove = false;
        m_OptionsCanvas.GetComponentInParent<Script_UIScripts>().SetAllActive();
    }

    private void SpawnFootstep()
    {
        if (m_FootstepSounds.Length > 0)
        {
            m_bRightFoot = !m_bRightFoot;
            Vector3 footOffset = new Vector3(m_bRightFoot ? 1.0f : -1.0f, 0.0f, 0.0f) * 0.25f;
            footOffset = Quaternion.Euler(0.0f, m_Look.m_fSpin, 0.0f) * footOffset;
            Debug.Log("Spawned footstep");
            Destroy(Instantiate(m_FootstepSounds[Random.Range(0, m_FootstepSounds.Length)], m_FeetPosition.position + footOffset, m_FeetPosition.rotation), 1.0f);
        }
    }

    void Update()
    {
        
        Vector3 eulerAngles = m_Look.transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        m_Body.transform.rotation = Quaternion.Euler(eulerAngles);
        if (Input.GetKey(KeyCode.LeftShift))
        {

            m_MoveSpeed = m_fSprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_MoveSpeed = m_fMaxMoveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {

            m_MoveSpeed = m_fCreepSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            m_MoveSpeed = m_fMaxMoveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            m_OptionsCanvas.GetComponentInParent<Script_UIScripts>().SetAllActive();
            m_Look.m_bIsFree = !m_Look.m_bIsFree;
            m_bCanMove = !m_bCanMove;
        }

        float z = 0.0f;
        float x = 0.0f;
        

        if (m_bCanMove)
        {
            x -= Input.GetKey(KeyCode.A) ? 1.0f : 0.0f;
            x += Input.GetKey(KeyCode.D) ? 1.0f : 0.0f;

            z -= Input.GetKey(KeyCode.S) ? 1.0f : 0.0f;
            z += Input.GetKey(KeyCode.W) ? 1.0f : 0.0f;

            if (Input.GetKeyDown(KeyCode.Space) && m_bGrounded)
            {
                m_Velocity.y = m_JumpSpeed;
                m_GroundedTimer = 0.0f;
                m_bGrounded = false;
                /*GetComponentInChildren<Animator>().SetBool("IsJumping", true);*/
            }
        }

       

        Vector3 inputMoveXZ = new Vector3(x, 0.0f, z);
        /*Vector3 inputMoveForward = new Vector3(m_Velocity.x, 0.0f, m_Velocity.z);
        inputMoveForward = Vector3.forward;

        inputMoveForward = Quaternion.Euler(0.0f, m_Look.m_fSpin, 0.0f) * Vector3.forward * m_Velocity.normalized.magnitude;*/
        inputMoveXZ = Quaternion.Euler(0.0f, m_Look.m_fSpin, 0.0f) * inputMoveXZ;

        if (inputMoveXZ.magnitude > 1.0f)
        {
            inputMoveXZ.Normalize();
        }

        float cacheY = m_Velocity.y;
        m_Velocity.y = 0.0f;

        float mag = m_Velocity.magnitude;

        float airMod = m_bGrounded ? 1.0f : m_AirMomentumMultiplier;
        if (m_bGrounded)
        {
            m_Velocity += inputMoveXZ * m_Acceleration * Time.deltaTime * airMod;
        }
        else
        {
            m_Velocity += inputMoveXZ * m_Acceleration * Time.deltaTime * airMod;
        }

        if (m_bGrounded)
        {
            m_Velocity -= m_Velocity.normalized * m_Acceleration * m_FrictionCurve.Evaluate(mag) * Time.deltaTime * airMod;
        }
        else
        {
            m_Velocity -= m_Velocity.normalized * m_FrictionCurve.Evaluate(mag) * Time.deltaTime * airMod * m_Acceleration * 0.95f;
        }

        m_Velocity.y = cacheY;
        m_Velocity.y -= m_Gravity * Time.deltaTime;

        m_TrueVelocity = m_Velocity;
        m_TrueVelocity.x *= m_MoveSpeed;
        m_TrueVelocity.z *= m_MoveSpeed;

        m_Controller.Move(m_TrueVelocity * Time.deltaTime);
        Vector3 footstepMove = m_TrueVelocity*Time.deltaTime;

        m_JumpFootstepTimer -= Time.deltaTime;
        m_GroundedTimer -= Time.deltaTime;

        if ((m_Controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            if (!m_bGrounded && m_JumpFootstepTimer < 0.0f)
            {
                m_JumpFootstepTimer = m_JumpFootstepCooldown;
                m_fDistanceTravelled = 0.0f;
                SpawnFootstep();
            }

            m_Velocity.y = -1.0f;
            m_GroundedTimer = m_GroundedLenience;
            m_bGrounded = true;
        }
        else
        {
            m_bGrounded = false;
        }

        if (m_bGrounded)
        {
            footstepMove.y = 0;
            m_fDistanceTravelled += footstepMove.magnitude;
            if (m_fDistanceTravelled > m_FootstepLength)
            {
                m_fDistanceTravelled -= m_FootstepLength;
                SpawnFootstep();
            }
        }

        if (m_Velocity.z > 0.01 || m_Velocity.z < -0.01 || m_Velocity.x > 0.01 || m_Velocity.x < -0.01)
        {
            m_bWalking = true;
            
        }
        else
        {
            m_bWalking = false;
            
        }

        float XZMove = Mathf.Abs(z) + Mathf.Abs(x);

        m_Animator.SetFloat("SpeedXZ", XZMove);
        m_Animator.SetFloat("SpeedX", x);
        m_Animator.SetFloat("SpeedZ", z);
    }
}
