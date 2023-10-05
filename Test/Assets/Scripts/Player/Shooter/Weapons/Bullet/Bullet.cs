using UnityEngine;

public class Bullet : MonoBehaviour, IItem
{
    [SerializeField] private BulletData _bulletData;
    private Vector2 _direction;

    public void Initialize(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (_direction == null)
            return;

        transform.Translate(_direction * _bulletData.Speed * Time.deltaTime, Space.World);
        CheckOnScreen();
    }

    //Вообще конечно подобная реализация проверки мне не сильно нравится, но временно, чтобы не занимать ресурсы лучше сделать так
    //Потому что лучше будет впоследствии включать врагов, а не удалять так пули.
    private void CheckOnScreen()
    {
        Vector3 position = transform.position;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(position);

        Vector3 screenSize = new Vector3(Screen.width, Screen.height, 0);

        if (screenPosition.x < 0 || screenPosition.x > screenSize.x ||
            screenPosition.y < 0 || screenPosition.y > screenSize.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_bulletData.Damage);

            Destroy(gameObject);
        }
    }
}
