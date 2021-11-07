using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Dishwasher : MonoBehaviour
{
    Script_ObjectiveManager_W m_ObjectiveManager;

    [SerializeField] GameObject[] m_Dishes;

    void Start()
    {
        m_ObjectiveManager = GameObject.Find("ObjectiveManager").GetComponent<Script_ObjectiveManager_W>();
        foreach (GameObject dish in m_Dishes)
        {
            dish.SetActive(false);
        }
    }
    public void AddDish()
    {
        m_ObjectiveManager.m_DishNumber--;

        foreach (GameObject dish in m_Dishes)
        {
            if (dish.activeSelf == false)
            {
                dish.SetActive(true);
                break;
            }
        }
    }
}
