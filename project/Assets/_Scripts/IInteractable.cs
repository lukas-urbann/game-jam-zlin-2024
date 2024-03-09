using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IInteractable
    {
        bool InteractableSober { get; set; }
        bool InteractableDrunk { get; set; }
        List<ItemType> RequiredItemsToInteract {  get; }
        public void InteractHighlight();
        public void Interact();
    }
}
