using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TaskCompleted : MonoBehaviour
{
    public void EnableTaskCompleted()
    {
        this.gameObject.SetActive(true);
    }

    public void DisableTaskCompleted()
    {
        this.gameObject.SetActive(false);
    }
}
