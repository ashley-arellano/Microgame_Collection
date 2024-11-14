using UnityEngine;
using System.Collections.Generic;

// ScriptableObject representing a level, containing level-specific data and references to minigame collections
[CreateAssetMenu(fileName = "LevelScriptableObject", 
                 menuName = "ScriptableObjects/LevelScriptableObject")]
public class LevelScriptableObject : ScriptableObject
{
    // Property for getting or setting the unique identifier of the level
    public string LevelID {
        get { return levelID; }
        set { levelID = value; }
    }
    
    // Serialized field to store the unique ID of the level
    [SerializeField]
    private string levelID;

    // Property for getting the number of speed-up intervals in the level
    public int SpeedUpIntervals {
        get { return speedUpIntervals; }
    }

    // Serialized field to store the number of speed-up intervals in the level
    private int speedUpIntervals;

    // Property for getting the minigame collection associated with this level
    public MinigameCollectionScriptableObject MinigameList {
        get { return minigameList; }
    }

    // Serialized field for storing a reference to a minigame collection for this level
    [SerializeField]
    private MinigameCollectionScriptableObject minigameList;
}
