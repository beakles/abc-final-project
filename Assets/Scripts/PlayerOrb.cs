using UnityEngine;

public class PlayerOrb : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    bool isShooting = true;

    float velocityX;

    float travelTime = 1f;
    float travelCounter = 1f;

    float fadeTime = 0.5f;
    float fadeCounter = 0.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        velocityX = PlayerController.direction * .25f;
        transform.position = player.transform.position;

        travelCounter = travelTime;
        fadeCounter = fadeTime;

        isShooting = true;
    }

    private void OnDisable()
    {
        transform.position = ProjectileBehavior.storage;
    }

    private void Update()
    {
        if (isShooting)
        {
            animator.Play("Orb");
        }
        else
        {
            animator.Play("Pop");
        }
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            Shoot();
        }
        else
        {
            OrbPop();
        }
    }

    void Shoot()
    {
        if (travelCounter > 0)
        {
            ProjectileBehavior.Shoot(gameObject, velocityX, 0);
            travelCounter -= Time.deltaTime;
        }
        else
        {
            isShooting = false;
        }
    }

    void OrbPop()
    {
        if (fadeCounter > 0)
        {
            animator.Play("Pop");
            fadeCounter -= Time.deltaTime;
        }
        else
        {
            PlayerShoot.activeOrbs--;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Play a dull impact noise
            isShooting = false;
            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/ground", 1);
            //*************
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Enemy makes damaged noise
            isShooting = false;
            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/death", 1);
            //*************
        }

        if (collision.gameObject.CompareTag("Neutral"))
        {
            // Baa
            isShooting = false;
            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/ground", 1);
            //*************
        }
    }
}
