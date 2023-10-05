using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _capacity;
    [SerializeField] private Button _removeButton;

    public int Id { get; private set; }

    public Button RemoveButton => _removeButton;

    public void Render(Sprite icon, string name, int id, int capacity)
    {
        _image.sprite = icon;
        _name.text = name;
        Id = id;

        if(capacity > 1)
            _capacity.text = capacity.ToString();
        else
            _capacity.text = string.Empty;
    }

    public void UpdateCapacity(int capacity)
    {
        if (capacity > 1)
            _capacity.text = capacity.ToString();
        else
            _capacity.text = string.Empty;
    }

    private void OnEnable()
    {
        _removeButton.onClick.AddListener(Destroy);
    }

    private void OnDisable()
    {
        _removeButton.onClick.RemoveAllListeners();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
