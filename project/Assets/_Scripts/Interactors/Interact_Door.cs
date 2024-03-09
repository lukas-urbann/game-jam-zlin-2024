using Game.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Interact_Door : MonoBehaviour, IInteractable, ILinkable
    {
        private InventoryHolder inventory;
        [SerializeField] GameObject highlightObject;

        [SerializeField] bool interactableSober = false;
        [SerializeField] bool interactableDrunk = false;
        public bool InteractableSober { get { return interactableSober; } set { interactableSober = value; } }
        public bool InteractableDrunk { get { return interactableDrunk; } set { interactableDrunk = value; } }
        public List<ItemType> RequiredItemsToInteract { get { return requiredItemsToInteract; } }
        [SerializeField] List<ItemType> requiredItemsToInteract = new();

        public UnityEvent openWithoutKey;
        public UnityEvent openWithKey;

        public void Interact()
        {
            if (requiredItemsToInteract.Count <= 0)
            {
                StartCoroutine(Open());
                openWithKey?.Invoke();
                return;
            }
            else if (CheckForAllItems())
            {
                foreach (var item in requiredItemsToInteract)
                {
                    inventory.RemoveFromInventory(item);
                    StartCoroutine(Open());
                    openWithKey?.Invoke();
                }
            }
            else
            {
                openWithoutKey?.Invoke();
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

        private IEnumerator Open()
        {
            yield return new WaitForEndOfFrame();
            openWithKey?.Invoke();
        }

        public void InteractHighlight() => highlightObject.SetActive(!highlightObject.activeSelf);
        public void SaveLinkReference(GameObject masterObject) => inventory = masterObject.GetComponent<InventoryHolder>();
    }
}