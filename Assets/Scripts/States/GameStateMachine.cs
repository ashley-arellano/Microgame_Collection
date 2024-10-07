using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//context of fsm
//only script to add to ui state
public class GameStateMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject stateMachine;
    private void Awake()
    {
        DontDestroyOnLoad(stateMachine);
    }
    private BaseState currentState;
    public UIMenuElements UIMenuElements{
        get {return uIMenuElements;} 
    }
    
    [SerializeField]
    private UIMenuElements uIMenuElements;
    public States States {
        get {return states;} 
    }
    //Reference to all states
    private States states;
    // Start is called before the first frame update
    void Start()
    {
        states = new States();
        //starting state for game state machine
        currentState = states.MainMenuState;
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
        if (currentState != null)
        {
            currentState.DestroyState();
        }
        currentState = state;
        currentState.EnterState(this);
    }
}
