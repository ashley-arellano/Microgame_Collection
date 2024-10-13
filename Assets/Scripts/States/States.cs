public class States
{
    public MainMenuState MainMenuState{
        get { return mainMenuState; }
    }
    public LevelOneState LevelOneState{
        get { return levelOneState; }
    }
    public LevelTwoState LevelTwoState{
        get { return levelTwoState; }
    }
    public LevelSelectState LevelSelectState{
        get { return levelSelectState; }
    }
    private MainMenuState mainMenuState = new MainMenuState();
    private LevelOneState levelOneState = new LevelOneState();
    private LevelTwoState levelTwoState = new LevelTwoState();
    private LevelSelectState levelSelectState = new LevelSelectState();
}
