using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Naruto_W : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("Run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
