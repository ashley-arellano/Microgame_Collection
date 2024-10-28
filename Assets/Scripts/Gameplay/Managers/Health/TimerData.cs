using UnityEngine;
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
