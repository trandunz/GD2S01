using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_W : MonoBehaviour
{
    enum STATE
    {
        IDLE,
        WANDER,
        RUN,
        ATTACK,
    }

    STATE m_AiState = STATE.IDLE;

    private void Start()
    {
        
    }
}
