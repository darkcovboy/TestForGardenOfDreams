using UnityEngine;

[CreateAssetMenu(fileName = "Container", menuName = "PrefabContainer/InitialScene")]
public class InitialSceneContainer : ScriptableObject
{
    [SerializeField] private SceneLoaderService _sceneLoaderService;

    public SceneLoaderService SceneLoaderService => _sceneLoaderService;

    /*
     * ћожно написать как [field: SerializeField] чтобы можно было пользоватьс€ как свойством, но с такой штукой у мен€ часто слетали ScriptableObject'ы, поэтому сделаю так.  
     */
}
