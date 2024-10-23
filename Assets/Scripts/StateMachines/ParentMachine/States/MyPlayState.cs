using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        
        gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["MyPlayState"]; 

        gameStateMachine.SceneHandler.OnUnloadScene("GameSystem");
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.CurrentSuperState =
                 gameStateMachine.GameStateContext.States.StatesDict["MyPlayState"];

        if(gameStateMachine.GameStateContext.States.LastState.GetType() == typeof(LevelSelectMenuState) )
        {
             // Load the scene and setup once it’s ready, passing the menuStateMachine using a lambda
             Debug.Log("Insert Cutscene: Not Done yet");

            //Go into cutscene state
             gameStateMachine.GameStateContext.States.StatesDict["CutsceneState"].EnterState(gameStateMachine);

        }
        //else if freeplay logic


        //else if typeof(PlayMinigamesState), load that state
        
    }


}
