
public class MenuStates 
{
    public MainMenuState MainMenuState{
        get { return mainMenuState;}
    }
    public LevelSelectMenuState LevelSelectMenuState{
        get { return levelSelectMenuState;}
    }
    public OptionsMenuState OptionsMenuState{
        get { return optionsMenuState;}
    }
    private MainMenuState mainMenuState = new MainMenuState();
    private LevelSelectMenuState levelSelectMenuState = new LevelSelectMenuState();
    private OptionsMenuState optionsMenuState= new OptionsMenuState();
}
