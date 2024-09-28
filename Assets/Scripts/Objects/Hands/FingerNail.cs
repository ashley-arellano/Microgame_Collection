using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//finger nails will be prefabs lol
//just with different sprites
public class FingerNail : MonoBehaviour, IInteractable
{
    private bool isPainted;
    //default non-painted finger sprite (attached to same object)
    private SpriteRenderer spriteRenderer;
    //Painted finger sprite
    [SerializeField]
    private Sprite newSprite;
    //will be called by hand to see if all fingers are painted
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
    

    private void ChangeSprite(){
        spriteRenderer.sprite = newSprite; 
    }
}
