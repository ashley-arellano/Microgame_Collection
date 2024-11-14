
using UnityEngine;

public class MyPlayState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        
        gameStateMachine.GameStateContext.States.LastSuperState =
                 gameStateMachine.GameStateContext.States.StatesDict["PlayState"]; 

    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        Debug.Log("EnterState() PlayState");
        gameStateMachine.GameStateContext.States.CurrentSuperState =
                 gameStateMachine.GameStateContext.States.StatesDict["PlayState"];

        
        if(gameStateMachine.GameStateContext.States.LastSubState.GetType() == typeof(LevelSelectMenuState))
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
