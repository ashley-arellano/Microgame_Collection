using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Add to canvas component
public class UIMenuElements : MonoBehaviour
{

    [SerializeField]
    private Canvas canvasElement;

    [SerializeField]
    private List<StringButtonPair> exposedDictionary; 
    private Dictionary<string, Button> buttonPrefabDic = new Dictionary<string, Button>();

    //Work-around to have a 'serialized field' for dictionaty to hold prefabs
    private void Awake(){
        foreach(StringButtonPair pair in exposedDictionary)
            buttonPrefabDic[pair.Key] = pair.Value;
    }

    public Dictionary<string, Button> InstaniateAllButtons(){
        Dictionary<string, Button> instaniatedButtons= new Dictionary<string, Button>();
        Button temp;
        foreach(KeyValuePair<string, Button> entry in buttonPrefabDic){
            // do something with entry.Value or entry.Key
            temp = Instantiate(entry.Value);
            temp.transform.SetParent(canvasElement.transform, false); //false - object's local position (relative to its new parent) will remain the same
            instaniatedButtons.Add(entry.Key, temp);
        }
        return instaniatedButtons;
    }
}
