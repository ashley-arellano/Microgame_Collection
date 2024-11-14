using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

//Class that manages minigame loading
public class MinigameLoader: MonoBehaviour
{
    private TimerData timerData;
    private SceneHandler sceneHandler;
    private List<MinigameScriptableObject> minigameList;
    private string currentMinigameID;
    //Used to store which minigames have not yet been played yet in the list of given minigames
    private List<int> availableIndices = new List<int>();
    private System.Random randomIndex = new System.Random();
    //Integer that signifies when to 'speed up' (or rather to reduce the timer of minigame) 
    //after nth minigame has been beated in level
    private int speedUpIntervals;
    //How much to speed-up level
    private int speedFactor = 1;
    //Function that retrieves needed references
    public void SetUp(List<MinigameScriptableObject> minigameList, int speedUpIntervals, TimerData timerData){
        sceneHandler = GetComponent<SceneHandler>();
        this.minigameList = minigameList;
        this.speedUpIntervals = speedUpIntervals;
        this.timerData = timerData;
        RandomizeMinigame(minigameList.Count);
    }

    //Loads minigame from the list of minigames
    public void LoadMinigame(){
        //if there are still mingames to load
        if(availableIndices.Count != 0){
            //Retrieve minigame list's index
            int index = availableIndices[0];
            //Remove index from the available minigame list
            availableIndices.RemoveAt(0); 
            //Get minigame from list via index
            MinigameScriptableObject minigame = minigameList[index];

            //Speedup at intervals for StoryMode
            if (speedUpIntervals != 0){
                UpdateTimerDataStoryMode(minigame, minigameList.Count);
            }
            //TBA: Code for Freeplay Speedup after every boss

            //Get name of new minigame scene
            string oldMinigameID = currentMinigameID;
            currentMinigameID = minigame.MinigameName;

            //Pass an anonymous function that calls UnloadCurrentMinigame with the oldMinigameID
            //to load new minigame and unload current minigame
            sceneHandler.OnLoadScene(currentMinigameID, () => UnloadCurrentMinigame(oldMinigameID));
        }else{
            //Debug Code: After all minigames are loaded for level, return back to levelSelect menu
            sceneHandler.OnLoadScene("LevelSelectUI");
            sceneHandler.OnUnloadScene(currentMinigameID);
        }
    }

    //Updates the current timer data based on minigame for story mode
    public void UpdateTimerDataStoryMode(MinigameScriptableObject minigame, int numberOfLevels){
        //Change TimerData based on minigame
        timerData.TimeRemaining = minigame.TimeToComplete;
        //Excluding boss levels (which is when the level 'speeds up')
        if((numberOfLevels-1) % speedUpIntervals == 1){
            speedFactor++;
            timerData.SpeedFactor = speedFactor;
        }
    }
    //Unload the current minigame scene
    public void UnloadCurrentMinigame(string oldMinigameID){
        if(oldMinigameID != null){
            //Unload current minigame
            sceneHandler.OnUnloadScene(oldMinigameID);
        }
    }
    //Randomize the list of minigames
    private void RandomizeMinigame(int size){
        // List to store indices for each item in minigameList except the last one (boss stage is always last)
        availableIndices = Enumerable.Range(0, size - 1).ToList();
        // Randomize the order of indices
        availableIndices = availableIndices.OrderBy(x => randomIndex.Next()).ToList();
        // Add the last index at the end
        availableIndices.Add(size - 1);
    }

}
