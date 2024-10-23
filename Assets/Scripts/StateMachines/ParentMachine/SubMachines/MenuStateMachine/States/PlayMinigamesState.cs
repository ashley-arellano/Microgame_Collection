public class PlayMinigamesState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.LastState =
                 gameStateMachine.GameStateContext.States.StatesDict["PlayMinigamesState"]; 
        //UnloadScene
        gameStateMachine.SceneHandler.OnUnloadScene("GameSystem");
    }


    public override void EnterState(GameStateMachine gameStateMachine)
    {
        // Load the scene
         // Load the scene and setup once it’s ready, passing the gameStateMachine using a lambda
        gameStateMachine.SceneHandler.OnLoadScene("GameSystem");

    }


}