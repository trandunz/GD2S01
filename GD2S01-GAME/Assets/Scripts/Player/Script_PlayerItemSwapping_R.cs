using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerItemSwapping_R : MonoBehaviour
{

    public List<GameObject> storedItems;
    public int activeItemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in storedItems)
        {
            go.SetActive(false); //set every item to be inactive
        }
        storedItems[activeItemIndex].SetActive(true); //set the currently held item to be active
    }

    // Update is called once per frame
    void Update()
    {
        float scrl = Input.mouseScrollDelta.y; //get scroll wheel input
        if (scrl != 0)
        {
            storedItems[activeItemIndex].SetActive(false);
            activeItemIndex += (int)scrl;
            if (activeItemIndex < 0) //too low
                activeItemIndex = storedItems.Count - 1;
            if (activeItemIndex > storedItems.Count-1) //too high
                activeItemIndex = 0;

            storedItems[activeItemIndex].SetActive(true);
        }
    }
}
