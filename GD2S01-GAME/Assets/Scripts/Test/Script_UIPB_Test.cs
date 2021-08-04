using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_UIPB_Test : MonoBehaviour
{
    public Sprite m_sPlayButton;
    public Sprite m_sPauseButton;
    public List<Animator> m_aAnimatorList;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("FloorSpeakers_2").GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<Image>().sprite = m_sPlayButton;
        }
    }

    public void Play()
    {
        if (!GameObject.Find("FloorSpeakers_2").GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<Image>().sprite = m_sPauseButton;
            GameObject.Find("FloorSpeakers_2").GetComponent<AudioSource>().Play();
            foreach (Animator animator in m_aAnimatorList)
            {
                if (animator.speed == 0)
                {
                    animator.speed = 1;
                }
                else
                {
                    animator.SetTrigger("Play");
                }
                
            }
        }
        else if (GameObject.Find("FloorSpeakers_2").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("FloorSpeakers_2").GetComponent<AudioSource>().Pause();
            foreach (Animator animator in m_aAnimatorList)
            {
                animator.speed = 0;
            }
        }



    }
}
