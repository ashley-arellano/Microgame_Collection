using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelScriptableObject levelTemplate; // Template object to instantiate
    
    //List of Levels apart of the 'Party' Category
    public List<LevelScriptableObject> LevelList{
        get {return levelList;}
    }
    
    private List<LevelScriptableObject> levelList;
    private MinigameManager minigameManager;
    private void Start()
    {
        //Make sure that minigameManager is on the same gameobject as levelmanager!!!
       minigameManager = GetComponent<MinigameManager>();
        // Initialize the list and create instances using collection initializer syntax
        levelList = new List<LevelScriptableObject>
        {
            //TEMP: For now just pass the 'Party' minigames fo rlevel 1
            CreateLevel("1", minigameManager.PartyMinigames),
        };
    }

    private LevelScriptableObject CreateLevel(string levelName, List<MinigameScriptableObject> minigameList)
    {
        // Instantiate the template LevelScriptableObject
        LevelScriptableObject level = Object.Instantiate(levelTemplate);
        
        // Set the unique values for this instance
        level.LevelID = levelName;
        level.MinigameList = minigameList;
        
        return level;
    }
}
