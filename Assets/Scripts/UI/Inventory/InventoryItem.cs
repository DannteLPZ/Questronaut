using Questronaut.Interaction;
using System;

namespace Questronaut.Inventory
{
    [Serializable]
    public class InventoryItem
    {
        public ItemDataSO Item;
        public int CurrentAmount;

        public InventoryItem(ItemDataSO item, int currentAmount = 0)
        {
            Item = item;
            CurrentAmount = currentAmount;
        }

        public bool IsFull => CurrentAmount >= Item.MaxStackSize;
        public bool IsEmpty => Item == null; //string.IsNullOrEmpty(Item.Name);

        public override string ToString()
        {
            return $"ID: {Item.ID}, Amount: {CurrentAmount}";
        }
    }

}