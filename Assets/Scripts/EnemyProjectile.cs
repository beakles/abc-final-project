using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    /* Animator animator;
    bool isShooting = true;

    float velocityX;

    float travelTime = 2f;
    float travelCounter = 2f;

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
            Debug.Log("Oof");
            isShooting = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ouch");
            isShooting = false;
        }
    }*/
}
