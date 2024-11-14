using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages level loading by retrieving level data based on a selected ID.
public class LevelLoader : MonoBehaviour
{
    //Get reference for scriptable object that contains data for all levels
    [SerializeField]
    private LevelCollectionScriptableObject allLevels;
    //Get reference for scriptable object that contains data for a particular level
    private LevelScriptableObject selectedLevel;
    //Retrieves data for the selected level from the level collection based on the given selection data.
    public LevelScriptableObject getLevel(GameSelectionData gameSelectionData){
        for (int i = 0; i < allLevels.LevelList.Count; i++){
            //if matches the selected level ID
            if(allLevels.LevelList[i].LevelID == gameSelectionData.SelectedLevelID){
                selectedLevel = allLevels.LevelList[i];
                return selectedLevel;
            }
        } 
        //if no match is found
        return null;
    }
}

