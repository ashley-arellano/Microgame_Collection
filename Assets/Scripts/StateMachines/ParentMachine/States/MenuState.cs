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
        }else{
            //three ways to enter menu state 
                //from the start
                //after exiting play state
                    //player would be placed in levelselect or minigame select
                //after exiting pause state
                    //player would be placed in levelselect or minigame select
                    //meaning the last state would need to be recorded :(
                    //possible solution is by making an observer pattern 
                    //and replace my laststate variable in options too if i do this
                    //or i could just add a laststate variable in menustate for now
                    //and depending how the statemachine grows
                    //i could consider the observer pattern
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
