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

    void Start()
    {
        StartCoroutine(StartGameSpooky());
    }

    IEnumerator StartGameSpooky()
    {
        yield return new WaitForSeconds(60);
        GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<Script_AudioManager_B>().StopMusic();
        m_RoomSwaps[Random.Range(0, m_RoomSwaps.Length - 1)].RoomSwap();
        GetComponent<AudioSource>().PlayOneShot(m_RoomMoveSound);
        GetComponent<AudioSource>().PlayOneShot(m_TensionMusic);

        // restart music after a minute
        yield return new WaitForSeconds(60);
        GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<Script_AudioManager_B>().CanPlay();
    }


}
