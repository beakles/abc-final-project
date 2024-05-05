using UnityEngine;

public class BubbleWoolScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameMultiplier.gameMultiplier += 2.5f;
            gameObject.SetActive(false);
        }
    }
}
