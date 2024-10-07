public class States
{
    public MainMenuState MainMenuState{
        get { return mainMenuState; }
    }
    public PlayState PlayState{
        get { return playState; }
    }
    private MainMenuState mainMenuState = new MainMenuState();
    private PlayState playState = new PlayState();
}
