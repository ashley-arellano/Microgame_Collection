using UnityEditor;
using UnityEngine.Playables;

public class States
{
    public MenuState MenuState{
        get { return menuState; }
    }
    public MyPauseState MyPauseState{
        get { return myPauseState; }
    }
    public MyPlayState MyPlayState{
        get { return myPlayState; }
    }
    private MenuState menuState = new MenuState();
    
    private MyPauseState myPauseState = new MyPauseState();

    private MyPlayState myPlayState = new MyPlayState();
}
