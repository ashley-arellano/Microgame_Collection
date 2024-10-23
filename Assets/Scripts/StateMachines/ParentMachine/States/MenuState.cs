using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using UnityEngine.Playables;

public class MenuState : BaseState
{
    
   // private MenuStateMachine menuStateMachine;

    private bool onStart = true; 
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["MenuState"]; 
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        //will write a conditon using context later
        //When Game is first launched, go to main menu
        if (onStart){
            onStart = false;
            gameStateMachine.GameStateContext.States.CurrentSubState = 
                gameStateMachine.GameStateContext.States.StatesDict["MainMenuState"];

            gameStateMachine.GameStateContext.States.CurrentSubState.EnterState(gameStateMachine);
        }
        else if(gameStateMachine.GameStateContext.States.CurrentSuperState.GetType() == typeof(PlayState)){
            gameStateMachine.SwitchState(gameStateMachine.GameStateContext.States.CurrentSuperState);
        }

        //will have to figure out how to handle the below:
            //When player returns from story via win/lose/exit, go to 
            //add some check using context
        
    }
   
    

}
