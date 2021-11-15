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
