using System.Collections;
using System.Collections.Generic; 

public class GameStateContext 
{
    public States States{
        get{return states;}
    }
    private States states = new States();

    //Data to pass to states

    //Event for LevelSelectState

    //not really satifised with how to get level info, hmmmmm
    public GameSelectionMediator GameSelectionMediator{
        get{return gameSelectionMediator;}
    }
    

    private GameSelectionMediator gameSelectionMediator;

   
    

}
