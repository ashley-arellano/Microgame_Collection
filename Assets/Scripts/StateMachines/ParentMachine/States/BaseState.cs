

//abstract state of fsm
public abstract class BaseState 
{
   public abstract void EnterState(GameStateMachine gameStateMachine);
  
   public abstract void DestroyState(GameStateMachine gameStateMachine );
}
