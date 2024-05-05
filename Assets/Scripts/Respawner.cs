using UnityEngine;

public class Respawner : MonoBehaviour
{
     void OnTriggerExit2D(Collider2D collider)
    {
        collider.transform.position = new Vector2(0, 0);
    }
}
