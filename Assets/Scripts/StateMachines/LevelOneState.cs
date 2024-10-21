using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneState : BaseState
{
    private bool canSetUp = false;
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.SceneHandler.OnUnloadScene("LevelOne");
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        
    }

   

    private void SetActivePauseMenu(){

    }
    private void SetInactivePauseMenu(){
        
    }

    public override void UpdateState(GameStateMachine gameStateMachine)
    {
        
    }
}
