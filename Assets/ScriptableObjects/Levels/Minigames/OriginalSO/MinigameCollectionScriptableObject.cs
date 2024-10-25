using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MinigameCollectionScriptableObject",
 menuName = "ScriptableObjects/MinigameCollectionScriptableObject")]
public class MinigameCollectionScriptableObject : ScriptableObject
{
    [SerializeField]
    private List<MinigameScriptableObject> minigameList;

    public List<MinigameScriptableObject> MinigameList {
        get { return minigameList; }
    }

    public string Category{
        get { return category; }
    }
    [SerializeField]
    private string category;
}
