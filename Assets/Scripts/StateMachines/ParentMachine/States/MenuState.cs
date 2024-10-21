using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class MenuState : BaseState
{
    
    private MenuStateMachine menuStateMachine;

    private bool enterPlayState = false;
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        //should i do ????????????
        //menuStateMachine = null; 
       gameStateMachine.GameSelectionMediator.OnGameSelectionChanged -= OnGameSelected;
       menuStateMachine.ExitState();
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        if (menuStateMachine == null)
        {
            Debug.Log("Initalize MenuStateMachine");
            menuStateMachine = new MenuStateMachine(gameStateMachine.SceneHandler, gameStateMachine.GameSelectionMediator);
            menuStateMachine.Initialize();
        }
        gameStateMachine.GameSelectionMediator.OnGameSelectionChanged += OnGameSelected;
        
    }


    public override void UpdateState(GameStateMachine gameStateMachine)
    {
        
        if(enterPlayState){
            enterPlayState = false;
            gameStateMachine.SwitchState(gameStateMachine.States.MyPlayState);
        }
    }

    private void OnGameSelected(string selectedGameID)
    {
        enterPlayState = true;
    }
    

}
