using Game.Systems;
using UnityEngine;

namespace Game
{
    public class BeerCounter : MonoBehaviour, ILinkable
    {
        InventoryHolder inventory;
        public ItemType beerType;
        public Transform stretchedPanel;
        public GameObject beerDisplayPrefab;

        public void SaveLinkReference(GameObject masterObject)
        {
            inventory = masterObject.GetComponent<InventoryHolder>();
        }

        public void UpdateDisplay()
        {
            if (inventory == null) return;

            foreach(Transform child in stretchedPanel.transform)
            {
                Destroy(child.gameObject);
            }

            int size = inventory.GetCount(beerType);

            for (int i = 0; i < size; i++)
            {
                Instantiate(beerDisplayPrefab, stretchedPanel);
            }
        }
    }
}
