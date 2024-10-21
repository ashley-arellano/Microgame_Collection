using System;

// Used to mediate information about whether a level is selected (in story mode) in LevelSelectMenuState
// OR to mediate information about whether a minigame is selected (in freeplay mode) in TBAState
// by triggering events to GameStateMachine
public class GameSelectionMediator
{
    public event Action<string> OnGameSelectionChanged; // Added string for selected ID

    private GameSelection _currentSelection;
    private string _selectedGameID; // Variable to track selected level or minigame ID

    public GameSelection CurrentSelection
    {
        get => _currentSelection;
        set
        {
            if (_currentSelection != value)
            {
                _currentSelection = value;
            }
        }
    }

    public string SelectedGameID
    {
        get => _selectedGameID;
        set
        {
            if (_selectedGameID != value)
            {
                _selectedGameID = value;
                TriggerSelectionChanged(); // Notify listeners when the game ID changes
            }
        }
    }

    // Helper method to trigger the selection change event
    private void TriggerSelectionChanged()
    {
        OnGameSelectionChanged?.Invoke(_selectedGameID);
    }
}

public enum GameSelection
{
    None,
    Level,      // Story mode
    Minigame    // Freeplay mode
}
