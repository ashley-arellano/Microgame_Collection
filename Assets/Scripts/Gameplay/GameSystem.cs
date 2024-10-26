using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//attached to a gameobject in scene GameSystem
public class GameSystem : MonoBehaviour
{
    [SerializeField]
    private LevelLoader levelLoader;
    private MinigameLoader minigameLoader;
    [SerializeField]
    private SceneHandler sceneHandler;
    [SerializeField]
    private TimerManager timerManager;
    private HealthManager healthManager;
    private LevelScriptableObject selectedLevel;
    //have to somehow get the instance from hsm
    private GameSelectionData gameSelectionData;
    private string currentMinigameID;
    // Start is called before the first frame update
    void Start()
    {   //Level Selected
        if(gameSelectionData.SelectedLevelID != null){
            selectedLevel = levelLoader.getLevel(gameSelectionData);
            minigameLoader = new MinigameLoader(timerManager, selectedLevel.MinigameList.MinigameList);
        }
        //Minigame Selected (Freeplay)

        healthManager = new HealthManager();
        Subscribe();
    }

    private void Subscribe()
    {
        timerManager.TimesUpEvent += TimesUpTriggered;
    }

    private void TimesUpTriggered(object sender, EventArgs e)
    {   //When times up, the event triggers the load next minigame
        string oldMinigameID = currentMinigameID;
        currentMinigameID = minigameLoader.LoadMinigame();
       // Pass an anonymous function that calls UnloadCurrentMinigame with the oldMinigameID
        sceneHandler.OnLoadScene(currentMinigameID, () => UnloadCurrentMinigame(oldMinigameID));
    }

    private void UnloadCurrentMinigame(string oldMinigameID){
        //Unload current minigame
        sceneHandler.OnUnloadScene(oldMinigameID);
    }
    


    //one thing i have to make sure is that
    //UI intermission loops until the minigame scene is loaded
    //before playing the transition animation (the zooming in one)
    //when minigame is done, it will play the transition animation (the zooming out one)
    //repeats until all minigames are played (for storymode)
    //https://www.youtube.com/watch?v=CE9VOZivb3I
    //going to have to find copyright free music lol for the health moving animation
    //like health becomes bigger, smaller, like it on the beat lol
}


