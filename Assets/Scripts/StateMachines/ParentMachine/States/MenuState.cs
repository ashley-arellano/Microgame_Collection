using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using UnityEngine.Playables;

public class MenuState : BaseState
{
    
   // private MenuStateMachine menuStateMachine;


    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["MenuState"]; 
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.CurrentSuperState = 
            gameStateMachine.GameStateContext.States.StatesDict["MenuState"];
        //will write a conditon using context later

        //When Game is first launched, go to main menu
        if (gameStateMachine.GameStateContext.States.LastState == null){
            

            gameStateMachine.GameStateContext.States.StatesDict["MainMenuState"].EnterState(gameStateMachine);
        }
        
    }

}
