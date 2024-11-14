using UnityEngine.UI;
using System;
using UnityEngine;
// Serializable class representing a pair of a string key and a Button value
[Serializable]
public class StringButtonPair : MonoBehaviour
{
    // Public property to get the key string
    public string Key {
        get { return key; }
    }

    // Public property to get the Button value
    public Button Value {
        get { return value; }
    }

    // Private serialized field for the key string
    [SerializeField]
    private string key;

    // Private serialized field for the Button value
    [SerializeField]
    private Button value;
}

