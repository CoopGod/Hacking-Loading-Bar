using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLoadingBar : MonoBehaviour
{
    // Time in seconds
    public float startTime = 0.0f;
    public float endTime = 10.0f;
    float currentTime;
    float completeTime = 0f;
    // Position variables
    public float maxWidth; // TODO: Get this based off of size of parent
    public float maxHeight; // TODO: Get this based off of size of parent
    public float xPosition;
    public float yPosition = 0f;
    RectTransform rt;
    // Complete Variables
    Image image;
    public float completePulse = 0.4f;
    public Color completeColor;
    public Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        rt = GetComponent<RectTransform>();
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime < endTime)
        {
            rt.sizeDelta = new Vector2(maxWidth / (endTime / currentTime), maxHeight);
            rt.anchoredPosition = new Vector2(xPosition + (maxWidth / (endTime / currentTime) / 2), yPosition);
        }
        else
        {
            completeTime += Time.deltaTime;
            if (completeTime < completePulse)
            {
                image.color = completeColor;
                Debug.Log("Test1");
            }
            else if (completeTime < completePulse * 2)
            {
                image.color = defaultColor;
                Debug.Log("Test2");

            }
            else
            {
                completeTime = 0f;
                Debug.Log("Test3");

            }
        }
    }
}
