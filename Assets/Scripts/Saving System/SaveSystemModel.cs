using Questronaut.Interaction;
using Questronaut.Inventory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveSystemModel : MonoBehaviour
{
    private string SavePath => Application.persistentDataPath + "/Inventory.json";

    [SerializeField] private ItemDatabase _itemDatabase;

    private void Start()
    {
        LoadData();
        PlayerInventoryModel.Instance.OnItemDataChanged += x => SaveData();
    }

    private void OnDestroy()
    {
        PlayerInventoryModel.Instance.OnItemDataChanged -= x => SaveData();
    }

    public void SaveData()
    {
        InventorySaveData saveData = new();

        foreach (InventoryItem item in PlayerInventoryModel.Instance.InventoryData)
        {
            if (item == null || item.Item == null)
                continue;

            saveData.InventoryItems.Add(new ItemSaveData
            {
                ID = item.Item.ID,
                CurrentAmount = item.CurrentAmount
            });
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(SavePath, json);
        Debug.Log(json);
    }

    public void LoadData()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("No save file found at: " + SavePath);
            return;
        }

        string json = File.ReadAllText(SavePath);
        InventorySaveData saveData = JsonUtility.FromJson<InventorySaveData>(json);

        List<InventoryItem> savedInventory = new();

        foreach (ItemSaveData entry in saveData.InventoryItems)
        {
            ItemDataSO item = _itemDatabase.GetItem(entry.ID);
            if (item != null)
            {
                savedInventory.Add(new InventoryItem(item, entry.CurrentAmount));
            }
            else
            {
                Debug.LogWarning($"Item with id '{entry.ID}' not found in database.");
            }
        }
        PlayerInventoryModel.Instance.SetInventory(savedInventory);
    }    
}
