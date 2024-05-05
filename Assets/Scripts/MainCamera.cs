using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static void ResizeCamera(float multiplier)
    {
        Camera.main.orthographicSize = 2f * multiplier;
    }
}
