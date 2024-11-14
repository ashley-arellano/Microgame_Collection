using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ScriptableObject representing a single minigame, containing relevant data for that minigame
[CreateAssetMenu(fileName = "MinigameScriptableObject", 
                 menuName = "ScriptableObjects/MinigameScriptableObject")]
public class MinigameScriptableObject : ScriptableObject
{
    // Serialized fields to store the minigame's properties
    [SerializeField]
    private string minigameName;         // Name of the minigame
    [SerializeField]
    private string minigameDescription;  // Description of the minigame
    [SerializeField]
    private string category;             // Category of the minigame 
    [SerializeField]
    private Sprite previewImage;         // Preview image of the minigame
    [SerializeField]
    private float timeToComplete;        // Time required to complete the minigame
    private bool isBoss;                 // Indicates if the minigame is a boss fight

    // Public property to access or modify the time required to complete the minigame
    public float TimeToComplete {
        get { return timeToComplete; }
        set { timeToComplete = value; }
    }

    // Public property to access or modify the name of the minigame
    public string MinigameName {
        get { return minigameName; }
        set { minigameName = value; }
    }

    // Public property to access or modify the description of the minigame
    public string MinigameDescription {
        get { return minigameDescription; }
        set { minigameDescription = value; }
    }

    // Public property to access or modify the preview image of the minigame
    public Sprite PreviewImage {
        get { return previewImage; }
        set { previewImage = value; }
    }

    // Public property to access or modify the category of the minigame
    public string Category {
        get { return category; }
        set { category = value; }
    }

    // Public property to access or modify if the minigame is a boss fight
    public bool IsBoss {
        get { return isBoss; }
        set { isBoss = value; }
    }
}
