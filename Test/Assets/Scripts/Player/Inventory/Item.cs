using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField,Min(1)] private int _capacity;

    public ItemData Data => _itemData;
    public int Capacity => _capacity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            void OnComplete()
            {
                player.AddItem(this);
                Destroy(gameObject);
            }

            transform.DOMove(player.transform.position, 0.1f).OnComplete(OnComplete);
        }
    }
}
