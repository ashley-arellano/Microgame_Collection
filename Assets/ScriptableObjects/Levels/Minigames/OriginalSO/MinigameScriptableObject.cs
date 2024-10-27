using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MinigameScriptableObject", 
menuName = "ScriptableObjects/MinigameScriptableObject")]
public class MinigameScriptableObject : ScriptableObject
{
    [SerializeField]
    private string minigameName;
    [SerializeField]
    private string minigameDescription;
    [SerializeField]
    private string category;
    [SerializeField]
    private Sprite previewImage;
    [SerializeField]
    private float timeToComplete;
    private bool isBoss;

    public float TimeToComplete{
        get { return timeToComplete; }
        set { timeToComplete = value; }
    }
    public string MinigameName{
        get{ return minigameName; }
        set{minigameName = value;}
    }

    public string MinigameDescription{
        get{ return minigameDescription; }
        set{minigameDescription = value;}
    }

    public Sprite PreviewImage{
        get{ return previewImage; }
        set{previewImage = value;}  
    }

    public string Category{
        get{ return category; }
        set{category = value;}
    }

    public bool IsBoss{
        get{ return isBoss; }
        set{ isBoss = value;}
    }


}
