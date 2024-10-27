using System.Collections;
using System.Collections.Generic;
//So minigame scene changes the value here when its event triggers a win
//this data is grabbed by gamesystem scene
public class WinLoseData 
{
    public bool IsWin{
        get { return isWin; }
        set { isWin = value; }
    }
    private bool isWin = false;
}
