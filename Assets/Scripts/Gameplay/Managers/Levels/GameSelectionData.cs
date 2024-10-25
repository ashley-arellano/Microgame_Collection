using System;


//GameSelectionData
public class GameSelectionData
{
    private string selectedMinigameID; 

    private string selectedLevelID;

    public string SelectedMinigameID
    {
        get => selectedMinigameID;
        set{ selectedMinigameID = value;}
    }

    public string SelectedLevelID
    {
        get => selectedLevelID;
        set{ selectedLevelID = value;}
    }
}
  
