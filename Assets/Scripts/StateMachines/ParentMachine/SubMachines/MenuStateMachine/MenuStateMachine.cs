using System;
public class MenuStateMachine 
{

    public MenuStates MenuStates{
        get{ return menuStates; }
    }
    public SceneHandler SceneHandler{ 
        get{return sceneHandler;}  
    }
    
    public GameSelectionMediator GameSelectionMediator{
        get{return gameSelectionMediator;}
    }
    //Reference to all states
    private MenuStates menuStates;
    private BaseMenuState currentState;
    private SceneHandler sceneHandler;
    private GameSelectionMediator gameSelectionMediator;
   
   //Constructor
   public MenuStateMachine (SceneHandler sceneHandler, GameSelectionMediator gameSelectionMediator){
        this.sceneHandler = sceneHandler;
        this.gameSelectionMediator = gameSelectionMediator;
    }

    
    
     // Start is called before the first frame update
    public void Initialize()
    {
      
        menuStates = new MenuStates();
        //starting state for game state machine
        currentState = menuStates.MainMenuState;
        //"this" is a reference to the context (this exact script)
        currentState.EnterState(this);
    }
   
    //transition through states
    public void SwitchState(BaseMenuState state){
        // If we currently have state, then destroy it
        if (currentState != null){
            currentState.DestroyState(this);
        }
        currentState = state;
        currentState.EnterState(this);
    }

    //not sure if needed but for now
    public void ExitState(){
        if (currentState != null){
            currentState.DestroyState(this);
        }
    }
}
