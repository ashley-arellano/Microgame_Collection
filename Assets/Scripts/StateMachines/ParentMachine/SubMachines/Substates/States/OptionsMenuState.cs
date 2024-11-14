using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Concrete class of GameStateMachine (hierarchical state machine)
public class OptionsMenuState : BaseState 
{
    //Dictionary to hold buttons in the options menu
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();

    //Called when entering the options menu state
    public override void EnterState(GameStateMachine gameStateMachine) 
    {
        //Set the current substate to OptionsMenuState
        gameStateMachine.GameStateContext.States.CurrentSubState = 
            gameStateMachine.GameStateContext.States.StatesDict["OptionsMenuState"];
        
        //Load the OptionsMenuUI scene and run setup once loaded
        gameStateMachine.SceneHandler.OnLoadScene("OptionsMenuUI", () => SetUpState(gameStateMachine));
    }

    //Called when exiting the options menu state
    public override void DestroyState(GameStateMachine gameStateMachine) 
    {
        //Set the last substate to OptionsMenuState
        gameStateMachine.GameStateContext.States.LastSubState =
            gameStateMachine.GameStateContext.States.StatesDict["OptionsMenuState"];   
        
        //Unload the OptionsMenuUI scene
        gameStateMachine.SceneHandler.OnUnloadScene("OptionsMenuUI");
    }

    //Sets up the options menu UI and initializes buttons after loading the scene
    public void SetUpState(GameStateMachine gameStateMachine) 
    {
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();

        if (uIMenuElements == null) 
        {
            Debug.LogError("Button panel not found!");
            return;
        }

        //Retrieve button references
        mainMenuButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(gameStateMachine);
    }

    //Adds listeners to buttons in the options menu
    private void InitializeButtons(GameStateMachine gameStateMachine) 
    {
        mainMenuButtons["Apply"].onClick.AddListener(ApplySettings);
        mainMenuButtons["Back"].onClick.AddListener(() => GoBackToLastState(gameStateMachine));
    }

    //Placeholder for applying settings action
    private void ApplySettings()
    {
        Debug.Log("TBA: Apply settings");
    }

    //Handles returning to the previous menu state
    private void GoBackToLastState(GameStateMachine gameStateMachine)
    {
        var lastStateType = gameStateMachine.GameStateContext.States.LastSubState.GetType();

        if (lastStateType == typeof(ModeSelectMenuState))
        {
            //Switch to the previous menu state
            gameStateMachine.SwitchSubState(gameStateMachine.GameStateContext.States.LastSubState);
        }
    }
}
