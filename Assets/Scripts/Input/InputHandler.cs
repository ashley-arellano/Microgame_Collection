using UnityEngine;
using UnityEngine.InputSystem;
using System;

//Handles input received from the player, including mouse clicks and their positions.
public class InputHandler : MonoBehaviour
{
    //Reference to the Player Input component that maps player input actions.
    [SerializeField]
    private PlayerInput playerInput; 
    //Input action for detecting click events.
    private InputAction clickAction;
    //Input action for detecting the position of the click
    private InputAction clickPositionAction;
    //Stores the position of the player's click in screen space.
    private Vector2 clickInput;
    //Indicates whether the player has clicked.
    private bool isClicked;
  
    public Vector2 ClickInput{
        get{
            return clickInput;}
        private set{clickInput=value;}
    }
    public bool IsClicked{
        get{return isClicked;}
        private set{isClicked=value;}
    }
    private void Awake(){
        //User Interaction (Default Map is Player)
        //Initializes input actions for clicking and click position.
        clickPositionAction = playerInput.actions["Point"];
        clickAction = playerInput.actions["Click"];
    }

    private void Start(){
        clickInput= new Vector2();
    }

    private void Update(){
       //Updates whether the click action was triggered and stores the position.
        isClicked = clickAction.triggered;
        clickInput = clickPositionAction.ReadValue<Vector2>();
        
    }

}