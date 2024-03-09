using Game.Systems;
using System.Collections;
using UnityEngine;

namespace Game.Interactors
{
    public class Interact_Item : MonoBehaviour, IInteractable, ILinkable
    {
        private InventoryHolder inventory;
        public ItemType itemToGive;

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
