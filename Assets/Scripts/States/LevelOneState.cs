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
        gameStateMachine.SceneHandler.OnLoadScene("LevelOne", SetUpWrapper);
    }

    public override void SetUpState(GameStateMachine gameStateMachine)
    {   
        canSetUp = false;
        //gameStateMachine.UIMenuElements = .GetComponent<UIMenuElements>();
        
        

    }

    public override void SetUpWrapper()
    {
        canSetUp = true;
    }

    private void SetActivePauseMenu(){

    }
    private void SetInactivePauseMenu(){
        
    }

    public override void UpdateState(GameStateMachine gameStateMachine)
    {
        if(canSetUp){
            SetUpState(gameStateMachine);
        }
    }
}
