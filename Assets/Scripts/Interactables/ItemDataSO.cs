using Questronaut.Inventory;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Questronaut.Interaction
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
    public class ItemDataSO : ScriptableObject
    {
        public string ID;
        public string Name;
        public string Description;
        public int MaxStackSize;
        public Sprite Icon;
    }

    [Serializable]
    public class ItemSaveData
    {
        public string ID;
        public int CurrentAmount;
    }

    [Serializable]
    public class InventoryData
    {
        public List<InventoryItem> InventoryItems = new();
    }

    [Serializable]
    public class InventorySaveData
    {
        public List<ItemSaveData> InventoryItems = new();
    }


}
