using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LightManager : MonoBehaviour
{
    GameObject[] m_Lights;
    [SerializeField] AudioClip m_FlipSwitch;
    [SerializeField] AudioClip m_GirlGiggle;

    bool m_LightsOn = true;

    void Start()
    {
        m_Lights = GameObject.FindGameObjectsWithTag("MansionLights");
        StartCoroutine(StartGameLights());
    }

    public void ToggleLights()
    {
        foreach (GameObject light in m_Lights)
        {
            light.GetComponent<Light>().enabled = !light.GetComponent<Light>().enabled;
        }
        GetComponent<AudioSource>().PlayOneShot(m_FlipSwitch);
        m_LightsOn = !m_LightsOn;

        if (m_LightsOn)
        {
            StartCoroutine(SpookyLights());
        }
    }

    IEnumerator StartGameLights()
    {
        
        yield return new WaitForSeconds(3);
        GetComponent<AudioSource>().PlayOneShot(m_GirlGiggle);
        ToggleLights();
        
    }

    IEnumerator SpookyLights()
    {
        yield return new WaitForSeconds(30 + Random.Range(30, 60));
        GetComponent<AudioSource>().PlayOneShot(m_GirlGiggle);
        ToggleLights();
    }
}
