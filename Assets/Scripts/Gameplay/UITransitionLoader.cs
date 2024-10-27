using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using the animator on a UI canvas "dirties" it even if nothing is going on because of 
the transform of the UI elements are being changed by the animator per frame; causing a 
recompute of all another elements in the same canvas which gets hairy in complex hierarchies. 
A good practice to improve performance is to make your scene transition in another canvas rather
 than the one in your UI and toggle on/off when needed.*/
public class UITransitionLoader : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
   
}
