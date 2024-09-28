using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
        //User Interaction
        clickPositionAction = playerInput.actions["ClickPosition"];
        clickAction = playerInput.actions["Interact"];
    }

    private void Start(){
        clickInput= new Vector2();
    }

    private void Update(){
        //User Interaction via click
        
        isClicked = clickAction.triggered;
        //gets the position of where the mouse click happened
        clickInput = clickPositionAction.ReadValue<Vector2>();
        
    }

}