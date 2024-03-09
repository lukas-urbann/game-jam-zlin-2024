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
        public List<ItemType> RequiredItemsToInteract { get { return requiredItemsToInteract; } }
        [SerializeField] List<ItemType> requiredItemsToInteract = new();

        public void Interact()
        {
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
            //Dont need this one
        }

        public void SaveLinkReference(GameObject masterObject) => inventory = masterObject.GetComponent<InventoryHolder>();
    }
}
