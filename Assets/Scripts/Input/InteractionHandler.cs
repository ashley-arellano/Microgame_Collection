using UnityEngine;

//Script attached to interactable object with its interface script
public class InteractionHandler : MonoBehaviour
{
    private InputHandler inputHandler;
    private IInteractable interactedObj;
    private bool isClicked;
    private void Start(){
        interactedObj = null;
        inputHandler = GetComponent<InputHandler>();
    }
    private void FixedUpdate()
    {
        while(isClicked){
            isClicked = false;
         
            Collider2D hit = Physics2D.OverlapCircle(inputHandler.ClickInput, radius: 0.1f);
            //Check what was hit 
            if(hit != null){
                Debug.Log("Hit!");
                //Use the hit variable to determine what was clicked on.
                interactedObj = hit.gameObject.GetComponent<IInteractable>();
                //If the object is interactable, trigger the interaction
                if (interactedObj != null){
                    interactedObj.OnInteract();
                }
            }
        }  
    }

    private void Update()
    {   
        //Updates check if the player has clicked interctable object
       if (inputHandler.IsClicked){
            isClicked = true;
        }
    }
}