using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: Fix code to current game system
public class FingerNail : MonoBehaviour, IInteractable
{
    private bool isPainted;
    //default non-painted fingernail sprite (attached to same object)
    private SpriteRenderer spriteRenderer;
    //Painted fingernail sprite
    [SerializeField]
    private Sprite newSprite;
    public bool IsPainted{
        get{return isPainted;}
    }
    // Start is called before the first frame update
    void Start()
    {
        isPainted = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnInteract(){
        if(!isPainted){
            //change sprite to painted fingernail
            ChangeSprite();
        }
        isPainted = true;
    }
    
    //assigns new sprite
    private void ChangeSprite(){
        spriteRenderer.sprite = newSprite; 
    }
}
