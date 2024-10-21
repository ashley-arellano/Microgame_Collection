using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    //Reference to all states
    private MenuStates states;
    private BaseMenuState currentState;
     // Start is called before the first frame update
    void Start()
    {
        states = new MenuStates();
        //starting state for game state machine
        currentState = states.MainMenuState;
        //"this" is a reference to the context (this exact script)
        currentState.EnterState(this);
    }
    void Update()
    {
        if(currentState != null){
            currentState.UpdateState(this);
        }
        
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
}
