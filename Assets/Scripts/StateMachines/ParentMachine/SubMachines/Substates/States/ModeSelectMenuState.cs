using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Concrete class of GameStateMachine (hierarchical state machine)
public class ModeSelectMenuState : BaseState 
{
    // Dictionary to hold buttons in the mode selection menu
    private Dictionary<string, Button> modeSelectButtons = new Dictionary<string, Button>();

    // Called when exiting the mode selection state
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        // Set last substate to ModeSelectMenuState and unload the ModeSelectUI scene
        gameStateMachine.GameStateContext.States.LastSubState =
            gameStateMachine.GameStateContext.States.StatesDict["ModeSelectMenuState"]; 
        gameStateMachine.SceneHandler.OnUnloadScene("ModeSelectUI");
    }

    // Called when entering the mode selection state
    public override void EnterState(GameStateMachine gameStateMachine)
    {
        // Set current substate to ModeSelectMenuState and load ModeSelectUI scene with setup
        gameStateMachine.GameStateContext.States.CurrentSubState = 
            gameStateMachine.GameStateContext.States.StatesDict["ModeSelectMenuState"];
        gameStateMachine.SceneHandler.OnLoadScene("ModeSelectUI", () => SetUpState(gameStateMachine));
    }

    // Sets up mode selection UI and initializes buttons after scene is loaded
    public void SetUpState(GameStateMachine gameStateMachine)
    {
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();

        if (uIMenuElements == null) 
        {
            Debug.LogError("uIMenuElements not found!");
            return;
        }

        // Retrieve button references
        modeSelectButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(gameStateMachine);
    }

    // Adds listeners to mode selection buttons
    private void InitializeButtons(GameStateMachine gameStateMachine) 
    {
        modeSelectButtons["StoryMode"].onClick.AddListener(() => StoryModeSelected(gameStateMachine));
        modeSelectButtons["Options"].onClick.AddListener(() => OptionsSelected(gameStateMachine));
        modeSelectButtons["FreePlay"].onClick.AddListener(() => FreePlaySelected(gameStateMachine));
    }

    // Handles Story Mode selection
    private void StoryModeSelected(GameStateMachine gameStateMachine)
    {
        gameStateMachine.SwitchSubState(
            gameStateMachine.GameStateContext.States.StatesDict["LevelSelectMenuState"]);
    }

    // Handles Options selection
    private void OptionsSelected(GameStateMachine gameStateMachine)
    {
        gameStateMachine.SwitchSubState(
            gameStateMachine.GameStateContext.States.StatesDict["OptionsMenuState"]);
    }

    // Handles Free Play selection (currently a placeholder)
    private void FreePlaySelected(GameStateMachine gameStateMachine)
    {
        Debug.Log("TBA: FreePlay");
    }
}
