using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//concrete state of fsm
public class LevelSelectMenuState : BaseMenuState
{

    private Dictionary<string, Button> levelSelectButtons = new Dictionary<string, Button>();

    public override void EnterState(MenuStateMachine menuStateMachine) {
        // Load the scene and setup once it’s ready, passing the menuStateMachine using a lambda
        menuStateMachine.SceneHandler.OnLoadScene("LevelSelectUI", () => SetUpState(menuStateMachine));
    }

    public override void DestroyState(MenuStateMachine menuStateMachine) {
        // Unload the scene when leaving the state
        menuStateMachine.SceneHandler.OnUnloadScene("LevelSelectUI");
    }

    public override void SetUpState(MenuStateMachine menuStateMachine) {
        var uIMenuElements = GameObject.FindWithTag("ButtonPanel")?.GetComponent<UIMenuElements>();
        if (uIMenuElements == null) {
            Debug.LogError("uIMenuElements not found!");
            return; // Make sure 'return' is lowercase
        }

        levelSelectButtons = uIMenuElements.ButtonPrefabDic;
        InitializeButtons(menuStateMachine);
    }

    private void InitializeButtons(MenuStateMachine menuStateMachine) {
        // mainMenuButtons["quitButton"].onClick.AddListener(ExitGame);
        // mainMenuButtons["playButton"].onClick.AddListener(() => StartGame(menuStateMachine));
        string temp = "";
        for(int i = 0; i < levelSelectButtons.Count; i++){
            temp = (i + 1).ToString();
            if(levelSelectButtons.ContainsKey(temp)) {
                //lambda holds a reference to the variable so using another 
                //variable to hold value to avoid issues of reference changing to 
                //incorrect value
                string tempCopy = temp;
                levelSelectButtons[temp].onClick.AddListener(() => LevelSelect(tempCopy,menuStateMachine));
            }
        }
        //add whenever i actually add it to ui*
        //levelSelectButtons["Options"].onClick.AddListener(() => OptionSSelected(menuStateMachine));
    }

    private void LevelSelect(string levelNumber, MenuStateMachine menuStateMachine){
        // Set the current selection to Level (story mode)
        menuStateMachine.GameSelectionMediator.CurrentSelection = GameSelection.Level;
        // Set the selected level ID, which will trigger the event
        menuStateMachine.GameSelectionMediator.SelectedGameID = levelNumber;
        //Destroy state
        DestroyState(menuStateMachine);
    }

}

