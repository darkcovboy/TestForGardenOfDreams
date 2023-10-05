using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private ICoroutineRunner _runner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        _runner = coroutineRunner;
    }

    public void Load(string name, Action onLoaded) => _runner.StartCoroutine(LoadScene(name, onLoaded));

    private IEnumerator LoadScene(string name, Action onLoaded)
    {
        /*
        if(SceneManager.GetActiveScene().name == name)
        {
            onLoaded?.Invoke();
            yield break;
        }
        */

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

        while (!waitNextScene.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}
