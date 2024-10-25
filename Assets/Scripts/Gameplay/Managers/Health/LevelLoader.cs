using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class LevelLoader : MonoBehaviour
{

    [SerializeField]
    private LevelCollectionScriptableObject allLevels;
    private LevelScriptableObject selectedLevel;
    // Start is called before the first frame update
    void Start()
    {
        //want to make dictionary 
        //will see if possible lol
        selectedLevel = allLevels.LevelList[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getLevel(){

    }
}
