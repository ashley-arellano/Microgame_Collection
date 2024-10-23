using System;

// Used to mediate information about whether a level is selected (in story mode) in LevelSelectMenuState
// OR to mediate information about whether a minigame is selected (in freeplay mode) in TBAState
// by triggering events to GameStateMachine

//GameSelection
public class GameSelectionMediator
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
  
