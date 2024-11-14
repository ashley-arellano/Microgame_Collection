using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that contains mutable data relating to if player wins or loses minigame
public class WinLoseData : MonoBehaviour
{
    public bool IsWin{
        get { return isWin; }
        set { isWin = value; }
    }
    private bool isWin = false;
}
