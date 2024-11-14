
public class GameStateContext{
    //Public property to access the current game states
    public States States
    {
        get { return states; }
    }

    //Instance of States, initialized by default
    private States states = new States();
}
