using System;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData
{
    public static readonly string DataPath = "Assets/Scripts/SaveData/json";

    public void SaveToJSON(string filePath, List<InventoryItem> inventoryItems)
    {
        Debug.Log("Сохраняемся");
        InventoryData inventoryData = new InventoryData
        {
            Items = inventoryItems
        };

        string jsonData = JsonUtility.ToJson(inventoryData);
        System.IO.File.WriteAllText(filePath, jsonData);
    }

    public bool TryLoadFromJSON(string filePath, out List<InventoryItem> items)
    {
        if (System.IO.File.Exists(filePath))
        {
            string jsonData = System.IO.File.ReadAllText(filePath);

            if (!string.IsNullOrEmpty(jsonData))
            {
                InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(jsonData);
                items = inventoryData.Items;
                return true;
            }
        }

        items = new List<InventoryItem>();
        return false;
    }
}

[Serializable]
public class InventoryData
{
    public List<InventoryItem> Items = new List<InventoryItem>();
}

