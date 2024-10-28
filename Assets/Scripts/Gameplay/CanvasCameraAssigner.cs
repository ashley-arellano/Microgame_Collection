using UnityEngine;

public class CanvasCameraAssigner : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        // Ensure the canvas is set to ScreenSpaceCamera mode
        canvas.renderMode = RenderMode.ScreenSpaceCamera;

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            canvas.worldCamera = mainCamera;
        }
    }
}
