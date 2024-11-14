using UnityEngine;
//Class that holds mutable data related to the timer of a minigame
public class TimerData : MonoBehaviour
{
    public float TimeRemaining{
        get { return timeRemaining; }
        set { timeRemaining = value; }
    }

    public float SpeedFactor{
        get { return speedFactor; }
        set { speedFactor = value; }
    }
    private float timeRemaining = 4;
    private float speedFactor = 1;
}
