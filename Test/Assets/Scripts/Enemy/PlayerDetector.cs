using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool IsPlayerFounded => Player != null;
    public Player Player { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            Player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Player = null;
        }
    }
}
