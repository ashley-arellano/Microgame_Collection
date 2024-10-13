using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//concrete state of fsm
public class LevelSelectState : BaseState
{
    //Scene should be LevelSelectState
    private bool canSetUp = false;
    private string selectedLevel;
  
    private Dictionary<string, Button> levelSelectButtons = new Dictionary<string, Button>();
    public override void EnterState(GameStateMachine gameStateMachine){
        gameStateMachine.SceneHandler.OnLoadScene("LevelSelectMode", SetUpWrapper);
    }
    public override void UpdateState(GameStateMachine gameStateMachine){
        if(canSetUp){
            SetUpState(gameStateMachine);
        }
    }
    public override void DestroyState(GameStateMachine gameStateMachine){
        ///wraps things up
        //gameStateMachine.SceneHandler.OnLoadScene(selectedLevel,"LevelSelectMode");
        gameStateMachine.SceneHandler.OnUnloadScene("LevelSelectMode");
    }
     public override void SetUpWrapper(){
        canSetUp = true;
    }
    public override void SetUpState(GameStateMachine gameStateMachine){
         gameStateMachine.UIMenuElements = GameObject.FindWithTag("ButtonPanel").GetComponent<UIMenuElements>();
        
        if(gameStateMachine.UIMenuElements !=  null){
             levelSelectButtons = gameStateMachine.UIMenuElements.ButtonPrefabDic;
             string temp = "";
             for(int i = 0; i < levelSelectButtons.Count; i++){
                temp += i+1;
                levelSelectButtons[temp].onClick.AddListener(() => LevelSelect(temp));
                temp = "";
             }
            //  levelSelectButtons["Level1"].onClick.AddListener(() => Debug.Log("Level 1 clicked"));
            // levelSelectButtons["Level2"].onClick.AddListener(() => Debug.Log("Level 2 clicked"));
            // levelSelectButtons["Level3"].onClick.AddListener(() => Debug.Log("Level 3 clicked"));
        }
    }
    //so, levelNumber is empty not sure why
    private void LevelSelect( string levelNumber){
        //need to add //remove all listeners code
        Debug.Log(levelNumber);
        switch(levelNumber){
            case "1":
                Debug.Log("Level 1");
                //gameStateMachine.SwitchState(gameStateMachine.States.LevelOneState);
                break;
            case "2":
                Debug.Log("Level 2");
               // gameStateMachine.SwitchState(gameStateMachine.States.LevelTwoState);
                break;
            case "3":
                Debug.Log("not implement yet");
                break;
            default:
                Debug.Log("no valid");
                break;
        }
        
    }
}
