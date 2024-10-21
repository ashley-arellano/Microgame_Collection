using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//context of fsm
//only script to add to ui state
public class GameStateMachine : MonoBehaviour
{
    public SceneHandler SceneHandler{ 
        get{return sceneHandler;}  
    }
    [SerializeField]
    private SceneHandler sceneHandler;
    private BaseState currentState;
    public UIMenuElements UIMenuElements{
        get {return uIMenuElements;} set{uIMenuElements = value;}
    }
    
    private UIMenuElements uIMenuElements;
    public States States {
        get {return states;} 
    }
    //Reference to all states
    private States states;

    // Start is called before the first frame update
    void Start()
    {
        //temp for now; going to add scene handler which will have a thing
        //that subcribes to when a new scene is loaded and done being loaded
        //and this will be the function that is called for it***

        //uIMenuElements = GameObject.FindWithTag("ButtonPanel").GetComponent<UIMenuElements>();
        states = new States();
        //starting state for game state machine
        currentState = states.MenuState;
        //"this" is a reference to the context (this exact script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null){
            currentState.UpdateState(this);
        }
        
    }
    //transition through states
    public void SwitchState(BaseState state){
        // If we currently have state, then destroy it
        if (currentState != null){
            currentState.DestroyState(this);
        }
        currentState = state;
        currentState.EnterState(this);
    }
    // /uIMenuElements = GameObject.FindWithTag("ButtonPanel").GetComponent<UIMenuElements>();
}
