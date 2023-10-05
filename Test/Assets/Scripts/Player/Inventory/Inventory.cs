using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Inventory
{
    public IReadOnlyList<InventoryItem> Items
    {
        get { return _items.AsReadOnly(); }
    }

    public event Action<InventoryItem> ItemAdded;
    public event Action<InventoryItem> ItemCapacityUpdated;

    private List<InventoryItem> _items = new List<InventoryItem>();

    public void SaveData()
    {
        Debug.Log("Сохраняем");
        PersistentData persistentData = new PersistentData();
        persistentData.SaveToJSON(PersistentData.DataPath, _items);
    }

    public Inventory(List<InventoryItem> inventoryItems)
    {
        _items = inventoryItems;
    }

    public void Add(Item itemToAdd, int capacity = 1)
    {
        InventoryItem item = _items.Find(item => item.ItemData.Data.Id == itemToAdd.Data.Id);

        if(item != null)
        {
            item.Capacity += capacity;
            ItemAdded?.Invoke(item);
        }
        else
        {
            InventoryItem inventoryItem = new InventoryItem(itemToAdd, capacity);
            ItemAdded?.Invoke(inventoryItem);
            _items.Add(inventoryItem);
        }
    }

    public void Remove(Item itemToRemove, int capacity = 1)
    {
        InventoryItem item = _items.Find(item => item.ItemData.Data.Id == itemToRemove.Data.Id);

        if(item != null)
        {
            item.Capacity -= capacity;

            if(item.Capacity <= 0)
            {
                _items.Remove(item);
            }
        }
    }

    public void Remove(int id,bool isAllRemove = true, int capacity = 1)
    {
        InventoryItem item = _items.Find(item => item.ItemData.Data.Id == id);

        if (item != null)
        {
            if(isAllRemove == true)
            {
                item.Capacity = 0;

                _items.Remove(item);
            }
            else
            {
                item.Capacity -= capacity;

                if (item.Capacity <= 0)
                {
                    _items.Remove(item);
                }
            }
        }
    }

    public bool TryGet<T>(out T item, bool isTakenFrom = false) where T : Component
    {
        foreach (var inventoryItem in _items)
        {
            GameObject itemObject = inventoryItem.ItemData.Data.ItemObject;

            if (itemObject != null && itemObject.TryGetComponent<T>(out item))
            {
                if (isTakenFrom == true)
                {
                    inventoryItem.Capacity -= 1;
                    ItemCapacityUpdated?.Invoke(inventoryItem);
                }

                return true;
            }
        }

        item = null;
        return false;
    }
}

[System.Serializable]
public class InventoryItem
{
    public Item ItemData;
    public int Capacity;

    public InventoryItem(Item item, int capacity)
    {
        ItemData = item;
        Capacity = capacity;
    }
}
