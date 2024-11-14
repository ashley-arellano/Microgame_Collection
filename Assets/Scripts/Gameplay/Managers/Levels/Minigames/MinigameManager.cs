// using System.Collections.Generic;
// using UnityEngine;

// public class MinigameManager : MonoBehaviour
// {
//     //will do getcomponent as well
//     [SerializeField] private MinigameScriptableObject minigameTemplate; // Template object to instantiate

//     //List of minigames apart of the 'Party' Category
//     public List<MinigameScriptableObject> PartyMinigames{
//         get {return partyMinigames;}
//     }
//     private List<MinigameScriptableObject> partyMinigames;

//     private void Awake()
//     {
//         // Initialize the list and create instances using collection initializer syntax
//         partyMinigames = new List<MinigameScriptableObject>
//         {
//             CreateMinigame("Poppin' Rush", "Pop the balloons before they leave the screen", "Party", null, 4),
//             CreateMinigame("Snip and Shine", "Cut the folded paper along the dotted lines", "Party", null, 4),
//         };
//     }

//     private MinigameScriptableObject CreateMinigame(string minigameName, string minigameDescription,
//          string category, Sprite previewImage, float timeToComplete)
//     {
//         // Instantiate the template MinigameScriptableObject
//         MinigameScriptableObject newMinigame = Object.Instantiate(minigameTemplate);
        
//         // Set the unique values for this instance
//         newMinigame.MinigameName =  minigameName;
//         newMinigame.MinigameDescription = minigameDescription;
//         newMinigame.Category = category;
//         newMinigame.PreviewImage = previewImage;
//         newMinigame.TimeToComplete = timeToComplete;
        
//         return newMinigame;
//     }
// }
