using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "MinigameScriptableObject", 
//menuName = "ScriptableObjects/Minigame")]
public class MinigameScriptableObject : ScriptableObject
{
    private string levelName;
    private string levelDescription;
    private string category;
    private Sprite previewImage;

    public string LevelName{
        get{ return levelName; }
        set{levelName = value;}
    }

    public string LevelDescription{
        get{ return levelDescription; }
        set{levelDescription = value;}
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
