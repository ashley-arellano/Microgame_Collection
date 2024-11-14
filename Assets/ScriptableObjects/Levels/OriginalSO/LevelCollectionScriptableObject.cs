using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ScriptableObject for holding a collection of levels, used to manage a group of levels
[CreateAssetMenu(fileName = "LevelCollectionScriptableObject",
                 menuName = "ScriptableObjects/LevelCollectionScriptableObject")]
public class LevelCollectionScriptableObject : ScriptableObject
{
    // Serialized list of level scriptable objects, exposed in the Unity editor
    [SerializeField]
    private List<LevelScriptableObject> levelList;

    // Public property to access the list of levels
    public List<LevelScriptableObject> LevelList {
        get { return levelList; }
    }
}
