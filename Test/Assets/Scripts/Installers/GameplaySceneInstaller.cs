using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private GameplaySceneContainer _gamePlaySceneContainer;
    [SerializeField] private List<Item> _items;
    [SerializeField] private EnemyFactoryData _enemyFactoryData;
    [SerializeField] private WinPanel _winPanel;
    [Header("Positions")]
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _enemySpawner;

    private Inventory _inventory;

    public override void InstallBindings()
    {
        BindMovement();
        BindEnemyFactory();
        BindInventory();
        BindPlayer();
    }

    private void BindEnemyFactory()
    {
        Container.Bind<WinPanel>().FromInstance(_winPanel).AsSingle();
        EnemyFactory enemyFactory = new EnemyFactory(Container, _enemyFactoryData, _enemySpawner);
        Container.Bind<EnemyFactory>().FromInstance(enemyFactory).AsSingle();
        EnemySpawner spawner = Container.InstantiatePrefabForComponent<EnemySpawner>(_gamePlaySceneContainer.EnemySpawner);
        Container.Bind<IGameEndHandler>().To<EnemySpawner>().FromInstance(spawner).AsSingle();
        Container.Bind<SceneLoaderService>().FromInstance(SceneLoaderService.Instance).AsSingle();
    }

    private void BindMovement()
    {
        /*
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
        }
        else
        {
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        }
        Вариант реализации для мультиплатформы, можно будет будет добавить другие, но так как пока тестовый проект будем запускать в Editor, то оставлю один вариант
        */

        Container.BindInterfacesAndSelfTo<EditorInput>().AsSingle();
    }

    private void BindInventory()
    {
        PersistentData persistentData = new PersistentData();

        if(persistentData.TryLoadFromJSON(PersistentData.DataPath, out List<InventoryItem> list))
        {
            Debug.Log("Создаем не новые");
            Inventory inventory = new Inventory(list);
            _inventory = inventory;
        }
        else
        {
            Debug.Log("Создаем новые");
            list = new List<InventoryItem>();
            foreach (var item in _items)
            {
                list.Add(new InventoryItem(item, item.Capacity));
            }

            Inventory inventory = new Inventory(list);
            persistentData.SaveToJSON(PersistentData.DataPath, list);
            _inventory = inventory;
        }

        Container.Bind<Inventory>().FromInstance(_inventory).AsSingle();
        Container.Bind<PersistentData>().FromInstance(persistentData).AsSingle();
    }


    private void BindPlayer()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_gamePlaySceneContainer.PlayerPrefab, _playerPosition.position, Quaternion.identity, null);
        Container.Bind<IFollowed>().To<Player>().FromInstance(player).AsSingle();
        Container.Bind<IShootable>().To<Shooter>().FromInstance(player.Shooter).AsSingle();    
    }
}
