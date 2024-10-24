using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "MinigameScriptableObject", 
//menuName = "ScriptableObjects/Minigame")]
public class MinigameScriptableObject : ScriptableObject
{
    private string minigameName;
    private string minigameDescription;
    private string category;
    private Sprite previewImage;

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
}
