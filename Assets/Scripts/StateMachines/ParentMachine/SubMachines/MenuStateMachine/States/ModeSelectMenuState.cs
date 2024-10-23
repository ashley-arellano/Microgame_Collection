using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectMenuState : BaseState 
{
    private Dictionary<string, Button> modeSelectButtons = new Dictionary<string, Button>();
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        // Unload the scene when leaving the state
        gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["ModeSelectMenuState"]; 
        gameStateMachine.SceneHandler.OnUnloadScene("ModeSelectUI");
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        // Load the scene and setup once it’s ready, passing the gameStateMachine using a lambda
        gameStateMachine.SceneHandler.OnLoadScene("ModeSelectUI", () => SetUpState(gameStateMachine));
    }

    public void SetUpState(GameStateMachine gameStateMachine)
    {
        
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();
        if (uIMenuElements == null) {
            Debug.LogError("uIMenuElements not found!");
            return; // Make sure 'return' is lowercase
        }

        modeSelectButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(gameStateMachine);
    }

    private void InitializeButtons(GameStateMachine gameStateMachine) {
        modeSelectButtons["StoryMode"].onClick.AddListener(() => StoryModeSelected(gameStateMachine));
        modeSelectButtons["Options"].onClick.AddListener(() => OptionsSelected(gameStateMachine));
        modeSelectButtons["FreePlay"].onClick.AddListener(() => FreePlaySelected(gameStateMachine));
    }

    private void StoryModeSelected(GameStateMachine gameStateMachine){

         gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["LevelSelectMenuState"];

        gameStateMachine.SwitchState(
            gameStateMachine.GameStateContext.States.CurrentSubState);
    }
    private void OptionsSelected(GameStateMachine gameStateMachine){

        gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["OptionsMenuState"];

        gameStateMachine.SwitchState(gameStateMachine.GameStateContext.States.CurrentSubState);
        
    }
    private void FreePlaySelected(GameStateMachine gameStateMachine){
        Debug.Log("TBA: FreePlay");
    }
}
