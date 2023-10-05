using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using static UnityEditor.Progress;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private InventoryItemView _itemViewPrefab;

    private Inventory _inventory;
    private List<InventoryItemView> _inventoryItemsView = new List<InventoryItemView>();

    [Inject]
    private void Constructor(Inventory inventory)
    {
        _inventory = inventory;
        _inventory.ItemAdded += CreateItem;
        _inventory.ItemCapacityUpdated += UpdateCapacity;
    }

    private void Start()
    {
        CreateItems();
    }

    private void OnDisable()
    {
        _inventory.ItemAdded -= CreateItem;
        _inventory.ItemCapacityUpdated -= UpdateCapacity;
    }

    private void CreateItems()
    {
        if(_inventory.Items != null)
        {
            foreach (var item in _inventory.Items)
            {
                var itemView = Instantiate(_itemViewPrefab, _container.transform);
                itemView.Render(item.ItemData.Data.Icon, item.ItemData.Data.Name, item.ItemData.Data.Id, item.Capacity);
                itemView.RemoveButton.onClick.AddListener(() => RemoveItem(itemView.Id));
                _inventoryItemsView.Add(itemView);
            }
        }
    }

    private void CreateItem(InventoryItem inventoryItem)
    {
        if(IsItemExist(out InventoryItemView itemView, inventoryItem))
        {
            itemView.UpdateCapacity(inventoryItem.Capacity);
        }
        else
        {
            itemView = Instantiate(_itemViewPrefab, _container.transform);
            itemView.Render(inventoryItem.ItemData.Data.Icon, inventoryItem.ItemData.Data.Name, inventoryItem.ItemData.Data.Id, inventoryItem.Capacity);
            itemView.RemoveButton.onClick.AddListener(() => RemoveItem(itemView.Id));
            _inventoryItemsView.Add(itemView);
        }
    }

    private void UpdateCapacity(InventoryItem inventoryItem)
    {
        if (IsItemExist(out InventoryItemView itemView, inventoryItem))
        {
            itemView.UpdateCapacity(inventoryItem.Capacity);
        }
    }

    private bool IsItemExist(out InventoryItemView item, InventoryItem inventoryItem)
    {
        item = _inventoryItemsView.First(x => x.Id == inventoryItem.ItemData.Data.Id);

        if(item == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void RemoveItem(int id)
    {
        _inventory.Remove(id, true);
    }
}
