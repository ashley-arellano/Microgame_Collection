using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Add to button panel component
public class UIMenuElements : MonoBehaviour
{

    [SerializeField]
    private RectTransform panelElement;

    [SerializeField]
    private List<StringButtonPair> exposedDictionary; 
    public Dictionary<string, Button> ButtonPrefabDic{
        get{return buttonPrefabDic;}
    }
    private Dictionary<string, Button> buttonPrefabDic = new Dictionary<string, Button>();

    //Work-around to have a 'serialized field' for dictionaty to hold prefabs
    private void Awake(){
        
        foreach(StringButtonPair pair in exposedDictionary){
            buttonPrefabDic.Add(pair.Key, pair.Value);
        }
        //Debug.Log(buttonPrefabDic.Count);
    }

    // public Dictionary<string, Button> InstaniateAllButtons(){
    //     Dictionary<string, Button> instaniatedButtons= new Dictionary<string, Button>();
    //     Button temp;
    //     foreach(KeyValuePair<string, Button> entry in buttonPrefabDic){
    //         // do something with entry.Value or entry.Key
    //         temp = Instantiate(entry.Value);
    //         temp.transform.SetParent(canvasElement.transform, false); //false - object's local position (relative to its new parent) will remain the same
    //         instaniatedButtons.Add(entry.Key, temp);
    //     }
    //     return instaniatedButtons;
    // }

    public void Visible(GameObject currentGameObject){
        currentGameObject.SetActive(true);
    }

    public void NotVisible(GameObject currentGameObject){
        currentGameObject.SetActive(false);
    }
}
