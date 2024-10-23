using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuState : BaseState 
{
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();

    public override void EnterState(GameStateMachine gameStateMachine) {
         gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["OptionsMenuState"];
        // Load the scene and setup once it’s ready, passing the gameStateMachine using a lambda
        gameStateMachine.SceneHandler.OnLoadScene("OptionsMenuUI", () => SetUpState(gameStateMachine));
    }

    public override void DestroyState(GameStateMachine gameStateMachine) {
         gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["OptionsMenuState"];   
        // Unload the scene when leaving the state
        gameStateMachine.SceneHandler.OnUnloadScene("OptionsMenuUI");
    }

    public void SetUpState(GameStateMachine gameStateMachine) {
        //we need another way to grab the buttons
        //maybe
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();

        if (uIMenuElements == null) {
            Debug.LogError("Button panel not found!");
            return;
        }

        mainMenuButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(gameStateMachine);
    }

    private void InitializeButtons(GameStateMachine gameStateMachine) {
        mainMenuButtons["Apply"].onClick.AddListener(ApplySettings);
        mainMenuButtons["Back"].onClick.AddListener(() => GoBackToLastState(gameStateMachine));
    }

    private void ApplySettings(){
        Debug.Log("TBA: Apply settings");
        //do most games kick you out of it? idk

    }

    //has to be fixed

    private void GoBackToLastState(GameStateMachine gameStateMachine){


        var lastStateType = gameStateMachine.GameStateContext.States.LastState.GetType();

        if (lastStateType == typeof(ModeSelectMenuState))
        {
            // Handle ModeSelectMenuState
            gameStateMachine.SwitchState(gameStateMachine.GameStateContext.States.LastState);
        }
        else
        {
            // Handle other cases (default)
            Debug.Log("Not implemented: In OptionsMenuState");
        }

    }
    
}
