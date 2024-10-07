using UnityEngine;
using UnityEngine.UI;
//Add to canvas component
public class UIMenuElements : MonoBehaviour
{

    [SerializeField]
    private Canvas canvasElement;
    public Button Button1{
        get { return button1;}
    }

    public Button Button2{
        get { return button2;}
    }

    [SerializeField]
    private Button button1;

    [SerializeField]
    private Button button2;
    public Button InstaniateButton(Button buttonPrefab){
        Button button = Instantiate(buttonPrefab);
        button.transform.SetParent(canvasElement.transform, false); //false - object's local position (relative to its new parent) will remain the same
        return button;
    }
}
