using UnityEngine;

public class CanvasCameraAssigner : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        Debug.Log("Before ScreenSpaceCamera check");
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            Debug.Log("after ScreenSpaceCamera check");
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                Debug.Log("assignming camera");
                canvas.worldCamera = mainCamera;
            }
        }
    }
}

