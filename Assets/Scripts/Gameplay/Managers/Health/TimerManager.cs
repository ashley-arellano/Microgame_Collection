using UnityEngine;
using System;
//Script that manages the timer of a minigame
public class TimerManager : MonoBehaviour
{
    // Define an event using EventHandler
    public event EventHandler TimesUpEvent;
    private TimerData timerData;
    private float actualTimeRemaining;
    //Get reference to TimerData of the game system scene
    public void SetUp(TimerData timerData){
        this.timerData = timerData;
    }

    private void Update()
    {
        CountdownTime();
    }

    //Countdown the timer for the minigame
    public void CountdownTime(){
        //Sets the inital actual time remaining variable
        //Problem: Overwrites it, need to figure out when to get updated timeremaining 
        //when minigame is loaded (possibly through events)
        //actualTimeRemaining = timerData.TimeRemaining/timerData.SpeedFactor;
        //Reduces the timer
        if (actualTimeRemaining > 0)
        {
            actualTimeRemaining -= Time.deltaTime;
        }else{
            //Times run out
            Debug.Log("Time has run out!");
            actualTimeRemaining = 0;

        }
    }

    // Method to trigger the event when times is up
    protected virtual void OnTimesUpEvent()
    {
        // Check if there are any subscribers before invoking the event
        TimesUpEvent?.Invoke(this, EventArgs.Empty);
    }

}
