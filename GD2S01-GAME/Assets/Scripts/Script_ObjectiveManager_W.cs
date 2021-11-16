using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Script_ObjectiveManager_W : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_TaskListText;
    private List<string> m_TaskList = new List<string>();
    public TMPro.TextMeshProUGUI m_CompletedListText;
    private List<string> m_CompletedList = new List<string>();

    private GameObject[] m_CobwebObjectList;
    private GameObject[] m_WindowObjectList;
    private GameObject[] m_DishObjectList;
    private GameObject[] m_ClothesObjectList;
    public int m_WNumber;
    public int m_DWNumber;
    public int m_CWNumber;
    public int m_DishNumber;
    public int m_clothesNumber;

    [SerializeField] AudioClip m_TaskCompleted;
    private bool m_GrabText;

    public bool m_bTutorial = false;
    [SerializeField] Script_Door_W m_BasementDoor;

    [SerializeField] bool m_bDebugBasement = false;

    private float m_BlackingOut = 60.0f;


    private void Awake()
    {
        if (m_bTutorial)
        {
            StartCoroutine(TutorialMouseWheel());
        }
    }

    private void Start()
    {
        m_GrabText = true;
        m_CobwebObjectList = GameObject.FindGameObjectsWithTag("Cobweb");
        m_WindowObjectList = GameObject.FindGameObjectsWithTag("WindowObject");
        m_DishObjectList = GameObject.FindGameObjectsWithTag("Dish");
        m_ClothesObjectList = GameObject.FindGameObjectsWithTag("Clothes");
        m_CWNumber = m_CobwebObjectList.Length;
        m_WNumber = m_WindowObjectList.Length;
        foreach (GameObject window in m_WindowObjectList)
        {
            if(window.GetComponentInChildren<WindowClean_B>().m_isClean == false)
            {
                m_DWNumber++;
            }
        }
        m_DishNumber = m_DishObjectList.Length;
        m_clothesNumber = m_ClothesObjectList.Length;

        addTask("- Close The Windows");
        addTask("- Clean The Windows");
        addTask("- Clean Up Cobwebs");
        addTask("- Clean Up Dishes");
        addTask("- Wash Clothes");
        addTask("- Turn On Power");
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

        
        if (m_TaskList.Count <= 0 || m_bDebugBasement)
        {
            m_bDebugBasement = false;

            if (m_bTutorial)
            {
                m_BlackingOut += 0.04f;
                // fade character view to red                
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().fieldOfView = m_BlackingOut;
                StartCoroutine(SwitchToMain());
            }
            else
            {
                //basement shit
                m_BasementDoor.GetComponentInChildren<Animator>().SetBool("Open", true); // "Open" -> "Open90"
                GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponent<Animator>().SetTrigger("TaskComplete");
                GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText("- Clean Basement...");
                GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponentInChildren<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                addTask("- Clean Basement...");
            }
        }
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
                GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponent<Animator>().SetTrigger("TaskComplete");
                GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(newInput);
                GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponentInChildren<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
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
            else if (s == "- Clean The Windows")
            {
                _text.text = _text.text + s + "(" + m_DWNumber + " Remaining)" + "\n";
            }
            else if (s == "- Clean Up Cobwebs")
            {
                _text.text = _text.text + s + "(" + m_CWNumber + " Remaining)" + "\n";
            }
            else if (s == "- Clean Up Dishes")
            {
                _text.text = _text.text + s + "(" + m_DishNumber + " Remaining)" + "\n";
            }
            else if (s == "- Wash Clothes")
            {
                _text.text = _text.text + s + "(" + m_clothesNumber + " Remaining)" + "\n";
            }
            else
            {
                _text.text = _text.text + s + "\n";
            }
        }

    }

    IEnumerator TutorialMouseWheel()
    {
        yield return new WaitForSeconds(10);
        GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponent<Animator>().speed = 0.5f;
        GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponent<Animator>().SetTrigger("TaskComplete");
        GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText("Use Mouse Wheel to change tools.");
        GameObject.FindGameObjectWithTag("TaskCompletedUI").GetComponentInChildren<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.Bold;
    }

    IEnumerator SwitchToMain()
    {
        yield return new WaitForSeconds(6);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Canvas"));
        SceneManager.LoadScene(sceneName: "MainGame");
    }
}
