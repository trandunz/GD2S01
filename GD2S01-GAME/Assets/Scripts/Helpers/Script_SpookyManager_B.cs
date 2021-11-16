using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SpookyManager_B : MonoBehaviour
{
    // lights out
    // tension music plays
    // room move sound plays

    // lock all other doors
    // music stops
    [SerializeField] AudioClip m_RoomMoveSound;
    [SerializeField] AudioClip m_TensionMusic;
    [SerializeField] AudioClip m_CurrentMusic;

    [SerializeField] Room_Swap_J[] m_RoomSwaps;

    [SerializeField] Script_Door_W[] m_SpookyDoors;

    bool m_bIsSpooky;

    void Start()
    {
        m_bIsSpooky = false;
        //StartCoroutine(StartGameSpooky());
    }

    public IEnumerator StartGameSpooky()
    {
        //yield return new WaitForSeconds(60);
        if (!m_bIsSpooky)
        {
            m_bIsSpooky = true;        

            GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<Script_AudioManager_B>().StopMusic();
            //m_RoomSwaps[Random.Range(0, m_RoomSwaps.Length - 1)].RoomSwap();
            foreach (Room_Swap_J rooms in m_RoomSwaps)
            {
                rooms.RoomSwap();
            }
            GetComponent<AudioSource>().PlayOneShot(m_RoomMoveSound);
            yield return new WaitForSeconds(2);
            GetComponent<AudioSource>().PlayOneShot(m_TensionMusic);

            // restart music after a minute
            yield return new WaitForSeconds(60);
            GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<Script_AudioManager_B>().CanPlay();

            foreach (Script_Door_W door in m_SpookyDoors)
            {
                door.m_isLocked = false;
            }
        }
    }

    public void SwapBack()
    {
        foreach (Room_Swap_J rooms in m_RoomSwaps)
        {
            rooms.RoomSwap();
            m_bIsSpooky = false;
        }
    }

}
