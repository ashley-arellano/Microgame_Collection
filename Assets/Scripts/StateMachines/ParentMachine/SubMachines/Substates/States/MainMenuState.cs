using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenuState : BaseState 
{
    
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();

    public override void EnterState(GameStateMachine gameStateMachine) {
        gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["MainMenuState"];
        // Load the scene and setup once it’s ready, passing the gameStateMachine using a lambda
        gameStateMachine.SceneHandler.OnLoadScene("MainMenuUI", () => SetUpState(gameStateMachine));
    }

    public override void DestroyState(GameStateMachine gameStateMachine) {
        // Unload the scene when leaving the state
        gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["MainMenuState"]; 
                 
        gameStateMachine.SceneHandler.OnUnloadScene("MainMenuUI");
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
        mainMenuButtons["quitButton"].onClick.AddListener(ExitGame);
        mainMenuButtons["playButton"].onClick.AddListener(() => StartGame(gameStateMachine));
    }

    private void ExitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void StartGame(GameStateMachine gameStateMachine) {
        // Transition to the next state
        Debug.Log("Moving to ModeSelectUI");
        

        gameStateMachine.SwitchState(gameStateMachine.GameStateContext.States.CurrentSubState);
    }

}
