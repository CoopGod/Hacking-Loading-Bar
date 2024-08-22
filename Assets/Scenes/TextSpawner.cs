using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    public GameObject randomTextObject;
    public float timeBetweenSpawns = 0.2f;
    float currentTime = 0f;
    Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeBetweenSpawns)
        {
            Instantiate(randomTextObject, this.transform);
            currentTime = 0f;
        }
    }
}
