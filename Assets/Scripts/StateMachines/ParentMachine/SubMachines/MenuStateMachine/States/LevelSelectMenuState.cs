using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//concrete state of fsm
public class LevelSelectMenuState : BaseMenuState
{
    // //Scene should be LevelSelectState
    // private bool canSetUp = false;

    // private Dictionary<string, Button> levelSelectButtons = new Dictionary<string, Button>();
    // public override void EnterState( MenuStateMachine menuStateMachine){
    //     menuStateMachine.SceneHandler.OnLoadScene("LevelSelectMode", SetUpWrapper);
    // }
    // public override void UpdateState(GameStateMachine gameStateMachine){
    //     if(canSetUp){
    //         SetUpState(gameStateMachine);
    //     }
    // }
    // public override void DestroyState(GameStateMachine gameStateMachine){
    //     ///wraps things up
    //     //gameStateMachine.SceneHandler.OnLoadScene(selectedLevel,"LevelSelectMode");
    //     gameStateMachine.SceneHandler.OnUnloadScene("LevelSelectMode");
    // }
    //  public override void SetUpWrapper(){
    //     canSetUp = true;
    // }
    // public override void SetUpState( MenuStateMachine menuStateMachine){
    //     canSetUp = false;
    //     gameStateMachine.UIMenuElements = GameObject.FindWithTag("ButtonPanel").GetComponent<UIMenuElements>();

    //     if(gameStateMachine.UIMenuElements !=  null){
    //          levelSelectButtons = gameStateMachine.UIMenuElements.ButtonPrefabDic;
    //          string temp = "";
    //          for(int i = 0; i < levelSelectButtons.Count; i++){
    //             temp = (i + 1).ToString();
    //             if(levelSelectButtons.ContainsKey(temp)) {
    //                 //lambda holds a reference to the variable so using another 
    //                 //variable to hold value to avoid issues of reference changing to 
    //                 //incorrect value
    //                 string tempCopy = temp;
    //                 levelSelectButtons[temp].onClick.AddListener(() => LevelSelect(tempCopy,menuStateMachine));
    //             }
    //          }
    //     }
    // }
    // //so, levelNumber is empty not sure why
    // private void LevelSelect(string levelNumber, MenuStateMachine menuStateMachine){
    //     //need to add 
    //     //not sure if remove listners are needed since they will be moving to next scene
    //     switch(levelNumber){
    //         case "1":
    //             Debug.Log("Level 1");
    //             //gameStateMachine.SwitchState(gameStateMachine.States.LevelOneState);
    //             break;
    //         case "2":
    //             Debug.Log("Level 2");
    //            // gameStateMachine.SwitchState(gameStateMachine.States.LevelTwoState);
    //             break;
    //         case "3":
    //             Debug.Log("not implement yet");
    //             break;
    //         default:
    //             Debug.Log("no valid");
    //             break;
    //     }

    // }
    public override void DestroyState(MenuStateMachine menuStateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(MenuStateMachine menuStateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void SetUpState(MenuStateMachine menuStateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void SetUpWrapper()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MenuStateMachine menuStateMachine)
    {
        throw new System.NotImplementedException();
    }
}
