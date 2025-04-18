using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;
        public SceneLoader(ICoroutineRunner coroutineRunner) => _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null )
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded)
        {
            
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded.Invoke();
                yield break;
            }
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);
            
            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            onLoaded.Invoke();
        }
    }
}