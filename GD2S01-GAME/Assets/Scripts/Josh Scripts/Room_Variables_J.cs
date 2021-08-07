using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Variables_J : MonoBehaviour
{
    // Remebers the Position that it is currently in, and the postion that it was last in
    public Vector3 CurrentPos;
    public Vector3 PrevPos;

    // Start is called before the first frame update
    void Start()
    {
        // updates the currentpos to its current postion at start
        CurrentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
