using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Script_ObjectiveManager_W : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_TaskListText;
    private List<string> m_TaskList = new List<string>();
    public TMPro.TextMeshProUGUI m_CompletedListText;
    private List<string> m_CompletedList = new List<string>();

    private GameObject[] m_CobwebObjectList;
    private GameObject[] m_WindowObjectList;
    private GameObject[] m_DishObjectList;
    public int m_WNumber;
    public int m_CWNumber;
    public int m_DishNumber;

    [SerializeField] AudioClip m_TaskCompleted;
    private bool m_GrabText;
    private void Start()
    {
        m_GrabText = true;
        m_CobwebObjectList = GameObject.FindGameObjectsWithTag("Cobweb");
        m_WindowObjectList = GameObject.FindGameObjectsWithTag("WindowObject");
        m_DishObjectList = GameObject.FindGameObjectsWithTag("Dish");
        m_CWNumber = m_CobwebObjectList.Length;
        m_WNumber = m_WindowObjectList.Length;
        m_DishNumber = m_DishObjectList.Length;

        addTask("- Close The Windows");
        addTask("- Clean Up Cobwebs");
        addTask("- Clean Up Dishes");
    }

    private void Update()
    {
        if (m_GrabText)
        {
            m_TaskListText = GameObject.FindGameObjectWithTag("TaskList").GetComponent<TMPro.TextMeshProUGUI>();
            m_TaskListText.text = "";
            m_CompletedListText = GameObject.FindGameObjectWithTag("TaskFinished").GetComponent<TMPro.TextMeshProUGUI>();
            m_CompletedListText.text = "";
            m_GrabText = false;
        }

        UpdateText(m_TaskListText, m_TaskList);
        UpdateText(m_CompletedListText, m_CompletedList);
    }

    public void addTask(string newInput)
    {
        Debug.Log(newInput);
        m_TaskList.Add(newInput);
    }

    public void removeTask(string newInput)
    {
        foreach (string s in m_TaskList)
        {
            if (s == newInput)
            {
                Debug.Log("Completed (" + newInput + ")");
                PlayTaskCompleted();
                m_TaskList.Remove(newInput);
                m_CompletedList.Add(newInput);
                break;
            }
        }
        
        
    }

    void PlayTaskCompleted()
    {
        GetComponent<AudioSource>().PlayOneShot(m_TaskCompleted);
    }
    private void UpdateText(TMPro.TextMeshProUGUI _text , List<string> _StringList )
    {
        _text.text = "";
        foreach (string s in _StringList)
        {
            if (s == "- Close The Windows")
            {
                _text.text = _text.text + s + "(" + m_WNumber + " Remaining)" + "\n";
            }
            else if (s == "- Clean Up Cobwebs")
            {
                _text.text = _text.text + s + "(" + m_CWNumber + " Remaining)" + "\n";
            }
            else if (s == "- Clean Up Dishes")
            {
                _text.text = _text.text + s + "(" + m_DishNumber + " Remaining)" + "\n";
            }
            else
            {
                _text.text = _text.text + s + "\n";
            }
        }

    }
}
