using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    private static IEnumerator LoadNewScene(string newSceneName, System.Action onSceneLoaded = null) {
        var asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone) {
            Debug.Log("Loading the Scene");
            yield return null;
        }
        Debug.Log("Scene Loaded");
        onSceneLoaded?.Invoke();
    }

    public void OnLoadScene(string newSceneName, System.Action onSceneLoaded = null) {
        StartCoroutine(LoadNewScene(newSceneName, onSceneLoaded));
    }

    public void OnUnloadScene(string oldSceneName) {
        SceneManager.UnloadSceneAsync(oldSceneName);
    }
}


