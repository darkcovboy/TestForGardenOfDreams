using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemData : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Icon;
    public GameObject ItemObject;

    //��� ��� ���� �������, ��� ��� ����������� ������� ����� IItem �� �� �����, �� ����� ��� ��������, ��� �������� ������ �������, ������� IItem
    private void OnValidate()
    {
        if(ItemObject.TryGetComponent<IItem>(out IItem item) == false)
        {
            throw new System.Exception();
        }
    }
}
