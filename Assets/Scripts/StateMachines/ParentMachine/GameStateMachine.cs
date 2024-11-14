using UnityEngine;

//context of hierarchical state machine
//Handles the current state of the game (menu, play, pause)
public class GameStateMachine : MonoBehaviour
{
   
    public SceneHandler SceneHandler{ 
        get{return sceneHandler;}  
    }
    [SerializeField]
    private SceneHandler sceneHandler;
    public GameSelectionData GameSelectionData{
        get{return gameSelectionData;}
    }
    private GameSelectionData gameSelectionData;

    public GameStateContext GameStateContext{
        get{return gameStateContext;}
    }
    //Reference to all states
    private GameStateContext gameStateContext;
    

    // Start is called before the first frame update
    void Start()
    {
        
        gameStateContext = new GameStateContext();
        gameSelectionData = GameObject.FindWithTag("DataHolder").GetComponent<GameSelectionData>();

        //starting states for game state machine
        gameStateContext.States.CurrentSubState = null;
        gameStateContext.States.LastSubState = null;
        gameStateContext.States.LastSuperState = null;

        //enter state
        gameStateContext.States.StatesDict["MenuState"].EnterState(this);
    }

    public void SwitchSuperState(BaseState state){
        // If we currently have state, then destroy it
        //Current State is Parent State
        if(gameStateContext.States.CurrentSuperState != null){
                gameStateContext.States.CurrentSuperState.DestroyState(this);
        }
        state.EnterState(this);
    }

    public void SwitchSubState(BaseState state){
        // If we currently have state, then destroy it
        //Current State is Child State
        if (gameStateContext.States.CurrentSubState != null){
            gameStateContext.States.CurrentSubState.DestroyState(this);
        }
        
        state.EnterState(this);
    }
   
}
