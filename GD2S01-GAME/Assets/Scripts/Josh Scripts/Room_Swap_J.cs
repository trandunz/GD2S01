using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Swap_J : MonoBehaviour
{
    // Array that contains all Rooms
    [SerializeField] Room_Variables_J[] m_Rooms;
    // The Number of Rooms in the Array
    [SerializeField] int m_iRoomCount;

    // Start is called before the first frame update
    void Start()
    {
        m_iRoomCount = m_Rooms.Length;
        m_iRoomCount++;
    }

    public void RoomSwap()
    {
        int iAvailavbletoSwap = 0;
        for (int i = 0; i < m_iRoomCount; i++)
        {
            if (m_Rooms[i].m_CanMove)
            {
                iAvailavbletoSwap++;
            }
            if (iAvailavbletoSwap == 2)
            {
                i = m_iRoomCount;
            }
        }
        // Randomize which 2 Rooms will swap
       if (iAvailavbletoSwap >= 2)
        {
            int itemp = Random.Range(1, m_iRoomCount);
            itemp -= 1;
            while (m_Rooms[itemp].m_CanMove == false)
            {
                itemp = Random.Range(1, m_iRoomCount);
                itemp -= 1;
            }

            int itemp2 = Random.Range(1, m_iRoomCount);
            itemp2 -= 1;
            while (m_Rooms[itemp2].m_CanMove == false || itemp == itemp2)
            {
                itemp2 = Random.Range(1, m_iRoomCount);
                itemp2 -= 1;
            }

            // Set the rooms which are about to swap to record their current position as their previous position
            m_Rooms[itemp].PrevPos = m_Rooms[itemp].CurrentPos;
            m_Rooms[itemp2].PrevPos = m_Rooms[itemp2].CurrentPos;

            // Move the Rooms
            m_Rooms[itemp].transform.position = m_Rooms[itemp2].PrevPos;
            m_Rooms[itemp2].transform.position = m_Rooms[itemp].PrevPos;

            // Update the Current Pos Vector in the Rooms
            m_Rooms[itemp].CurrentPos = m_Rooms[itemp].transform.position;
            m_Rooms[itemp2].CurrentPos = m_Rooms[itemp2].transform.position;
        }
    }    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RoomSwap();
            Debug.Log("Stuff");
        }
    }
}
