using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuState : BaseMenuState
{
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();

    public override void EnterState(MenuStateMachine menuStateMachine) {
        // Load the scene and setup once it’s ready, passing the menuStateMachine using a lambda
        menuStateMachine.SceneHandler.OnLoadScene("PauseMenuUI", () => SetUpState(menuStateMachine));
    }


    public override void UpdateState(MenuStateMachine menuStateMachine) {
        // Empty or just polling-based actions if needed
    }

    public override void DestroyState(MenuStateMachine menuStateMachine) {
        // Unload the scene when leaving the state
        menuStateMachine.SceneHandler.OnUnloadScene("PauseMenuUI");
    }

    public override void SetUpState(MenuStateMachine menuStateMachine) {
        //we need another way to grab the buttons
        //maybe
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();

        if (uIMenuElements == null) {
            Debug.LogError("Button panel not found!");
            return;
        }

        mainMenuButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(menuStateMachine);
    }

    private void InitializeButtons(MenuStateMachine menuStateMachine) {
        mainMenuButtons["Apply"].onClick.AddListener(ApplySettings);
        mainMenuButtons["Back"].onClick.AddListener(() => GoBackToLastState(menuStateMachine));
    }

    private void ApplySettings(){
        Debug.Log("TBA: Apply settings");
        //do most games kick you out of it? idk

    }

    private void GoBackToLastState(MenuStateMachine menuStateMachine){
        //small problem
        //how to find which state called options menu
        //was it main menu, levelselect or pause?
        Debug.Log("TBA: GoBackToLastState");
        menuStateMachine.SwitchState(menuStateMachine.MenuStates.LevelSelectMenuState);
    }

}
