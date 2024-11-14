using System;
using UnityEngine;


//Class that holds mutable data related to the player's selected game mode,
// either Freeplay or Story mode
public class GameSelectionData: MonoBehaviour
{
    //Stores the ID of the minigame selected by the player in Freeplay mode.
    private string selectedMinigameID; 
    // Stores the ID of the level selected by the player in Story mode.
    private string selectedLevelID;
    
    // Gets or sets the ID of the selected minigame. 
    // Used when the player chooses Freeplay mode.
    public string SelectedMinigameID
    {
        get => selectedMinigameID;
        set{ selectedMinigameID = value;}
    }
    // Gets or sets the ID of the selected level. 
    // Used when the player chooses Story mode.
    public string SelectedLevelID
    {
        get => selectedLevelID;
        set{ selectedLevelID = value;}
    }
}
  
