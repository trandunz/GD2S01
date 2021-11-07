using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LightManager : MonoBehaviour
{
    GameObject[] m_Lights;
    [SerializeField] AudioClip m_FlipSwitch;
    [SerializeField] AudioClip m_PowerDown;

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
    }

    IEnumerator StartGameLights()
    {
        GetComponent<AudioSource>().PlayOneShot(m_PowerDown);
        yield return new WaitForSeconds(3);
        ToggleLights();
        
    }
}
