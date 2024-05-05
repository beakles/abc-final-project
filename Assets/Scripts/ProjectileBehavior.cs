using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public static Vector2 storage = new Vector2(-100, -100);

    public static void Shoot(GameObject gameObject, float velocityX, float velocityY)
    {
        gameObject.transform.position = new Vector2((gameObject.transform.position.x + velocityX), (gameObject.transform.position.y + velocityY));
    }
}
