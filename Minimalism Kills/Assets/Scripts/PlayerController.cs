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
    float curDirection;
    float groundCheckDis = 0.05f;
    float speed = 5;
    bool pressingJumpButton = false;
    bool onGround = true;
    float onGroundCheckDelayer;
    float onGroundCheckDelay = 0.2f;

    // Num glasses
    int glassesFound = 0;

    // Explosions
    public GameObject explosion;

    // Sounds
    public Sound walkingSound;
    public Sound jumpSound;
    public Sound glassesSound;
    public Sound passFlag;
    float walkingMaxVolume;
    //Coroutine walkingSoundOutFader;

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
        controls.Player.Movement.performed += ctx => SetDirection(ctx.ReadValue<float>());
        controls.Player.Movement.canceled += ctx => StoppedMoving();
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.Jump.canceled += ctx => StoppedJumping();
        controls.Player.Enable();

        // SpawnLoc
        spawnLoc = transform.position;
    }

    // Disables controls when the script is disabled
    private void OnDisable() { controls.Player.Disable(); }

    // Setting frame rate
    private void Start() { Application.targetFrameRate = 60; }

    // Movement and jumping
    private void Update()
    {
        // Checking when player has returned to ground
        if (!onGround && Time.time > onGroundCheckDelayer)
        {
            IsGrounded();
            if (onGround)
            {
                animator.SetBool("Jumping", false);
                transform.position += Vector3.up * 0.5f;
            }
        }

        if (!disabled)
        {
            // Horizontal movement
            if (curDirection != 0)
                rb.velocity = new Vector2(curDirection * speed, rb.velocity.y);
            else if (onGround)
                rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Walking", curDirection != 0 && onGround);

            // Jumping
            if (!pressingJumpButton)
                rb.gravityScale = 2.8f;
            else if (rb.velocity.y > 0)
                rb.gravityScale = 1;
            else
                rb.gravityScale = 2.5f;
        }

        // Sounds
        if (curDirection != 0 && onGround)
            walkingSound.audioSource.volume = walkingMaxVolume;
        else
            walkingSound.audioSource.volume = 0;
    }

    /* Sets current direction player is moving
     * @param direction current direction player is moving. Given by horizontal input
     */
    void SetDirection(float direction)
    {
        spriteRenderer.flipX = direction < 0;
        curDirection = direction;
    }

    // Stops player movement
    void StoppedMoving()
    {
        curDirection = 0;
    }

    /* Returns true if player is on ground
     * @return bool true if player is on ground
     */
    bool IsGrounded()
    {
        onGround = Physics2D.BoxCast(
            boxCollider.bounds.center, boxCollider.bounds.size, 0f, 
            Vector2.down,
            groundCheckDis).collider != null;
        return onGround;
    }

    // Tries to jump if player on ground
    void Jump()
    {
        if (IsGrounded() && !disabled)
        {
            jumpSound.audioSource.Play();
            pressingJumpButton = true;
            rb.AddForce(Vector2.up * 3000);
            rb.velocity += Vector2.up * 4;
            animator.SetBool("Jumping", true);
            onGround = false;
            onGroundCheckDelayer = Time.time + onGroundCheckDelay;
        }
    }

    // Player has released jump button
    void StoppedJumping() { pressingJumpButton = false; }

    /* Updates number of glasses found
     * @param numGlasses number of glasses found
     */
    public void SetNumGlasses(int numGlasses)
    {
        glassesFound = numGlasses;
        animator.SetInteger("Num Glasses", numGlasses);
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
        //Destroy(this.gameObject);
    }
}
