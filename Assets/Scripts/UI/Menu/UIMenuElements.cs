using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Script attached to the button panel component to manage UI button elements
public class UIMenuElements : MonoBehaviour
{
    // Serialized list of string-button pairs to expose for the Unity editor
    [SerializeField]
    private List<StringButtonPair> exposedDictionary; 

    // Public property to access the dictionary of button prefabs
    public Dictionary<string, Button> ButtonPrefabDic {
        get { return buttonPrefabDic; }
    }

    // Private dictionary to store the key-value pairs of buttons
    private Dictionary<string, Button> buttonPrefabDic = new Dictionary<string, Button>();

    // Awake is called when the script is first initialized, before Start
    private void Awake() {
        // Populate the buttonPrefabDic dictionary from the serialized list of string-button pairs
        foreach (StringButtonPair pair in exposedDictionary) {
            buttonPrefabDic.Add(pair.Key, pair.Value);
        }
    }

    // Makes the given GameObject visible (active)
    public void Visible(GameObject currentGameObject) {
        currentGameObject.SetActive(true);
    }

    // Makes the given GameObject invisible (inactive)
    public void NotVisible(GameObject currentGameObject) {
        currentGameObject.SetActive(false);
    }
}
