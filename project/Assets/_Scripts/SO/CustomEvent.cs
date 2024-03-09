using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomEvent : ScriptableObject
{
    private List<CustomEventListener> listeners = new List<CustomEventListener> ();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--) {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(CustomEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(CustomEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
