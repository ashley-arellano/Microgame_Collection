using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
   private static IEnumerator LoadNewScene (string newSceneName, System.Action setUpWrapper = null){
        var asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone){
            Debug.Log("Loading the Scene"); 
            yield return null;
        }
         Debug.Log("Scene Loaded"); 
        setUpWrapper?.Invoke();
        
    }
   public void OnLoadScene(string newSceneName, string oldSceneName, System.Action setUpWrapper = null){
      if(oldSceneName !=  null){
         //Unload
         SceneManager.UnloadSceneAsync(oldSceneName);
      }
      StartCoroutine(LoadNewScene(newSceneName, setUpWrapper));
   }

}
