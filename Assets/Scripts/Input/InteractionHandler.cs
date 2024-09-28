using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//so goes together on interactable object with its respective inheritance script
public class InteractionHandler : MonoBehaviour
{
    [SerializeField]
    private InputHandler inputHandler;
    private IInteractable interactedObj;
    private bool isClicked;
    private void Start(){
        interactedObj = null;
    }
    private void FixedUpdate()
    {
        while(isClicked){
         
            Collider2D hit = Physics2D.OverlapCircle(inputHandler.ClickInput, radius: 0.1f);
            //Check what was hit 
            if(hit != null){
                // Use the hit variable to determine what was clicked on.
                interactedObj = hit.gameObject.GetComponent<IInteractable>();
                // If the object is interactable, trigger the interaction
                if (interactedObj != null){
                    interactedObj.OnInteract();
                }
            }
        }  
    }

    private void Update()
    {
       if (inputHandler.IsClicked){
            isClicked = true;
        }
    }
}
  // Create a ray into the screen at the position of the mouse pointer.
           // Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Physics2D.OverlapPoint could used instead, if i don't care about radius