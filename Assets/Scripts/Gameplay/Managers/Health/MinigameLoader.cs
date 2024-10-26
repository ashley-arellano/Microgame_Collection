using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


public class MinigameLoader
{
    private TimerManager timerManager;
    private List<MinigameScriptableObject> minigameList;
    private List<int> availableIndices = new List<int>();

    private System.Random randomIndex = new System.Random();

    public MinigameLoader(TimerManager timerManager, List<MinigameScriptableObject> minigameList){
        this.timerManager = timerManager;
        this.minigameList = minigameList;
        RandomizeMinigame(minigameList.Count);
    }

    //Two points of when triggered:
    //1. Loading first minigame in SetUp()
    //2. Loading minigame when times up
    public string LoadMinigame(){
        //Using first index, load minigame
        int index = availableIndices[0];
        //Remove first index from list
        availableIndices.RemoveAt(0); 
        return minigameList[index].MinigameName;
    }

    private void RandomizeMinigame(int size){
        // List to store indices for each item in minigameList
        availableIndices = Enumerable.Range(0, size).ToList();
        //Randomize the order of indices
        availableIndices = availableIndices.OrderBy(x => randomIndex.Next()).ToList();
    }
}
