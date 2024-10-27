using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;



public class MinigameLoader: MonoBehaviour
{
   // private TimerManager timerManager;
   [SerializeField]
    private TimerData timerData;
    [SerializeField]
    private SceneHandler sceneHandler;
    private List<MinigameScriptableObject> minigameList;
    private string currentMinigameID;
    private List<int> availableIndices = new List<int>();
    private System.Random randomIndex = new System.Random();
    private int speedUpIntervals;
    private int speedFactor = 1;

    public void SetUp(List<MinigameScriptableObject> minigameList, int speedUpIntervals){
        this.minigameList = minigameList;
        this.speedUpIntervals = speedUpIntervals;
        RandomizeMinigame(minigameList.Count);
    }

    //Two points of when triggered:
    //1. Loading first minigame in SetUp()
    //2. Loading minigame when times up
    public void LoadMinigame(){
        if(availableIndices.Count != 0){
            //Using first index, load minigame
            int index = availableIndices[0];
            //Remove first index from list
            availableIndices.RemoveAt(0); 
            //Get minigame
            MinigameScriptableObject minigame = minigameList[index];

            //StoryMode Speedup at intervals
            if (speedUpIntervals != 0){
                UpdateTimerDataStoryMode(minigame, minigameList.Count);
            }
            //Freeplay Speedup after every boss

            //Get name of new minigame scene
            string oldMinigameID = currentMinigameID;
            currentMinigameID = minigame.MinigameName;

        // Pass an anonymous function that calls UnloadCurrentMinigame with the oldMinigameID
            sceneHandler.OnLoadScene(currentMinigameID, () => UnloadCurrentMinigame(oldMinigameID));
        }
    }

    public void UpdateTimerDataStoryMode(MinigameScriptableObject minigame, int numberOfLevels){
        //Change TimerData based on minigame
        //need to figure out when to add speed factor
        timerData.TimeRemaining = minigame.TimeToComplete;
        //Excluding boss level
        if((numberOfLevels-1) % speedUpIntervals == 1){
            speedFactor++;
            timerData.SpeedFactor = speedFactor;
        }
    }

    public void UnloadCurrentMinigame(string oldMinigameID){
        //Unload current minigame
        sceneHandler.OnUnloadScene(oldMinigameID);
    }

    private void RandomizeMinigame(int size){
        // List to store indices for each item in minigameList except the last one
        availableIndices = Enumerable.Range(0, size - 1).ToList();
        // Randomize the order of indices
        availableIndices = availableIndices.OrderBy(x => randomIndex.Next()).ToList();
        // Add the last index at the end
        availableIndices.Add(size - 1);
    }

}
