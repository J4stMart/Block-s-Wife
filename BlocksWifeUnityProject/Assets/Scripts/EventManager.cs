using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void scoreDelegate(float score);
    public static scoreDelegate onUpdateScore;

    public static void UpdateScore(float score)
    {
        if (onUpdateScore != null)
            onUpdateScore(score);
    }
}
