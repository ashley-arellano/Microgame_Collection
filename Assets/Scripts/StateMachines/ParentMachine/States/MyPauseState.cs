using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPauseState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        Debug.Log("Pause Destory: TBA");
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
         Debug.Log("Pause Enter: TBA");
    }

}
