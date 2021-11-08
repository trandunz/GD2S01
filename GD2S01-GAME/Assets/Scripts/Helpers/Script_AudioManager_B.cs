using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AudioManager_B : MonoBehaviour
{
    public AudioSource[] m_Music;

    bool m_Switch = true;
    bool m_CanPlay = true;

    void Start()
    {
        StartCoroutine(PlaySong());
    }
    IEnumerator PlaySong()
    {
        yield return new WaitForSeconds(20);
        if (m_Switch && !m_Music[0].isPlaying && m_CanPlay == true)
        {
            m_Music[0].Play();
            m_Switch = !m_Switch;
        }

        if (!m_Switch && !m_Music[1].isPlaying && m_CanPlay == true)
        {
            m_Music[1].Play();
            m_Switch = !m_Switch;
        }
    }

    public void StopMusic()
    {
        foreach (AudioSource source in m_Music)
        {
            source.Stop();
        }
        m_CanPlay = false;
        StartCoroutine(PlaySong());
    }

    public void CanPlay()
    {
        m_CanPlay = true;
    }
}
