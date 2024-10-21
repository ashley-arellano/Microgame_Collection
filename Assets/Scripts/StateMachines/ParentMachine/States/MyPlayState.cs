using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.SceneHandler.OnUnloadScene("GameSystem");
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
         // Load the scene and setup once it’s ready, passing the menuStateMachine using a lambda
        gameStateMachine.SceneHandler.OnLoadScene("GameSystem");
    }

   

    public override void UpdateState(GameStateMachine gameStateMachine)
    {
        
    }
}
