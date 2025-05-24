using Questronaut.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Questronaut.Inventory
{
    public class PlayerInventoryModel : MonoBehaviour
    {
        public event Action<int> OnItemSlotChanged;


        public static PlayerInventoryModel Instance;

        private const int MAX_INVENTORY_SLOTS = 9;
        private List<InventoryItem> _inventoryData = new(MAX_INVENTORY_SLOTS);
        public List<InventoryItem> InventoryData => _inventoryData;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            for (int i = 0; i < MAX_INVENTORY_SLOTS; i++)
                _inventoryData.Add(new(null));

            //TO_DO: BIND DATA FROM SAVE FILE
        }

        public void AddItem(ItemData item, int amount = 1)
        {
            //Check for available slot
            InventoryItem inventoryItem = _inventoryData.Where(t => t.Item == item && t.IsFull == false).FirstOrDefault();

            //If one exists with the same item or empty, try adding full amount
            if (inventoryItem != null)
            {
                //If adding full amount overflows, fill, then check for available slot
                if (inventoryItem.CurrentAmount + amount > item.MaxStackSize)
                {
                    int overflow = inventoryItem.CurrentAmount + amount - item.MaxStackSize;
                    inventoryItem.CurrentAmount = item.MaxStackSize;
                    AddItem(item, overflow);
                }
                else
                {
                    inventoryItem.CurrentAmount += amount;
                }
                OnItemSlotChanged?.Invoke(_inventoryData.IndexOf(inventoryItem));
            }
            //If no slot exists check if one can be added
            else 
            {
                Debug.Log($"No item slot found");
                inventoryItem = _inventoryData.Where(t => t.IsEmpty == true).FirstOrDefault();
                Debug.Log($"Found empty slot? {inventoryItem != null}");
                if( inventoryItem != null)
                {
                    inventoryItem.Item = item;
                    AddItem(item);
                }
            }
        }
    }

}
