//Concrete class of GameStateMachine (hierarchical state machine)
public class PlayMinigamesState : BaseState
{
    // Method to handle the destruction of this state
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        // Set the last active substate to PlayMinigamesState in the state dictionary
        gameStateMachine.GameStateContext.States.LastSubState =
            gameStateMachine.GameStateContext.States.StatesDict["PlayMinigamesState"];

        // Unload the "GameSystem" scene
        gameStateMachine.SceneHandler.OnUnloadScene("GameSystem");
    }

    // Method to handle entering this state
    public override void EnterState(GameStateMachine gameStateMachine)
    {
        // Set the current active substate to PlayMinigamesState in the state dictionary
        gameStateMachine.GameStateContext.States.CurrentSubState =
            gameStateMachine.GameStateContext.States.StatesDict["PlayMinigamesState"];

        // Load the "GameSystem" scene
        gameStateMachine.SceneHandler.OnLoadScene("GameSystem");
    }
}
