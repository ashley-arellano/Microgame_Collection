using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


// public class SceneHandler : MonoBehaviour
// {
//    private static IEnumerator LoadNewScene (string newSceneName, System.Action setUpWrapper = null){
//         var asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
//         while (!asyncLoad.isDone){
//             Debug.Log("Loading the Scene"); 
//             yield return null;
//         }
//         Debug.Log("Scene Loaded"); 
//         setUpWrapper?.Invoke();
        
//     }
//    public void OnLoadScene(string newSceneName, System.Action setUpWrapper = null){
//       StartCoroutine(LoadNewScene(newSceneName, setUpWrapper));
//    }

//    public void OnUnloadScene(string oldSceneName){
//       //Unload
//       SceneManager.UnloadSceneAsync(oldSceneName);
//    }

// }
