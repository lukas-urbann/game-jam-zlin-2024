using Game.Systems;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Interact_Door : MonoBehaviour, IInteractable, ILinkable
    {
        private InventoryHolder inventory;
        [SerializeField] GameObject highlightObject;
        public ItemType key;

        [SerializeField] bool interactableSober = false;
        [SerializeField] bool interactableDrunk = false;
        public bool InteractableSober { get { return interactableSober; } set { interactableSober = value; } }
        public bool InteractableDrunk { get { return interactableDrunk; } set { interactableDrunk = value; } }

        public UnityEvent openWithoutKey;
        public UnityEvent openWithKey;

        public void Interact()
        {
            if (key == null)
                StartCoroutine(Open());

            Debug.Log("test1");

            if (inventory)
                if (inventory.CheckForItem(key))
                {
                    inventory.RemoveFromInventory(key);
                    StartCoroutine(Open() );
                    Debug.Log("test2");
                }
                else
                {
                    openWithoutKey?.Invoke();
                    Debug.Log("test3");
                }
        }

        private IEnumerator Open()
        {
            yield return new WaitForEndOfFrame();
            openWithKey?.Invoke();
            Debug.Log("test4");
        }

        public void InteractHighlight() => highlightObject.SetActive(!highlightObject.activeSelf);
        public void SaveLinkReference(GameObject masterObject) => inventory = masterObject.GetComponent<InventoryHolder>();
    }
}