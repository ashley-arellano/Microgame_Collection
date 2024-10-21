using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectMenuState : BaseMenuState
{
    private Dictionary<string, Button> modeSelectButtons = new Dictionary<string, Button>();
    public override void DestroyState(MenuStateMachine menuStateMachine)
    {
        // Unload the scene when leaving the state
        menuStateMachine.SceneHandler.OnUnloadScene("ModeSelectUI");
    }

    public override void EnterState(MenuStateMachine menuStateMachine)
    {
        // Load the scene and setup once it’s ready, passing the menuStateMachine using a lambda
        menuStateMachine.SceneHandler.OnLoadScene("ModeSelectUI", () => SetUpState(menuStateMachine));
    }

    public override void SetUpState(MenuStateMachine menuStateMachine)
    {
        
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();
        if (uIMenuElements == null) {
            Debug.LogError("uIMenuElements not found!");
            return; // Make sure 'return' is lowercase
        }

        modeSelectButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(menuStateMachine);
    }

    private void InitializeButtons(MenuStateMachine menuStateMachine) {
        modeSelectButtons["StoryMode"].onClick.AddListener(() => StoryModeSelected(menuStateMachine));
        modeSelectButtons["Options"].onClick.AddListener(() => OptionsSelected(menuStateMachine));
        modeSelectButtons["FreePlay"].onClick.AddListener(() => FreePlaySelected(menuStateMachine));
    }

    private void StoryModeSelected(MenuStateMachine menuStateMachine){
        menuStateMachine.SwitchState(menuStateMachine.MenuStates.LevelSelectMenuState);
    }
    private void OptionsSelected(MenuStateMachine menuStateMachine){
        menuStateMachine.MenuStates.OptionsMenuState.LastStateBeforeOptions = "ModeSelect";
        menuStateMachine.SwitchState(menuStateMachine.MenuStates.OptionsMenuState);
    }
    private void FreePlaySelected(MenuStateMachine menuStateMachine){
        Debug.Log("TBA: FreePlay");
    }
}
