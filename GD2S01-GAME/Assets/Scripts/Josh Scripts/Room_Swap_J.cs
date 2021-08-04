using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Swap_J : MonoBehaviour
{
    [SerializeField] Vector3 m_Origin;
    public Vector3 CurrentPos;
    public Vector3 PrevPos;

    [SerializeField] int m_iRoomTalley;

    [SerializeField] Room_Swap_J[] m_RoomCount;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPos = transform.position;
        m_Origin = CurrentPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int itemp = Random.Range(1, m_iRoomTalley);
            itemp -= 1;

            PrevPos = CurrentPos;
            CurrentPos = m_RoomCount[itemp].CurrentPos;

            m_RoomCount[itemp].PrevPos = m_RoomCount[itemp].CurrentPos;

            m_RoomCount[itemp].transform.position = m_RoomCount[itemp].CurrentPos;

            m_RoomCount[itemp].CurrentPos = PrevPos;
        }
    }
}
