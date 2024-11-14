using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
// Concrete class of GameStateMachine (hierarchical state machine)
public class MainMenuState : BaseState 
{
    // Dictionary to store references to main menu buttons
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();

    // Called when entering the main menu state
    public override void EnterState(GameStateMachine gameStateMachine) {
        // Set the current sub-state to MainMenuState
        gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["MainMenuState"];
        // Load the main menu UI scene and set up the state once it's ready
        gameStateMachine.SceneHandler.OnLoadScene("MainMenuUI", () => SetUpState(gameStateMachine));
    }

    // Called when exiting the main menu state
    public override void DestroyState(GameStateMachine gameStateMachine) {
        // Update last sub-state to MainMenuState
        gameStateMachine.GameStateContext.States.LastSubState =
                 gameStateMachine.GameStateContext.States.StatesDict["MainMenuState"]; 
        // Unload the main menu UI scene
        gameStateMachine.SceneHandler.OnUnloadScene("MainMenuUI");
    }

    // Sets up the main menu state by finding and storing the button elements
    public void SetUpState(GameStateMachine gameStateMachine) {
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();

        if (uIMenuElements == null) {
            Debug.LogError("Button panel not found!");
            return;
        }

        // Store the button elements in the dictionary
        mainMenuButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(gameStateMachine);
    }

    // Initializes button functionality for the main menu
    private void InitializeButtons(GameStateMachine gameStateMachine) {
        mainMenuButtons["quitButton"].onClick.AddListener(ExitGame);  // Quit button
        mainMenuButtons["playButton"].onClick.AddListener(() => StartGame(gameStateMachine));  // Play button
    }

    // Exits the game when the quit button is clicked
    private void ExitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Starts the game by transitioning to the ModeSelectMenuState
    private void StartGame(GameStateMachine gameStateMachine) {
        Debug.Log("Moving to ModeSelectUI");
        gameStateMachine.SwitchSubState(gameStateMachine.GameStateContext.States.StatesDict["ModeSelectMenuState"]);
    }
}

