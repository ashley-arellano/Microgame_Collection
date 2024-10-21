using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuState : BaseMenuState
{
    //Getting the last state before options
    public string LastStateBeforeOptions{
        set{ lastStateBeforeOptions = value; }
    }
    private string lastStateBeforeOptions;
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();

    public override void EnterState(MenuStateMachine menuStateMachine) {
        // Load the scene and setup once it’s ready, passing the menuStateMachine using a lambda
        menuStateMachine.SceneHandler.OnLoadScene("OptionsMenuUI", () => SetUpState(menuStateMachine));
    }

    public override void DestroyState(MenuStateMachine menuStateMachine) {
        // Unload the scene when leaving the state
        menuStateMachine.SceneHandler.OnUnloadScene("OptionsMenuUI");
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

    //has to be fixed

    private void GoBackToLastState(MenuStateMachine menuStateMachine){

        switch(lastStateBeforeOptions){
            case "ModeSelect":
                menuStateMachine.SwitchState(menuStateMachine.MenuStates.ModeSelectMenuState);
                break;
            case "PauseMenu":
                //menuStateMachine.SwitchState(menuStateMachine.MenuStates.PauseMenuState);
                Debug.Log("TBA: PauseMenu last state");
                break;
            default:
                break;
        }
        DestroyState(menuStateMachine);
    }

}
