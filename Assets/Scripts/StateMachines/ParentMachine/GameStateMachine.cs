using UnityEngine;

//context of hsm
//only script to add to ui state
public class GameStateMachine : MonoBehaviour
{
   
    public SceneHandler SceneHandler{ 
        get{return sceneHandler;}  
    }
    [SerializeField]
    private SceneHandler sceneHandler;
    // private BaseState currentState;
    public GameStateContext GameStateContext{
        get{return gameStateContext;}
    }
    //Reference to all states
    private GameStateContext gameStateContext;
    

    // Start is called before the first frame update
    void Start()
    {
        //temp for now; going to add scene handler which will have a thing
        //that subcribes to when a new scene is loaded and done being loaded
        //and this will be the function that is called for it***
        
        
        //gameSelectionMediator = new GameSelectionMediator();
        gameStateContext = new GameStateContext();

        //starting state for game state machine
       // currentState = gameStateContext.States.StatesDict["MenuState"];
        //gameStateContext.States.CurrentSuperState = currentState;
        gameStateContext.States.CurrentSubState = null;
        gameStateContext.States.LastSubState = null;
        gameStateContext.States.LastSuperState = null;

        //"this" is a reference to the context (this exact script)
        gameStateContext.States.StatesDict["MenuState"].EnterState(this);
    }

    //transition through states
    // public void SwitchState(BaseState state){
    //     // If we currently have state, then destroy it
    //     if (currentState != null){
    //         currentState.DestroyState(this);
    //     }
    //     currentState = state;
    //     currentState.EnterState(this);
    // }

    public void SwitchSuperState(BaseState state){
        // If we currently have state, then destroy it

        //Current State is Parent States
        if(gameStateContext.States.CurrentSuperState != null){
                gameStateContext.States.CurrentSuperState.DestroyState(this);
        }
        state.EnterState(this);
    }

    public void SwitchSubState(BaseState state){
        if (gameStateContext.States.CurrentSubState != null){
            gameStateContext.States.CurrentSubState.DestroyState(this);
        }
        
        state.EnterState(this);
    }
   
}



 // Update is called once per frame
    // void Update()
    // {
    //     if(currentState != null){
    //        currentState.UpdateState(this);
    //     }
        
    // }