using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems
{
    public class InventoryHolder : MonoBehaviour
    {
        public List<ItemType> Items = new();
        public void AddToInventory(ItemType item) => Items.Add(item);
        public void RemoveFromInventory(ItemType item) => Items.Remove(item);
        public bool CheckForItem(ItemType item) => Items.Contains(item);
    }
}

