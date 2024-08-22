using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    public TMP_Text textBox;
    public float timeBetweenChange = 0.1f;
    public float fallSpeed = 100f;
    float currentTime = 0f;
    float cutoffHeight = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cutoffHeight = (-1) * transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeBetweenChange)
        {
            textBox.text = char.ToString((char)Random.Range(33, 127));
            currentTime = 0f;
        }
        transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);

        // If fallen off screen, remove
        if (this.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
