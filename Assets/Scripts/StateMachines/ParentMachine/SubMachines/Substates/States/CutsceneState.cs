public class CutsceneState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.LastSubState =
                 gameStateMachine.GameStateContext.States.StatesDict["CutsceneState"]; 
        //UnloadScene
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.CurrentSubState =
                 gameStateMachine.GameStateContext.States.StatesDict["CutsceneState"]; 
        // Load the scene
        MoveToGame(gameStateMachine);

    }

    //for now, for testing
    private void MoveToGame(GameStateMachine gameStateMachine){
       
        gameStateMachine.SwitchSubState(gameStateMachine.GameStateContext.States.StatesDict["PlayMinigamesState"]);
    }

}