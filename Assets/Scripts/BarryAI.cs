using UnityEngine;

public class BarryAI : MonoBehaviour
{
    Animator animator;

    public int health = 3;
    int dropCount;

    // Start is called before the first frame update
    void Start()
    {
        dropCount = health;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            animator.Play("Hurt");
            Debug.Log("Owies");
            health--;
        }

        if (health <= 0)
        {
            LootDrop.Drop("BubblePuff", gameObject, dropCount);
            Destroy(gameObject);
        }
    }
}
