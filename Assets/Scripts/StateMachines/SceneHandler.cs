using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//Handles transitioning between scenes
public class SceneHandler : MonoBehaviour
{
    // Loads a new scene additively and calls onSceneLoaded when done
    private static IEnumerator LoadNewScene(string newSceneName, System.Action onSceneLoaded = null)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        
        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading the Scene");
            yield return null;
        }
        
        Debug.Log("Scene Loaded");
        onSceneLoaded?.Invoke(); // Invoke callback if provided
    }

    // Public method to start loading a new scene with an optional callback
    public void OnLoadScene(string newSceneName, System.Action onSceneLoaded = null)
    {
        StartCoroutine(LoadNewScene(newSceneName, onSceneLoaded));
    }

    // Unloads the specified scene
    public void OnUnloadScene(string oldSceneName)
    {
        SceneManager.UnloadSceneAsync(oldSceneName);
    }
}

