using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelScriptableObject", 
menuName = "ScriptableObjects/LevelScriptableObject")]
public class LevelScriptableObject : ScriptableObject
{
    public string LevelID
    {
        get{ return levelID;}
        set{ levelID = value;}
    }
    [SerializeField]
    private string levelID;

    public MinigameCollectionScriptableObject MinigameList{
        get{return minigameList;}
    }
   [SerializeField]
    private MinigameCollectionScriptableObject minigameList;


}
