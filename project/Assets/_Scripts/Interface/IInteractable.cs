using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IInteractable
    {
        ValueIdentifier CustomIdentifier { get; }
        bool InteractableSober { get; set; }
        bool InteractableDrunk { get; set; }
        List<ItemType> RequiredItemsToInteract {  get; }
        public void InteractHighlight();
        public void Interact();
        public bool TouchInteraction {  get; }
    }

    /*
     * 
     * 
     *
     *
     *
        private InventoryHolder inventory;
        public List<ItemType> RequiredItemsToInteract { get { return requiredItemsToInteract; } }
        [SerializeField] List<ItemType> requiredItemsToInteract = new();
    
        public UnityEvent InteractionWithoutKey;
        public UnityEvent InteractionWithKey;

        public void Interact()
        {
            if (requiredItemsToInteract.Count <= 0)
            {
                InteractionWithKey?.Invoke();
                return;
            }
            else if (CheckForAllItems())
            {
                foreach (var item in requiredItemsToInteract)
                {
                    inventory.RemoveFromInventory(item);
                    InteractionWithKey?.Invoke();
                }
            }
            else
            {
                InteractionWithoutKey?.Invoke();
            }    
        }

        private bool CheckForAllItems()
        {
            foreach (var item in requiredItemsToInteract)
            {
                if (!inventory.CheckForItem(item))
                    return false;
            }
            return true;
        }
     * 
     */
}
