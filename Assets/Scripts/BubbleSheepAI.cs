using UnityEngine;

public class BubbleSheepAI : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    bool wool = true;
    int woolHealth = 3;

    bool walking = false;
    float velocity = 1f;
    float walkCounter = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wool)
        {
            if (walking)
            {
                animator.Play("Walk");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        else
        {
            if (walking)
            {
                animator.Play("Sheep_Walk");
            } else
            {
                animator.Play("Sheep_Idle");
            }
        }
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
        velocity = Random.Range(-.25f, .25f);;

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
            transform.position = new Vector2(transform.position.x + velocity, transform.position.y + Mathf.Abs(velocity / 3));
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
            if (woolHealth > 0)
            {
                Debug.Log("D:<");
                LootDrop.Drop("BubblePuff", gameObject);
            }
            else if(woolHealth == 0)
            {
                wool = false;
                LootDrop.Drop("BubbleWool", gameObject);
            }
            woolHealth--;
        }
    }
}
