using Zenject;
using UnityEngine;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private InitialSceneContainer _prefabContainer;

    public override void InstallBindings()
    {
        SceneLoaderService sceneLoader = Container.InstantiatePrefabForComponent<SceneLoaderService>(_prefabContainer.SceneLoaderService);
    }
}
