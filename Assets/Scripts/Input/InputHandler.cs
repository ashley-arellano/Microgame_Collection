using UnityEngine;
using UnityEngine.InputSystem;
using System;


// This class handles interaction triggers with the player
public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput; 
    private InputAction clickAction;
    private InputAction clickPositionAction;
    
    private Vector2 clickInput;
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
        clickPositionAction = playerInput.actions["Point"];
        clickAction = playerInput.actions["Click"];
    }

    private void Start(){
        clickInput= new Vector2();
    }

    private void Update(){
       
        isClicked = clickAction.triggered;
        clickInput = clickPositionAction.ReadValue<Vector2>();
        
    }

}