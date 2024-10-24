using UnityEngine;
using System.Collections.Generic;

// [CreateAssetMenu(fileName = "LevelScriptableObject", 
//menuName = "ScriptableObjects/Level")]
public class Level1ScriptableObject : ScriptableObject
{
    public string LevelID
    {
        get{ return levelID;}
    }
    private string levelID;

    public List<MinigameScriptableObject> MinigameList{
        get{return minigameList;}
    }
    //Minigame list
    //Which is just a List of Scenes to reference
    //either the name of scenes
    //or their own scriptable objects?
    private List<MinigameScriptableObject> minigameList = new List<MinigameScriptableObject>(){
        
    };

    public bool IsLocked
    {
        get{ return isLocked;}
        set{isLocked = value;}
    }

    private bool isLocked = true;

}
