using System.Collections.Generic;
using UnityEngine;

// ScriptableObject for holding a collection of minigames, used to manage a group of minigames
[CreateAssetMenu(fileName = "MinigameCollectionScriptableObject",
                 menuName = "ScriptableObjects/MinigameCollectionScriptableObject")]
public class MinigameCollectionScriptableObject : ScriptableObject
{
    // Serialized list of minigame scriptable objects, exposed in the Unity editor
    [SerializeField]
    private List<MinigameScriptableObject> minigameList;

    // Public property to access the minigameList
    public List<MinigameScriptableObject> MinigameList {
        get { return minigameList; }
    }

    // Public property to access the category of minigames 
    public string Category {
        get { return category; }
    }

    // Serialized field to store the category string 
    [SerializeField]
    private string category;
}
