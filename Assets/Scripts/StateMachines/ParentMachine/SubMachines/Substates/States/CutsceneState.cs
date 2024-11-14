
// Concrete class of GameStateMachine (hierarchical state machine)
public class CutsceneState : BaseState
{
    // Called when exiting the cutscene state
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        // Set the last sub-state to CutsceneState
        gameStateMachine.GameStateContext.States.LastSubState =
                 gameStateMachine.GameStateContext.States.StatesDict["CutsceneState"]; 
        // Unload the cutscene scene (to be implemented)
    }

    // Called when entering the cutscene state
    public override void EnterState(GameStateMachine gameStateMachine)
    {
        // Set the current sub-state to CutsceneState
        gameStateMachine.GameStateContext.States.CurrentSubState =
                 gameStateMachine.GameStateContext.States.StatesDict["CutsceneState"]; 
        // Load the cutscene scene (to be implemented)
        
        // Immediately transition to the PlayMinigamesState for testing
        MoveToGame(gameStateMachine);
    }

    // Temporary method for testing transitions, moves to the PlayMinigamesState
    private void MoveToGame(GameStateMachine gameStateMachine)
    {
        gameStateMachine.SwitchSubState(gameStateMachine.GameStateContext.States.StatesDict["PlayMinigamesState"]);
    }
}
