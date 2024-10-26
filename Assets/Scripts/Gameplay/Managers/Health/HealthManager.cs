using System.Collections;
using System.Collections.Generic;

public class HealthManager 
{
    private HealthData healthData = new HealthData();

    public void ChangeHealth(int amount){
        healthData.CurrentHealth += amount;
    }
}
