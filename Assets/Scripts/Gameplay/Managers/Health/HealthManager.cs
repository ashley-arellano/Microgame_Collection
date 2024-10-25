using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private HealthData healthData = new HealthData();

    public void ChangeHealth(int amount){
        healthData.CurrentHealth += amount;
    }
}
