
public class MenuState : BaseState
{
    public override void DestroyState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.LastSuperState =
                 gameStateMachine.GameStateContext.States.StatesDict["MenuState"]; 
    }

    public override void EnterState(GameStateMachine gameStateMachine)
    {
        gameStateMachine.GameStateContext.States.CurrentSuperState = 
            gameStateMachine.GameStateContext.States.StatesDict["MenuState"];
        //will write a conditon using context later

        //When Game is first launched, go to main menu
        if (gameStateMachine.GameStateContext.States.LastSuperState == null
            && gameStateMachine.GameStateContext.States.LastSubState == null){

            gameStateMachine.GameStateContext.States.StatesDict["MainMenuState"].EnterState(gameStateMachine);
        }
        
    }

}
