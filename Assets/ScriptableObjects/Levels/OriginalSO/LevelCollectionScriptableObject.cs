using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelCollectionScriptableObject",
 menuName = "ScriptableObjects/LevelCollectionScriptableObject")]
public class LevelCollectionScriptableObject : ScriptableObject
{
    [SerializeField]
    private List<LevelScriptableObject> levelList;

    public List<LevelScriptableObject> LevelList {
        get { return levelList; }
    }
}
