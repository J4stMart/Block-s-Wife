using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentDependent : MonoBehaviour
{
    protected abstract void ChangePlayerScore(float score);

    private void OnEnable()
    {
        EventManager.onUpdateScore += ChangePlayerScore;
    }

    private void OnDisable()
    {
        EventManager.onUpdateScore -= ChangePlayerScore;
    }
}
