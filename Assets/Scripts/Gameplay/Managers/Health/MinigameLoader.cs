using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinigameLoader : MonoBehaviour
{
    //Will like to do get component in the end
    [SerializeField]
    private TimerManager timerManager;
    
    public void Subscribe()
    {
        timerManager.TimesUpEvent += TimesUpTriggered;
    }

    private void TimesUpTriggered(object sender, EventArgs e)
    {
        Debug.Log("Times Up!");
        //Switch minigame
    }

    private void SwitchMinigame(){

    }
}
