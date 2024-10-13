using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//concrete state of fsm
public class LevelSelectState : BaseState
{
    //Scene should be LevelSelectState
    private bool canSetUp = false;
    private Dictionary<string, Button> levelSelectButtons = new Dictionary<string, Button>();
    public override void EnterState(GameStateMachine gameStateMachine){
        gameStateMachine.SceneHandler.OnLoadScene("LevelSelectMode","MainMenuMode", SetUpWrapper);
    }
    public override void UpdateState(GameStateMachine gameStateMachine){
        if(canSetUp){
            SetUpState(gameStateMachine);
        }
    }
    public override void DestroyState(GameStateMachine gameStateMachine){

    }
     public override void SetUpWrapper(){
        canSetUp = true;
    }
    public override void SetUpState(GameStateMachine gameStateMachine){
         gameStateMachine.UIMenuElements = GameObject.FindWithTag("ButtonPanel").GetComponent<UIMenuElements>();
        
        if(gameStateMachine.UIMenuElements !=  null){
             levelSelectButtons = gameStateMachine.UIMenuElements.ButtonPrefabDic;
             levelSelectButtons["Level1"].onClick.AddListener(() => Debug.Log("Level 1 clicked"));
            levelSelectButtons["Level2"].onClick.AddListener(() => Debug.Log("Level 2 clicked"));
            levelSelectButtons["Level3"].onClick.AddListener(() => Debug.Log("Level 3 clicked"));
        }
    }
}
