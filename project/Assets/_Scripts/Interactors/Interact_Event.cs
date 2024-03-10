using Game.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Interactors
{
    public class Interact_Event : MonoBehaviour, IInteractable, ILinkable
    {
        private InventoryHolder inventory;
        [SerializeField] GameObject highlightObject;
        [SerializeField] bool interactableSober = false;
        [SerializeField] bool interactableDrunk = false;
        public bool InteractableSober { get { return interactableSober; } set { interactableSober = value; } }
        public bool InteractableDrunk { get { return interactableDrunk; } set { interactableDrunk = value; } }
        public List<ItemType> RequiredItemsToInteract { get { return requiredItemsToInteract; } }
        public ValueIdentifier CustomIdentifier { get { return customIdentifier; } }

        public bool touchInteraction = false;
        public bool TouchInteraction { get { return touchInteraction; } }

        public ValueIdentifier customIdentifier;

        [SerializeField] List<ItemType> requiredItemsToInteract = new();

        public UnityEvent InteractionWithoutItems;
        public UnityEvent InteractionWithItems;

        public void Interact()
        {
            if (!interactableDrunk && !interactableSober) return;
            else if (!interactableSober && CustomIdentifier.Value == 1) return;
            else if (!interactableDrunk && CustomIdentifier.Value == -1) return;

            if (requiredItemsToInteract.Count <= 0)
            {
                AudioSingleton.instance.PlaySoundOneShot(AudioSingleton.instance.interactSound);
                InteractionWithItems?.Invoke();
                return;
            }
            else if (CheckForAllItems())
            {
                foreach (var item in requiredItemsToInteract)
                {
                    AudioSingleton.instance.PlaySoundOneShot(AudioSingleton.instance.interactSound);
                    inventory.RemoveFromInventory(item);
                    InteractionWithItems?.Invoke();
                }
            }
            else
            {
                InteractionWithoutItems?.Invoke();
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

        public void InteractHighlight()
        {
            if (!interactableDrunk && !interactableSober) return;
            else if (!interactableSober && CustomIdentifier.Value == 1) return;
            else if (!interactableDrunk && CustomIdentifier.Value == -1) return;

            highlightObject.SetActive(!highlightObject.activeSelf);

            if (touchInteraction)
                Interact();
        }
        public void SaveLinkReference(GameObject masterObject) => inventory = masterObject.GetComponent<InventoryHolder>();
    }
}
