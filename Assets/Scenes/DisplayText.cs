using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    // Messages
    public string[] messages;
    public float[] messageDurations;
    int[] messageLengths;
    bool[] messageCompletes;

    // Timing and Display Variables
    public TMP_Text textBox;

    public float timeBetweenChar = 0.1f;
    float currentTimeBetween = 0f;
    float totalTime = 0f;

    int currentLength = 0;
    bool messageDone = false;


    // Start is called before the first frame update
    void Start()
    {
        messageLengths = new int[messages.Length];
        messageCompletes = new bool[messages.Length + 1];

        // initalize lengths of strings and message completed codes
        for (int i = 0; i < messages.Length; i++)
        {
            messageLengths[i] = messages[i].Length;
            messageCompletes[i] = false;
        }
        messageCompletes[messages.Length] = false; // For complete message

        // Compound the message durations together to get timing transitions
        float currentTotal = -messageDurations[0];
        for (int i = 0; i < messages.Length; i++)
        {
            currentTotal += messageDurations[i];
            messageDurations[i] = currentTotal + messageDurations[i];
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalTime += Time.deltaTime;

        if (totalTime < messageDurations[0])
        {
            DisplayMessage(messageLengths[0], messages[0], 0);
        }
        else if (totalTime < messageDurations[1])
        {
            DisplayMessage(messageLengths[1], messages[1], 1);
        }
        else if (totalTime < messageDurations[2])
        {
            DisplayMessage(messageLengths[2], messages[2], 2);
        }
        else if (totalTime < messageDurations[3])
        {
            DisplayMessage(messageLengths[3], messages[3], 3);
        }
        else if (totalTime < messageDurations[4])
        {
            DisplayMessage(messageLengths[4], messages[4], 4);
        }
        else if (totalTime < messageDurations[5])
        {
            DisplayMessage(messageLengths[5], messages[5], 5);
        }
        else if (totalTime < messageDurations[6])
        {
            DisplayMessage(messageLengths[6], messages[6], 6);
        }
        else if (totalTime < messageDurations[7])
        {
            DisplayMessage(messageLengths[7], messages[7], 7);
        }
        else if (totalTime < messageDurations[8])
        {
            DisplayMessage(messageLengths[8], messages[8], 8);
        }
        else
        {
            DisplayMessage(18, "Download Complete!", 9);
        }

    }

    void DisplayMessage(int messageLength, string message, int messageIndex)
    {
        // Display Message
        currentTimeBetween += Time.deltaTime;
        if (currentTimeBetween >= timeBetweenChar && !messageCompletes[messageIndex])
        {
            if (currentLength < messageLength) // Add character to text if available
            {
                currentLength += 1;
                textBox.text = message.Substring(0, currentLength);
                currentTimeBetween = 0;
            }
            else // terminate future additions
            {
                messageCompletes[messageIndex] = true;
                currentLength = 0;
            }
        }
    }
}
