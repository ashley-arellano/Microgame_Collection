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
    private bool startGame;
    private bool exitGame;
    public override void EnterState(GameStateMachine gameStateMachine){
        startGame = false;
        exitGame = false;
        if(gameStateMachine.UIMenuElements !=  null){
           // instaniatedButtons = gameStateMachine.UIMenuElements.InstaniateAllButtons();
           mainMenuButtons = gameStateMachine.UIMenuElements.ButtonPrefabDic;
            //Debug.Log(mainMenuButtons.Count);
        }
        
        mainMenuButtons["quitButton"].onClick.AddListener(() => exitGame = true);
        mainMenuButtons["playButton"].onClick.AddListener(() => startGame = true);

        //inital state
        //should call elsewhere to pull UI
        //so will use prefab instance of ui
        //will have to store all of them in one place
        //rare time with i could use singleton design in a good way
        //ui menus should only have one instance of
    }
    public override void UpdateState(GameStateMachine gameStateMachine){
        ///changes to current state
        ///if else for changing to next state
        ///
        if(startGame){
            gameStateMachine.SwitchState(gameStateMachine.States.LevelSelectState);
        }

        if(exitGame){
            Debug.Log("Quit");
            Application.Quit();
        }
        
    }
    public override void DestroyState(){
        ///wraps things up
        SceneManager.LoadScene("LevelSelectMode", LoadSceneMode.Single);
    }
    
}
