using System;
using UnityEngine;

public class TriggerBuffEvent : MonoBehaviour
{
    public event Action<TriggerBuffEvent, TriggerBuffEventArgs> OnTriggerBuffEnter;

    public void CallTriggerBuffEvent(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        OnTriggerBuffEnter?.Invoke(this, new TriggerBuffEventArgs()
        {
            currentEnergy = currentEnergy,
            currentRatio = currentRatio,
            currentTechnologyPoints = currentTechnologyPoints
        });
    }
}

public class TriggerBuffEventArgs : EventArgs
{
    public int currentEnergy;
    public int currentRatio;
    public int currentTechnologyPoints;
}
