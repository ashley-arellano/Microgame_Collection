using System.Collections;
using System.Collections.Generic;
//Class that holds mutable data relating to the player's health
public class HealthData
{
    public int CurrentHealth { 
        get{return currentHealth;} 
        set{currentHealth = value;}
    }
    private int currentHealth = 4;

}
