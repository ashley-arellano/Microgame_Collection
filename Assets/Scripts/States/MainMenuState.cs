using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//concrete state of fsm
//Scene should be MainMenuMode
public class MainMenuState : BaseState 
{
    private Button playButton;
    private Button quitButton;
    private bool startGame;
    private bool exitGame;
    public override void EnterState(GameStateMachine gameStateMachine){
        startGame = false;
        exitGame = false;

        if(gameStateMachine.UIMenuElements == null){
            Debug.Log("null");
        }
        if(gameStateMachine.UIMenuElements.Button1 != null){
            playButton = gameStateMachine.UIMenuElements.InstaniateButton(gameStateMachine.UIMenuElements.Button1);
        }
        if(gameStateMachine.UIMenuElements.Button2 != null){
            quitButton = gameStateMachine.UIMenuElements.InstaniateButton(gameStateMachine.UIMenuElements.Button2);
        }

        playButton.onClick.AddListener(() => startGame = true);
        quitButton.onClick.AddListener(() => exitGame = true);
        //inital state
        //should call elsewhere to pull UI
        //so will use prefab instance of ui
        //will have to store all of them in one place
        //rare time with i could use singleton design in a good way
        //ui menus should only have one instance of
    }
    public override void UpdateState(GameStateMachine gameStateMachine){
        ///changes to current state
        ///if else for changing to next state
        ///
        if(startGame){
            gameStateMachine.SwitchState(gameStateMachine.States.PlayState);
        }

        if(exitGame){
            Application.Quit();
        }
        
    }
    public override void DestroyState(){
        ///wraps things up
        SceneManager.LoadScene("GameMode", LoadSceneMode.Single);
    }
    
}
