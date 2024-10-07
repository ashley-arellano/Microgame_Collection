public class States
{
    public MainMenuState MainMenuState{
        get { return mainMenuState; }
    }
    public LevelOneState PlayState{
        get { return levelOneState; }
    }
    public LevelSelectState LevelSelectState{
        get { return levelSelectState; }
    }
    private MainMenuState mainMenuState = new MainMenuState();
    private LevelOneState levelOneState = new LevelOneState();
    private LevelSelectState levelSelectState = new LevelSelectState();
}
