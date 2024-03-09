using UnityEngine;

namespace Game
{
    public interface IInteractable
    {
        bool InteractableSober { get; set; }
        bool InteractableDrunk { get; set; }
        public void InteractHighlight();
        public void Interact();
    }
}
