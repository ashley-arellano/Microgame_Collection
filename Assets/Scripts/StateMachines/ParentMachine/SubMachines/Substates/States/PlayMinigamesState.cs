
public class PlayMinigamesState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.LastSubState =
                 gameStateMachine.GameStateContext.States.StatesDict["PlayMinigamesState"]; 
        //UnloadScene
        gameStateMachine.SceneHandler.OnUnloadScene("GameSystem");
    }


    public override void EnterState(GameStateMachine gameStateMachine)
    {
        
         gameStateMachine.GameStateContext.States.CurrentSubState = 
            gameStateMachine.GameStateContext.States.StatesDict["PlayMinigamesState"];
        // Load the scene
         // Load the scene and setup once it’s ready, passing the gameStateMachine using a lambda
        gameStateMachine.SceneHandler.OnLoadScene("GameSystem");

    }


}