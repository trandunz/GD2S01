using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Room_Swap_Trigger_J : MonoBehaviour
{
    [SerializeField] Room_Swap_J m_RoomSwap;
    [SerializeField] int m_iRoomSwapTimes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < m_iRoomSwapTimes; i++)
            {
                m_RoomSwap.RoomSwap();
            }
        }
    }
}
