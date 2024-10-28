using UnityEngine;
using System;

public class TimerManager : MonoBehaviour
{
    // Define an event using EventHandler
    public event EventHandler TimesUpEvent;
    private TimerData timerData;
    private float actualTimeRemaining;

    public void SetUp(TimerData timerData){
        this.timerData = timerData;
    }

    void Update()
    {
        CountdownTime();
    }

    public void CountdownTime(){
        actualTimeRemaining = timerData.TimeRemaining/timerData.SpeedFactor;
        if (actualTimeRemaining > 0)
        {
            actualTimeRemaining -= Time.deltaTime;
        }else{
            
            Debug.Log("Time has run out!");
            actualTimeRemaining = 0;

        }
    }

    // Method to trigger the event
    protected virtual void OnTimesUpEvent()
    {
        // Check if there are any subscribers before invoking the event
        TimesUpEvent?.Invoke(this, EventArgs.Empty);
    }

    /* code to add to subscriber
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
    }*/
}
