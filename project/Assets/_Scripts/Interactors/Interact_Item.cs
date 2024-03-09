using Game.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactors
{
    public class Interact_Item : MonoBehaviour, IInteractable, ILinkable
    {
        private InventoryHolder inventory;
        public ItemType itemToGive;

        [SerializeField] bool interactableSober = false;
        [SerializeField] bool interactableDrunk = false;
        public bool InteractableSober { get { return interactableSober; } set { interactableSober = value; } }
        public bool InteractableDrunk { get { return interactableDrunk; } set { interactableDrunk = value; } }
        public List<ItemType> RequiredItemsToInteract { get => null; }
        public ValueIdentifier CustomIdentifier { get { return customIdentifier; } }
        public ValueIdentifier customIdentifier;
        public bool touchInteraction = false;
        public bool TouchInteraction { get { return touchInteraction; } }

        public void Interact()
        {
            if (!interactableDrunk && !interactableSober) return;
            else if (!interactableSober && CustomIdentifier.Value == 1) return;
            else if (!interactableDrunk && CustomIdentifier.Value == -1) return;

            inventory.AddToInventory(itemToGive);
            StartCoroutine(Collected());
        }

        private IEnumerator Collected()
        {
            yield return new WaitForEndOfFrame();
            Destroy(gameObject);
        }

        public void InteractHighlight()
        {
            if (touchInteraction)
                Interact();
        }

        public void SaveLinkReference(GameObject masterObject) => inventory = masterObject.GetComponent<InventoryHolder>();
    }
}
