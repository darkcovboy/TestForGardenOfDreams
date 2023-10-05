using UnityEngine;

[CreateAssetMenu(fileName = "Container", menuName = "PrefabContainer/InitialScene")]
public class InitialSceneContainer : ScriptableObject
{
    [SerializeField] private SceneLoaderService _sceneLoaderService;

    public SceneLoaderService SceneLoaderService => _sceneLoaderService;

    /*
     * ����� �������� ��� [field: SerializeField] ����� ����� ���� ������������ ��� ���������, �� � ����� ������ � ���� ����� ������� ScriptableObject'�, ������� ������ ���.  
     */
}
