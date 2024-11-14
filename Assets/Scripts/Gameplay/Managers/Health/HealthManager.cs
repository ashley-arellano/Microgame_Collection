using System.Collections;
using System.Collections.Generic;
//Script that manages the health of an player, allowing health to be modified
public class HealthManager 
{
    //Instance of HealthData to track the current health of the player
    private HealthData healthData = new HealthData();
    
    //Modifies the entity's health by a specified amount
    public void ChangeHealth(int amount){
        healthData.CurrentHealth += amount;
    }
}
