using UnityEngine;
//************** use UnityOSC namespace...
using UnityOSC;
//*************

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D playerRigidbody2D;
    SpriteRenderer spriteRenderer;

    public CharacterController controller;

    float horizontalMovement;
    public static float direction = 1f;
    public static float agility = 3f;
    float jumpTime = 0.25f;
    float jumpTimeCounter = 0.25f;
    bool isJumping;
    bool isSwimming;

    public static bool isShooting = false;

    [SerializeField] // Make it available in the Unity editor
    Transform groundCheck = null;

    // Start is called before the first frame update
    void Start()
    {
        //************* Instantiate the OSC Handler...
        OSCHandler.Instance.Init ();
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/test1", 1);
        //*************

        //************* Send the message to the client...
        OSCHandler.Instance.SendMessageToClient ("pd", "/unity/master", 375);

        OSCHandler.Instance.SendMessageToClient ("pd", "/unity/tempo", GameMultiplier.gameTempo);
        //*************

        animator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/coin", 1);
            //*************
        }

        if (Input.GetButtonDown("Jump") && IsSwimming())
        {
            isSwimming = true;
        }
        else
        {
            isSwimming = false;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            isSwimming = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if (isShooting)
        {
            animator.Play("Shoot");
        }
        else if (!IsGrounded())
        {
            animator.Play("Jump");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (isJumping && !isSwimming)
        {
            Jump();
        }

        if (isSwimming)
        {
            Swim();
        }
    }

    void Move()
    {
        playerRigidbody2D.velocity = new Vector2(agility * horizontalMovement, playerRigidbody2D.velocity.y);
        if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
            direction = -1f;
        }
        else if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
            direction = 1f;
        }
    }

    void Swim()
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, agility);
    }

    void Jump()
    {
        // playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpHeight);

        if (jumpTimeCounter > 0)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, agility);
            jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
            jumpTimeCounter = jumpTime;
            isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        return groundCheck.GetComponent<GroundCheck>().isGrounded;
    }

    private bool IsSwimming()
    {
        return gameObject.GetComponent<WaterCheck>().isSwimming;
    }
}
