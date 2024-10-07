using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//concrete state of fsm
public class LevelSelectState : BaseState
{
    //Scene should be LevelSelectState
    private Dictionary<string, Button> levelSelectButtons = new Dictionary<string, Button>();
    public override void EnterState(GameStateMachine gameStateMachine){
        if(gameStateMachine.UIMenuElements !=  null){
           levelSelectButtons = gameStateMachine.UIMenuElements.ButtonPrefabDic;
           Debug.Log("count"+levelSelectButtons.Count);
        }
        //testing purposes only
       levelSelectButtons["Level1"].onClick.AddListener(() => Debug.Log("Level 1 clicked"));
        levelSelectButtons["Level2"].onClick.AddListener(() => Debug.Log("Level 2 clicked"));
        levelSelectButtons["Level3"].onClick.AddListener(() => Debug.Log("Level 3 clicked"));
    }
    public override void UpdateState(GameStateMachine gameStateMachine){

    }
    public override void DestroyState(){

    }
}
