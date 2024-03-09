using UnityEngine;

namespace Game
{ 
    public class CustomEventRaiser : MonoBehaviour
    {
        public CustomEvent selectedEvent;

        public void InvokeEvent()
        {
            if (selectedEvent != null)
                selectedEvent.Raise();
        }
    }
}

