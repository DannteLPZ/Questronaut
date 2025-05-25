using Questronaut.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Questronaut.Inventory
{
    public class PlayerInventoryModel : MonoBehaviour
    {
        public event Action<int> OnItemDataChanged;
        public event Action<int> OnItemSelected;

        public static PlayerInventoryModel Instance;

        private const int MAX_INVENTORY_SLOTS = 9;

        private InventoryItem _selectedItem;
        public InventoryItem SelectedItem => _selectedItem;

        private List<InventoryItem> _inventoryData = new(MAX_INVENTORY_SLOTS);
        public List<InventoryItem> InventoryData => _inventoryData;

        private List<InventoryItemViewModel> _itemSlots = new(MAX_INVENTORY_SLOTS);

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

            _itemSlots = FindObjectsByType<InventoryItemViewModel>(FindObjectsSortMode.None).ToList();
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
                OnItemDataChanged?.Invoke(_inventoryData.IndexOf(inventoryItem));
            }
            //If no slot exists check if one can be added
            else 
            {
                inventoryItem = _inventoryData.Where(t => t.IsEmpty == true).FirstOrDefault();
                if( inventoryItem != null)
                {
                    inventoryItem.Item = item;
                    AddItem(item);
                }
            }
        }

        public void RemoveItem(int amount = 1)
        {
            InventoryItem inventoryItem = _inventoryData[_inventoryData.IndexOf(_selectedItem)];
            if (inventoryItem.CurrentAmount < amount)
                return;
            inventoryItem.CurrentAmount -= amount;

            if (inventoryItem.CurrentAmount == 0)
            {
                inventoryItem.Item = null;
                int newSelectedIndex = _inventoryData.IndexOf(_inventoryData.FirstOrDefault(t => t.Item != null));
                newSelectedIndex = newSelectedIndex >= 0 ? newSelectedIndex : 0;
                InventoryItemViewModel newSelectedSlot = _itemSlots[newSelectedIndex];
                GameObject newSelecteObject = newSelectedSlot.gameObject;

                EventSystem.current.SetSelectedGameObject(newSelecteObject);
                SelectItem(newSelectedIndex);
            }
            OnItemDataChanged?.Invoke(_inventoryData.IndexOf(inventoryItem));
        }

        public void SelectItem(int slot)
        {
            if (slot >= MAX_INVENTORY_SLOTS)
                return;
            _selectedItem = _inventoryData[slot];
            OnItemSelected?.Invoke(slot);
        }
    }

}
