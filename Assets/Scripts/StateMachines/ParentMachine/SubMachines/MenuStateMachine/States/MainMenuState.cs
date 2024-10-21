using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenuState : BaseMenuState
{
    
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();

    public override void EnterState(MenuStateMachine menuStateMachine) {
        // Load the scene and setup once it’s ready, passing the menuStateMachine using a lambda
        menuStateMachine.SceneHandler.OnLoadScene("MainMenuUI", () => SetUpState(menuStateMachine));
    }


    public override void UpdateState(MenuStateMachine menuStateMachine) {
        // Empty or just polling-based actions if needed
    }

    public override void DestroyState(MenuStateMachine menuStateMachine) {
        // Unload the scene when leaving the state
        menuStateMachine.SceneHandler.OnUnloadScene("MainMenuUI");
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
        mainMenuButtons["quitButton"].onClick.AddListener(ExitGame);
        mainMenuButtons["playButton"].onClick.AddListener(() => StartGame(menuStateMachine));
    }

    private void ExitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void StartGame(MenuStateMachine menuStateMachine) {
        // Transition to the next state
        Debug.Log("Moving to LevelSelectUI");
        menuStateMachine.SwitchState(menuStateMachine.MenuStates.LevelSelectMenuState);
    }


    /*private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();
    private bool startGame = false;
    private bool exitGame = false;
    private bool canSetUp = false;
    public override void EnterState(GameStateMachine gameStateMachine){
       //Will eventuall call SetUp to setup the state
        gameStateMachine.SceneHandler.OnLoadScene("MainMenuMode",SetUpWrapper);
    }
    public override void UpdateState(GameStateMachine gameStateMachine){
        ///changes to current state
        ///if else for changing to next state
        ///
        if(canSetUp){
            SetUpState(gameStateMachine);
        }
        //need to add //remove all listeners code
        if(startGame){
           // gameStateMachine.SwitchState(gameStateMachine.States.LevelSelectState);
        }

        if(exitGame){
            Debug.Log("Quit");
            Application.Quit();
        }
        
    }
    public override void DestroyState(GameStateMachine gameStateMachine){
        ///wraps things up
        gameStateMachine.SceneHandler.OnUnloadScene("MainMenuMode");
       // gameStateMachine.SceneHandler.OnLoadScene("LevelSelectMode");
    }
    
    public override void SetUpWrapper(){
        canSetUp = true;
    }

    public override void SetUpState(GameStateMachine gameStateMachine){
        canSetUp = false;
        gameStateMachine.UIMenuElements = GameObject.FindWithTag("ButtonPanel").GetComponent<UIMenuElements>();
        
        if(gameStateMachine.UIMenuElements !=  null){
           // instaniatedButtons = gameStateMachine.UIMenuElements.InstaniateAllButtons();
           mainMenuButtons = gameStateMachine.UIMenuElements.ButtonPrefabDic;  
           mainMenuButtons["quitButton"].onClick.AddListener(() => exitGame = true);
           mainMenuButtons["playButton"].onClick.AddListener(() => startGame = true);
        }
    }*/
}
