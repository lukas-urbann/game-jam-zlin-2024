using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class CustomEventListener : MonoBehaviour
{
    public CustomEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response?.Invoke();
    }
}
