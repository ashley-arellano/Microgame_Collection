using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

//concrete state of fsm
//Scene should be MainMenuMode
public class MainMenuState : BaseState 
{
    private Dictionary<string, Button> mainMenuButtons = new Dictionary<string, Button>();
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
            gameStateMachine.SwitchState(gameStateMachine.States.LevelSelectState);
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
        gameStateMachine.UIMenuElements = GameObject.FindWithTag("ButtonPanel").GetComponent<UIMenuElements>();
        
        if(gameStateMachine.UIMenuElements !=  null){
           // instaniatedButtons = gameStateMachine.UIMenuElements.InstaniateAllButtons();
           mainMenuButtons = gameStateMachine.UIMenuElements.ButtonPrefabDic;  
           mainMenuButtons["quitButton"].onClick.AddListener(() => exitGame = true);
           mainMenuButtons["playButton"].onClick.AddListener(() => startGame = true);
        }
    }


}
