using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class MenuState : BaseState
{
    private MenuStateMachine menuStateMachine;
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
       menuStateMachine.ExitState();
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        if(menuStateMachine == null){
            menuStateMachine = new MenuStateMachine(gameStateMachine.SceneHandler);
        }
        menuStateMachine.Initialize();
    }


    public override void UpdateState(GameStateMachine gameStateMachine)
    {
        menuStateMachine.UpdateState();
    }
}
