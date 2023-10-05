using UnityEngine;
using Zenject;

public class SceneLoaderService : MonoBehaviour, ICoroutineRunner
{
    [SerializeField]
    private LoadingPanel _loadingPanel;

    public static SceneLoaderService Instance { get; private set; }

    private SceneLoader _sceneLoader;

    private readonly string _sceneLevelName = "Level";

    private void Start()
    {
        DontDestroyOnLoad(this);
        SceneLoader sceneLoader = new(this);
        _sceneLoader = sceneLoader;
        _loadingPanel.Show();
        Instance = this;
        _sceneLoader.Load(_sceneLevelName, _loadingPanel.Hide);
    }

    public void RestartLevel()
    {
        _loadingPanel.Show();
        _sceneLoader.Load(_sceneLevelName, _loadingPanel.Hide);
    }
}
