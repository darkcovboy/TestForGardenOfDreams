using UnityEngine;

public interface IFollowed
{
    //Реализуем интерфейс IFollowed, который будет в себе хранить позицию, чтобы мы в дальнейшем не отдавали камере весь скрипт Player, он там вообще не нужен.
    public Transform Body { get;}
}
