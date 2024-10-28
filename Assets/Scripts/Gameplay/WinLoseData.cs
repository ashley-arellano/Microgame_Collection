using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//So minigame scene changes the value here when its event triggers a win
//this data is grabbed by gamesystem scene
public class WinLoseData : MonoBehaviour
{
    public bool IsWin{
        get { return isWin; }
        set { isWin = value; }
    }
    private bool isWin = false;
}
