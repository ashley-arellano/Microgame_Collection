using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Playables;

public class States
{
    public Dictionary<String,BaseState> StatesDict{
        get { return statesDict; }
    }
    private Dictionary<String,BaseState> statesDict = new Dictionary<String,BaseState>(){
        {"MenuState", new MenuState()},
        {"PlayState", new MyPlayState()},
        {"PauseState", new MyPauseState()},
        {"MainMenuState", new MainMenuState()},
        {"ModeSelectMenuState", new ModeSelectMenuState()},
        {"LevelSelectMenuState", new LevelSelectMenuState()},
        {"OptionsMenuState", new OptionsMenuState()},
        {"CutsceneState", new CutsceneState()},
        {"PlayMinigamesState", new PlayMinigamesState()}

    };
    public BaseState CurrentSuperState{
        get{return currentSuperState;}
        set{currentSuperState=value;}
    }

    public BaseState CurrentSubState{
        get{return currentSubState;}
        set{currentSubState=value;}
    }
    public BaseState LastState{
        get{return lastState;}
        set{lastState=value;}
    }
    private BaseState currentSuperState;
    private BaseState currentSubState;
    private BaseState lastState;
}
