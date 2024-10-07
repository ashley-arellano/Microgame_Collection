using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//concrete state of fsm
public class LevelSelectState : BaseState
{
    //Scene should be LevelSelectState
    // private Button playButton;
    // private Button quitButton;
    public override void EnterState(GameStateMachine gameStateMachine){
        // if(gameStateMachine.UIMenuElements == null){
        //     Debug.Log("null");
        // }
        // if(gameStateMachine.UIMenuElements.Button1 != null){
        //     playButton = gameStateMachine.UIMenuElements.InstaniateButton(gameStateMachine.UIMenuElements.Button1);
        // }
        // if(gameStateMachine.UIMenuElements.Button2 != null){
        //     quitButton = gameStateMachine.UIMenuElements.InstaniateButton(gameStateMachine.UIMenuElements.Button2);
        // }
    }
    public override void UpdateState(GameStateMachine gameStateMachine){

    }
    public override void DestroyState(){

    }
}
