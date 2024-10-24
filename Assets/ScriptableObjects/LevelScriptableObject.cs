using UnityEngine;
using System.Collections.Generic;

// [CreateAssetMenu(fileName = "LevelScriptableObject", 
//menuName = "ScriptableObjects/Level")]
public class LevelScriptableObject : ScriptableObject
{
    public string LevelID
    {
        get{ return levelID;}
        set{ levelID = value;}
    }
    private string levelID;

    public List<MinigameScriptableObject> MinigameList{
        get{return minigameList;}
        set{ minigameList = value;}
    }
   
    private List<MinigameScriptableObject> minigameList;


}
