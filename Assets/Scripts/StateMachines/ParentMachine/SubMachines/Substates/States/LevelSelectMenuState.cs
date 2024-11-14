using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Concrete class of GameStateMachine (hierarchical state machine)
public class LevelSelectMenuState : BaseState 
{
    // Dictionary to store references to level select buttons
    private Dictionary<string, Button> levelSelectButtons = new Dictionary<string, Button>();

    // Called when entering the level select state
    public override void EnterState(GameStateMachine gameStateMachine) {
        // Set the current sub-state to LevelSelectMenuState
        gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["LevelSelectMenuState"];
        // Load the level select UI scene and set up the state once it's ready
        gameStateMachine.SceneHandler.OnLoadScene("LevelSelectUI", () => SetUpState(gameStateMachine));
    }

    // Called when exiting the level select state
    public override void DestroyState(GameStateMachine gameStateMachine) {
        // Update last sub-state to LevelSelectMenuState
        gameStateMachine.GameStateContext.States.LastSubState =
                 gameStateMachine.GameStateContext.States.StatesDict["LevelSelectMenuState"];
        // Unload the level select UI scene
        gameStateMachine.SceneHandler.OnUnloadScene("LevelSelectUI");
    }

    // Sets up the level select state by finding and storing button elements
    public void SetUpState(GameStateMachine gameStateMachine) {
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();
        if (uIMenuElements == null) {
            Debug.LogError("uIMenuElements not found!");
            return; 
        }

        // Store the button elements in the dictionary
        levelSelectButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(gameStateMachine);
    }

    // Initializes button functionality for each level select button
    private void InitializeButtons(GameStateMachine gameStateMachine) {
        string temp = "";
        for (int i = 0; i < levelSelectButtons.Count; i++) {
            temp = (i + 1).ToString();
            if (levelSelectButtons.ContainsKey(temp)) {
                // Using a separate variable to avoid capturing the loop variable (temp) by reference
                string tempCopy = temp;
                levelSelectButtons[temp].onClick.AddListener(() => LevelSelect(tempCopy, gameStateMachine));
            }
        }
    }

    // Called when a level is selected; transitions to the PlayState
    private void LevelSelect(string levelNumber, GameStateMachine gameStateMachine) {
        Debug.Log("Inside LevelSelect");
        // Save the selected level number
        gameStateMachine.GameSelectionData.SelectedLevelID = levelNumber;

        // Reset the current sub-state
        gameStateMachine.GameStateContext.States.CurrentSubState = null;
        // Destroy the current sub-state
        DestroyState(gameStateMachine);
        // Switch to the PlayState as the new super state
        gameStateMachine.SwitchSuperState(
            gameStateMachine.GameStateContext.States.StatesDict["PlayState"]);
    }
}


