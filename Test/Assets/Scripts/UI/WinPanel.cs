using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _button;

    private SceneLoaderService _loader;

    [Inject]
    public void Constructor(SceneLoaderService sceneLoaderService)
    {
        _loader = sceneLoaderService;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_loader.RestartLevel);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(_loader.RestartLevel);
    }
}
