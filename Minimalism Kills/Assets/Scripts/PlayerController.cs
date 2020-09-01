using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    InputMaster controls;

    // Attached components
    Rigidbody2D rb;
    Animator animator;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    // Movement
    const float GROUND_TOUCH_ADJUSTMENT = 0.5f;
    const float GROUND_CHECK_JUMP_DELAY = 0.2f;
    float groundCheckDis = 0.05f;
    Coroutine cr_moving;
    bool pressingJumpButton = false;
    bool onGround = true;
    float onGroundCheckDelayer;
    Coroutine cr_jumping;
    //const float SPRINTING_SPEED_MULTIPLIER = 1.4f;
    float speed = 5;
    //bool sprinting;
    //const float CROUCHING_SPEED_MULTIPLIER = 0.7f;
    //bool crouching;

    // Glasses
    int numGlasses;

    // Explosions
    public GameObject explosion;

    // Sounds
    public Sound walkingSound;
    public Sound jumpSound;
    public Sound glassesSound;
    public Sound passFlag;
    float walkingMaxVolume;

    // Disabled
    bool disabled;

    // Checkpoints
    Vector2 spawnLoc;

    // Initializing instance variables
    private void Awake()
    {
        controls = new InputMaster();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Sounds
        walkingSound.audioSource = gameObject.AddComponent<AudioSource>();
        walkingSound.audioSource.clip = walkingSound.audioClip;
        walkingMaxVolume = walkingSound.volume;
        walkingSound.audioSource.volume = 0;
        walkingSound.audioSource.loop = true;
        walkingSound.audioSource.Play();
        jumpSound.audioSource = gameObject.AddComponent<AudioSource>();
        jumpSound.audioSource.clip = jumpSound.audioClip;
        jumpSound.audioSource.volume = jumpSound.volume;
        glassesSound.audioSource = gameObject.AddComponent<AudioSource>();
        glassesSound.audioSource.clip = glassesSound.audioClip;
        glassesSound.audioSource.volume = glassesSound.volume;
        passFlag.audioSource = gameObject.AddComponent<AudioSource>();
        passFlag.audioSource.clip = passFlag.audioClip;
        passFlag.audioSource.volume = passFlag.volume;

        // Inputs
        controls.Player.Movement.performed += ctx => cr_moving = StartCoroutine(Move(ctx.ReadValue<float>()));
        controls.Player.Movement.canceled += ctx => StopCoroutine(cr_moving);
        controls.Player.Movement.canceled += ctx => StopIfOnGround();
        controls.Player.Movement.canceled += ctx => animator.SetBool("Walking", false);
        controls.Player.Movement.canceled += ctx => walkingSound.audioSource.volume = 0;
        controls.Player.Jump.performed += ctx => cr_jumping = StartCoroutine(Jump());
        controls.Player.Jump.canceled += ctx => StopCoroutine(cr_jumping);
        controls.Player.Jump.canceled += ctx => rb.gravityScale = 2.8f;
        /*controls.Player.Sprint.performed += ctx => sprinting = true;
        controls.Player.Sprint.canceled += ctx => sprinting = false;
        controls.Player.Crouch.performed += ctx => crouching = true;
        controls.Player.Crouch.canceled += ctx => crouching = false;*/


        controls.Player.Enable();

        // SpawnLoc
        spawnLoc = transform.position;
    }

    // Disables controls when the script is disabled
    private void OnDisable() { controls.Player.Disable(); }

    // Setting frame rate
    private void Start()
    {
        Application.targetFrameRate = 60;

        StartCoroutine(OnGroundChecker());
    }

    void StopIfOnGround()
    {
        if (onGround)
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    /* Updates number of glasses found
     * @param numGlasses number of glasses found
     */
    public void SetNumGlasses(int numGlasses)
    {
        if (numGlasses > this.numGlasses)
            animator.SetInteger("Num Glasses", numGlasses);
        this.numGlasses = numGlasses;
        glassesSound.audioSource.Play();
    }

    /* Sets disable status
     * @param disableStatus what to set disabled to
     */
    public void SetDisable(bool disableStatus)
    {
        if (disableStatus)
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Jumping", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        disabled = disableStatus;
    }

    /* Sets spawn location of player
     * @param tempSpawnLoc What to set the spawn location to
     */
    public void SetSpawnLoc(Transform tempSpawnLoc)
    {
        spawnLoc = tempSpawnLoc.position;
        passFlag.audioSource.Play();
    }

    // Called when player is killed
    public void Kill()
    {
        explosion.SetActive(true);
        explosion.GetComponent<Explosion>().StartExplosion(0.5f);
        explosion.transform.parent = null;
        transform.position = spawnLoc;
        FindObjectOfType<DeathsText>().AddDeath();
    }

    // Moving player left/right
    IEnumerator Move(float direction)
    {
        while (true)
        {
            while (disabled)
                yield return null;

            // Horizontal movement
            spriteRenderer.flipX = direction < 0;
            if (direction != 0)
            {
                /*if (crouching)
                    rb.velocity = new Vector2(direction * speed * CROUCHING_SPEED_MULTIPLIER, rb.velocity.y);
                else if (sprinting)
                    rb.velocity = new Vector2(direction * speed * SPRINTING_SPEED_MULTIPLIER, rb.velocity.y);
                else*/
                    rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            }
            else if (onGround)
                rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Walking", direction != 0 && onGround);

            // Sounds
            if (direction != 0 && onGround)// && !crouching)
                walkingSound.audioSource.volume = walkingMaxVolume;
            else
                walkingSound.audioSource.volume = 0;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Jump()
    {
        if (!onGround || disabled)
            while (true)
                yield return null;

        jumpSound.audioSource.Play();
        pressingJumpButton = true;
        rb.AddForce(Vector2.up * 3000);
        rb.velocity += Vector2.up * 4;
        animator.SetBool("Jumping", true);
        animator.SetBool("Walking", false);
        onGround = false;
        onGroundCheckDelayer = Time.time + GROUND_CHECK_JUMP_DELAY;

        while (true)
        {
            if (!pressingJumpButton)
                rb.gravityScale = 2.8f;
            else if (rb.velocity.y > 0)
                rb.gravityScale = 1;
            else
                rb.gravityScale = 2.5f;
            yield return null;
        }
    }

    IEnumerator OnGroundChecker()
    {
        while (true)
        {
            // Checking when player has returned to ground
            if (!onGround && Time.time > onGroundCheckDelayer)
            {
                onGround = Physics2D.BoxCast(
                    boxCollider.bounds.center, boxCollider.bounds.size, 0f,
                    Vector2.down,
                    groundCheckDis).collider != null;
                if (onGround)
                {
                    animator.SetBool("Jumping", false);
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    transform.position += Vector3.up * GROUND_TOUCH_ADJUSTMENT;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
