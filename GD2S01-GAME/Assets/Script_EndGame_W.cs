using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EndGame_W : MonoBehaviour
{
    public float waitTime = 2.0f;

    float m_ColourChangeTime = 0.2f;
    float m_CurrentTime = 0;

    [SerializeField] GameObject m_Wall;
    
    GameObject[] m_AbeTest;
    [SerializeField] GameObject[] m_Lights;
    [SerializeField] GameObject[] m_LightBulbs;
    [SerializeField] AudioClip Thriller;

    bool doOnce = false;
    bool isDancing = false;
    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        m_Wall.GetComponent<Animator>().SetTrigger("OpenDoor");
        GetComponent<AudioSource>().PlayOneShot(Thriller);
        m_AbeTest = GameObject.FindGameObjectsWithTag("AbeTest");
        m_Lights = GameObject.FindGameObjectsWithTag("AbeLights");
        m_LightBulbs = GameObject.FindGameObjectsWithTag("AbeBulbs");

        foreach (GameObject gameObject in m_AbeTest)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Play");
        }
        foreach (GameObject gameObject in m_Lights)
        {
            gameObject.GetComponent<Light>().intensity = 5.0f;
        }

        isDancing = true;
    }

    private void Update()
    {
        m_CurrentTime += Time.deltaTime;
        if (m_CurrentTime >= m_ColourChangeTime)
        {
            foreach (GameObject gameObject in m_Lights)
            {
                gameObject.GetComponent<Light>().color = new Color(Random.value, Random.value, Random.value);
            }
            foreach (GameObject gameObject in m_LightBulbs)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
            }
            m_CurrentTime = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !doOnce)
        {
            StartCoroutine(EndGameCoroutine());
            doOnce = true;
        }
       
    }
}
