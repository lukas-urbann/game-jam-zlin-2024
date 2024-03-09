using UnityEngine;

namespace Game
{ 
    public class CustomEventRaiser : MonoBehaviour
    {
        public CustomEvent selectedEvent;
        public bool disableAfterInvoke = false;

        public void InvokeEvent()
        {
            if (selectedEvent != null)
                selectedEvent.Raise();

            if (disableAfterInvoke)
                Destroy(this);
        }
    }
}

