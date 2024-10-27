using System;
using System.Collections.Generic;

public class States
{
    public Dictionary<string,BaseState> StatesDict{
        get { return statesDict; }
    }
    private Dictionary<string,BaseState> statesDict = new Dictionary<string,BaseState>(){
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
    public BaseState LastSuperState{
        get{return lastSuperState;}
        set{lastSuperState=value;}
    }
    public BaseState LastSubState{
        get{return lastSubState;}
        set{lastSubState=value;}
    }
    private BaseState currentSuperState;
    private BaseState currentSubState;
    private BaseState lastSuperState;
    private BaseState lastSubState;
}
