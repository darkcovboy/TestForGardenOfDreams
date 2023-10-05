using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemData : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Icon;
    public GameObject ItemObject;

    //Так как явно указать, что это подбираемый предмет через IItem мы не можем, то делаю доп проверку, что добавлен именно предмет, который IItem
    private void OnValidate()
    {
        if(ItemObject.TryGetComponent<IItem>(out IItem item) == false)
        {
            throw new System.Exception();
        }
    }
}
