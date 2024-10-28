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
        //User Interaction
        clickPositionAction = playerInput.actions["ClickPosition"];
        clickAction = playerInput.actions["Interact"];
    }

    private void Start(){
        clickInput= new Vector2();
    }

    private void Update(){
        try {
            //Debug.Log("in update");
        isClicked = clickAction.triggered;
        //clickInput = clickPositionAction.ReadValue<Vector2>();
        } catch (Exception e) {
            Debug.LogError($"Error handling input: {e.Message}");
        }
        
    }

}