using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AudioManager_B : MonoBehaviour
{
    public AudioSource[] m_Music;

    bool m_Switch = true;
   public bool m_CanPlay = true;
   public bool m_MusicIsPlaying = false;

    void Start()
    {
        StartCoroutine(PlaySong());
    }
    public IEnumerator PlaySong()
    {
        if (!(m_Music[1].isPlaying) && m_CanPlay)
        {
            yield return new WaitForSeconds(10);
            m_Music[1].Play();
        }
        //// m_MusicIsPlaying = true;

        // if (m_Music[0].isPlaying)
        // {
        //     m_MusicIsPlaying = true;
        // }

        //foreach (AudioSource source in m_Music)
        //{
        //    if (source.isPlaying)
        //    {
        //        m_MusicIsPlaying = true;
        //    }
        //}
        //foreach (AudioSource source in m_Music)
        //{
        //    if (!(source.isPlaying))
        //    {
        //        m_MusicIsPlaying = false;
        //    }

        //}


        //if ((m_Switch) && (!(m_Music[0].isPlaying)) && (m_CanPlay) && (!m_MusicIsPlaying))
        //{
        //    yield return new WaitForSeconds(1);
        //    //m_Music[0].Play();
        //    //m_Switch = !m_Switch;
        //}

        //if (!(m_Switch) && (!(m_Music[0].isPlaying)) && (m_CanPlay) && (!m_MusicIsPlaying))
        //{
        //    yield return new WaitForSeconds(1);
        //    m_Music[1].Play();
        //    //m_Switch = !m_Switch;
        //}
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
        PlaySong();
    }
}
