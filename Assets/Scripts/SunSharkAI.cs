using UnityEngine;

public class SunSharkAI : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    public int health = 2;
    int dropCount;

    bool walking = false;
    float velocity = 1f;
    float walkCounter = 1f;

    // Start is called before the first frame update
    void Start()
    {
        dropCount = health;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (walking)
        {
            Move();
        }
        else
        {
            DetermineWalk();
        }
    }

    void DetermineWalk()
    {
        walkCounter = Random.Range(.25f, 1f);
        velocity = Random.Range(-.25f, .25f); ;

        if (Time.frameCount % 7 == 0)
        {
            walking = true;
        }
    }

    void Move()
    {
        if (velocity < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (velocity > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (walkCounter > 0)
        {
            transform.position = new Vector2(transform.position.x + velocity, transform.position.y);
            walkCounter -= Time.deltaTime;
        }
        else
        {
            walking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
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
