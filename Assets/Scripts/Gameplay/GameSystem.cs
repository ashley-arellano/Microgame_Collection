using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//attached to a gameobject in scene GameSystem
//Handles the overall game system in play mode
public class GameSystem : MonoBehaviour
{
    private LevelLoader levelLoader;
    private MinigameLoader minigameLoader;
    
    private TimerManager timerManager;  
    private HealthManager healthManager;
    private LevelScriptableObject selectedLevel;
    private WinLoseData winLoseData;
    private TimerData timerData;
    
    //have to somehow get the same instance from hsm
    private GameSelectionData gameSelectionData;

    // Start is called before the first frame update
    private void Start()
    {   
        //Retrieve all references
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("DataHolder");

        foreach (GameObject targetObject in targetObjects){
            if (gameSelectionData == null)
            {
                gameSelectionData = targetObject.GetComponent<GameSelectionData>();
            }

            if (winLoseData == null)
            {
                winLoseData = targetObject.GetComponent<WinLoseData>();
            }

            if(timerData == null){
                timerData = targetObject.GetComponent<TimerData>();
            }

            // Exit loop early if both components are found
            if (gameSelectionData != null && winLoseData != null && timerData != null)
            {
                break;
            }
        }

        timerManager = GetComponent<TimerManager>();
        levelLoader = GetComponent<LevelLoader>();
        minigameLoader = GetComponent<MinigameLoader>();

        //Level Selected (Story Mode)
        if(gameSelectionData.SelectedLevelID != null){
            selectedLevel = levelLoader.getLevel(gameSelectionData);
            minigameLoader.SetUp(selectedLevel.MinigameList.MinigameList, selectedLevel.SpeedUpIntervals, timerData);
            timerManager.SetUp(timerData);
            //Temp Code:
            minigameLoader.LoadMinigame();
        }
        
        //Getting health manager
        healthManager = new HealthManager();
        Subscribe();
    }

    //Subscribes to times up event (when timer runs out)
    private void Subscribe()
    {
        timerManager.TimesUpEvent += TimesUpTriggered;
    }

    //Function triggered by event when time runs out
    private void TimesUpTriggered(object sender, EventArgs e)
    {   //TBA: Play UI zoom out animation
        if(!winLoseData.IsWin){
            Debug.Log("Lost");
            healthManager.ChangeHealth(-1);
            //TBA: Play UI Lose animation
        }else{
            Debug.Log("Won");
            winLoseData.IsWin = false;
            //TBA: Play UI Win animation
        }
        //When times up, the event triggers the load next minigame scene
        minigameLoader.LoadMinigame();
        //TBA: Play regular UI intermission transition until minigame scene is loaded
    }
}


