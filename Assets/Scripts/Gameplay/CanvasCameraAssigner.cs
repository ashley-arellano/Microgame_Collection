using UnityEngine;
//Script assigns main camera to the current canvas of the scene 
public class CanvasCameraAssigner : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        // Ensure the canvas is set to ScreenSpaceCamera mode
        //to prevent canvas from overlaying on other gameobjects in view
        canvas.renderMode = RenderMode.ScreenSpaceCamera;

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            //Set canvas's reference to camera
            canvas.worldCamera = mainCamera;
        }
    }
}
