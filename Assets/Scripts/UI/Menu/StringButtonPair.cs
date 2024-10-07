using UnityEngine.UI;
using System;
using UnityEngine;

[Serializable]
public class StringButtonPair : MonoBehaviour
{
    public string Key{
        get{return key;}
    }

    public Button Value{
        get{return value;}
    }
    private string key;
    private Button value;
}
