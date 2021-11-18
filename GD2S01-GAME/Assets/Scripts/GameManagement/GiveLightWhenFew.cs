
/*
Bachelor of Software Engineering
Media Design School
Auckland
New Zealand

(c) Media Design School

File Name : GiveLightWhenFew.cs
Description : Highlights objects with the same tag if there are few in the scene
Author : Richard Walters
Mail : richard.walters@mds.ac.nz
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLightWhenFew : MonoBehaviour
{
    public Light lightToSpawn;
    private bool lightIsSpawned = false;
    string objsTag;
    public int numTillSpawn = 3;

    // Start is called before the first frame update
    void Start()
    {
        objsTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lightIsSpawned && GameObject.FindGameObjectsWithTag(objsTag).Length <= numTillSpawn)
        {
            lightIsSpawned = true;
            Instantiate(lightToSpawn, transform.position, transform.rotation, transform);
        }
    }
}
