using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//attached to a gameobject in scene GameSystem
public class GameSystem : MonoBehaviour
{
    //will have to add a uiTransitionHandler later
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
    void Start()
    {   
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

        //Level Selected
        if(gameSelectionData.SelectedLevelID != null){
            selectedLevel = levelLoader.getLevel(gameSelectionData);
            minigameLoader.SetUp(selectedLevel.MinigameList.MinigameList, selectedLevel.SpeedUpIntervals, timerData);
            timerManager.SetUp(timerData);
            //temp*************************************
            minigameLoader.LoadMinigame();
        }
        //Minigame Selected (Freeplay)

        //Getting health manager
        healthManager = new HealthManager();
        Subscribe();
    }

    //could make a WinLose Manager which has the event where bool isWin becomes true
    //which is checked during timesupTriggered

    private void Subscribe()
    {
        timerManager.TimesUpEvent += TimesUpTriggered;
    }

    //Function triggered by event when time runs out
    private void TimesUpTriggered(object sender, EventArgs e)
    {   //Play UI zoom out animation
        if(!winLoseData.IsWin){
            Debug.Log("Lost");
            healthManager.ChangeHealth(-1);
            //Play UI Lose animation
        }else{
            Debug.Log("Won");
            winLoseData.IsWin = false;
            //Play UI Win animation
        }
        //When times up, the event triggers the load next minigame scene
        minigameLoader.LoadMinigame();
        //Play regular UI intermission transition until minigame scene is loaded
    }

//play intermission ui animation during which minigame is loaded (minigame is loaded is done by minigameLoaded)
//zoom in minigame (ui animation)
//do minigame 
//zoom out minigame
//play  intermission animation during which minigame is loaded (minigame is loaded is done by minigameLoaded)



    
    


    //one thing i have to make sure is that
    //UI intermission loops until the minigame scene is loaded
    //before playing the transition animation (the zooming in one)
    //when minigame is done, it will play the transition animation (the zooming out one)
    //repeats until all minigames are played (for storymode)
    //https://www.youtube.com/watch?v=CE9VOZivb3I
    //going to have to find copyright free music lol for the health moving animation
    //like health becomes bigger, smaller, like it on the beat lol
}


