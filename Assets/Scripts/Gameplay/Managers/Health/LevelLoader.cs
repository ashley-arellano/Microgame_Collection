using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is first called
//then minigameloader is called is passed this information
public class LevelLoader : MonoBehaviour
{

    [SerializeField]
    private LevelCollectionScriptableObject allLevels;
    private LevelScriptableObject selectedLevel;
 
    private LevelScriptableObject getLevel(GameSelectionData gameSelectionData){
        for (int i = 0; i < allLevels.LevelList.Count; i++){
            if(allLevels.LevelList[i].LevelID == gameSelectionData.SelectedLevelID){
                selectedLevel = allLevels.LevelList[i];
                return selectedLevel;
            }
        } 
        return null;
    }

}

