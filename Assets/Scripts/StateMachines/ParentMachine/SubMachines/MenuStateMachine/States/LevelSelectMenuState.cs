using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//concrete state of fsm
public class LevelSelectMenuState : BaseState 
{

    private Dictionary<string, Button> levelSelectButtons = new Dictionary<string, Button>();

    public override void EnterState(GameStateMachine gameStateMachine) {
        gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["LevelSelectMenuState"];
        // Load the scene and setup once it’s ready, passing the gameStateMachine using a lambda
        gameStateMachine.SceneHandler.OnLoadScene("LevelSelectUI", () => SetUpState(gameStateMachine));
    }

    public override void DestroyState(GameStateMachine gameStateMachine) {
        gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["LevelSelectMenuState"]; 
        // Unload the scene when leaving the state
        gameStateMachine.SceneHandler.OnUnloadScene("LevelSelectUI");
    }

    public void SetUpState(GameStateMachine gameStateMachine) {
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();
        if (uIMenuElements == null) {
            Debug.LogError("uIMenuElements not found!");
            return; // Make sure 'return' is lowercase
        }

        levelSelectButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(gameStateMachine);
    }

    private void InitializeButtons(GameStateMachine gameStateMachine) {
        string temp = "";
        for(int i = 0; i < levelSelectButtons.Count; i++){
            temp = (i + 1).ToString();
            if(levelSelectButtons.ContainsKey(temp)) {
                //lambda holds a reference to the variable so using another 
                //variable to hold value to avoid issues of reference changing to 
                //incorrect value
                string tempCopy = temp;
                levelSelectButtons[temp].onClick.AddListener(() => LevelSelect(tempCopy,gameStateMachine));
            }
        }
    }

    private void LevelSelect(string levelNumber, GameStateMachine gameStateMachine){
        // Save levelNumber
        gameStateMachine.GameStateContext.GameSelectionMediator.SelectedLevelID = levelNumber;

        gameStateMachine.GameStateContext.States.CurrentSubState = null;
          //  gameStateMachine.GameStateContext.States.StatesDict["CutsceneState"];

        //or do i have it go back to menu then to play??????????
        gameStateMachine.SwitchState(
            gameStateMachine.GameStateContext.States.StatesDict["PlayState"]);//or should i switch to parent first?
    }
}

