using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private MinigameScriptableObject minigameTemplate; // Template object to instantiate


    
    //List of minigames apart of the 'Party' Category
    public List<MinigameScriptableObject> PartyMinigames{
        get {return partyMinigames;}
    }
    private List<MinigameScriptableObject> partyMinigames;

    private void Awake()
    {
        // Initialize the list and create instances using collection initializer syntax
        partyMinigames = new List<MinigameScriptableObject>
        {
            CreateMinigame("Poppin' Rush", "Pop the balloons before they leave the screen", "Party", null),
            CreateMinigame("Snip and Shine", "Cut the folded paper along the dotted lines", "Party", null),
        };
    }

    private MinigameScriptableObject CreateMinigame(string minigameName, string minigameDescription, string category, Sprite previewImage)
    {
        // Instantiate the template MinigameScriptableObject
        MinigameScriptableObject newMinigame = Object.Instantiate(minigameTemplate);
        
        // Set the unique values for this instance
        newMinigame.MinigameName =  minigameName;
        newMinigame.MinigameDescription = minigameDescription;
        newMinigame.Category = category;
        newMinigame.PreviewImage = previewImage;
        
        return newMinigame;
    }
}
