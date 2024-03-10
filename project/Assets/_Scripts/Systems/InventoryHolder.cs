using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Systems
{
    public class InventoryHolder : MonoBehaviour
    {
        public CustomEvent inventoryUpdateEvent;
        public List<ItemType> Items = new();
        public void AddToInventory(ItemType item)
        {
            Items.Add(item);
            inventoryUpdateEvent.Raise();
        }
        public void RemoveFromInventory(ItemType item)
        {
            Items.Remove(item);
            inventoryUpdateEvent.Raise();
        }

        public bool CheckForItem(ItemType item) => Items.Contains(item);
        public int GetCount(ItemType item) => Items.Count(i => i == item);
    }
}

