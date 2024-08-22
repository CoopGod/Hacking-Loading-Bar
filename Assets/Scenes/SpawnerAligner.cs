using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAligner : MonoBehaviour
{
    public GameObject textSpawner;
    public int numberOfSpawners = 40;

    // Start is called before the first frame update
    void Start()
    {
        float spaceBetweenSpawners = Screen.width / (numberOfSpawners-1);
        this.transform.position = new Vector3(0, Screen.height, 0); 
        for (int i = 0; i < numberOfSpawners; i++)
        {
            GameObject newObject = Instantiate(textSpawner, this.transform.position + new Vector3(spaceBetweenSpawners*i, 0), Quaternion.identity);
            newObject.transform.SetParent(this.transform);
        }
    }
}
